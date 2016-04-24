using FinancialProfile.Repositories;
using System;
using System.Threading.Tasks;
using UIKit;
using FinancialProfileDomain = FinancialProfile.Models.FinancialProfile;

namespace FinancialProfile
{
    //TODO: Show graphs
    //TODO: Link to lendingclub
	partial class OverviewController : UIViewController
	{
        private FinancialProfileRepository repository = new FinancialProfileRepository();
        private FinancialProfileDomain record = null;
        public OverviewController (IntPtr handle) : base (handle)
		{
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            buttonClear.TouchUpInside += HandleButtonClear;
            // Perform any additional setup after loading the view, typically from a nib.
            CalculateFinancialProfile();
        }

        
        private void CalculateFinancialProfile()
        {
            MakeSureAllQuestionsAnswered();
            var todaysDate = DateTime.Now.Date;
            var birthday = DateTime.Parse(repository.Get(1).Answer);
            var netWorthDate = repository.Get(2).ModifiedAt;
            var netWorth = int.Parse(repository.Get(2).Answer);
            var makeEachMonth = int.Parse(repository.Get(3).Answer);
            var spendOnHouse = int.Parse(repository.Get(4).Answer);
            var spendOnCar = int.Parse(repository.Get(5).Answer);
            var spendOnOther = int.Parse(repository.Get(6).Answer);
            var spendEachMonth = spendOnHouse + spendOnCar + spendOnOther;


            var totalNeeded = spendEachMonth * 12.5 * 12;//assuming 8% interest

            var principal = netWorth;
            var time = 0.00;
            var rate = (double)8 / (double)100;
            var depositPerMonth = makeEachMonth - spendEachMonth;
            var depositEachDay = (double)depositPerMonth * 12 / 365;
            time = CalculateTime(principal, rate, depositEachDay, totalNeeded);
            var d1 = DateTime.Parse(todaysDate.ToString("d"));
            var d2 = DateTime.Parse(netWorthDate.Value.ToString("d"));
            var daysSinceNetWorthSet = (d1 - d2).TotalDays;
           
            //Day's before net worth * interest > spending (net spending is positive?)
            textboxTimeRemaining.Text = (time - daysSinceNetWorthSet).ToString() + " days";
            labelSummary.Text = "You will be " + 
                Math.Truncate((((todaysDate - birthday).TotalDays) + (time - daysSinceNetWorthSet)) / 365) +
                " years old by the time your net worth could potentially cover all of what you spend each year.  " +
                "Below you will find a great snapshot of todays potential earnings as well as helpful information to help you retire earlier!";
            //Today's interest earned
            var currentNetWorth = NetWorthCalculator(principal, rate, depositEachDay, daysSinceNetWorthSet);
            textboxInterestToday.Text = String.Format("{0:C}", (decimal)Math.Round((double.Parse(currentNetWorth.ToString()) * .08 / 365),2));
            textboxNetWorthToday.Text = String.Format("{0:C}", (decimal)currentNetWorth);
            textboxSpendingToday.Text = String.Format("{0:C}", (decimal)Math.Round((double)spendEachMonth / 30, 2));
        }

        //http://quant.stackexchange.com/questions/25586/compound-interest-calculator-solving-for-time-with-deposits/25587#25587
        private double CalculateTime(double principal, double rate, double deposit, double total)
        {
            //days needed to save to reach total goal
            var time = Math.Log((total + (deposit / (rate / 365))) / (principal + (deposit / (rate / 365)))) / Math.Log(1 + (rate / 365));
            time = Math.Round(time, MidpointRounding.AwayFromZero);
            return time;
        }

        //http://www.moneychimp.com/articles/finworks/fmbasinv.htm
        private double NetWorthCalculator(double principal, double rate, double deposit, double time)
        {
            var power = (double)time / 365;
            if(power == 0)
            {
                return principal;
            }
            var currentNetWorth = Math.Pow(principal * (1 + rate), power) + deposit * power * ((Math.Pow((1 + rate), power) - 1) / rate);
            return currentNetWorth;
        }

        private void MakeSureAllQuestionsAnswered()
        {
            for(int i = 1; i <6; i++)
            {
                GetQuestion(i);
                if(record.Answer == null || record.Answer == "")
                {
                    Transition(i);
                }
            }
        }

        private void Transition(int i)
        {
            if(i == 1)
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (BirthdayController)storyboard.InstantiateViewController("BirthdayController");
                this.PresentViewController(controller, true, null);
            }
            else
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (OtherQuestionController)storyboard.InstantiateViewController("OtherQuestionController");
                controller.Id = i;
                this.PresentViewController(controller, true, null);
            }
        }

        private void GetQuestion(int Id)
        {
            record = repository.Get(Id);
        }

        //TODO actuated by button click
        private async void HandleButtonClear(object sender, EventArgs ea)
        {
            int button = await ShowAlert("Clear", "Are you sure you want to restart your profile?", "Yes", "Cancel");
            if (button == 0)
            {

                for (int i = 1; i < 7; i++)
                {
                    GetQuestion(i);
                    record.Answer = "";
                    repository.Update(record);
                }
                Transition(1);
            }
        }

        public static Task<int> ShowAlert(string title, string message, params string[] buttons)
        {
            var tcs = new TaskCompletionSource<int>();
            var alert = new UIAlertView
            {
                Title = title,
                Message = message
            };
            foreach (var button in buttons)
                alert.AddButton(button);
            alert.Clicked += (s, e) => tcs.TrySetResult((int)e.ButtonIndex);
            alert.Show();
            return tcs.Task;
        }
    }
}
