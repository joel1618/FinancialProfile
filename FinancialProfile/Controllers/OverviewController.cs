using FinancialProfile.Repositories;
using System;
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

        //http://www.thecalculatorsite.com/articles/finance/compound-interest-formula.php?page=2
        private void CalculateFinancialProfile()
        {
            MakeSureAllQuestionsAnswered();
            //TODO: Do math
            var birthday = int.Parse(repository.Get(1).Answer);
            var netWorth = int.Parse(repository.Get(2).Answer);
            var makeEachMonth = int.Parse(repository.Get(3).Answer);
            var spendOnHouse = int.Parse(repository.Get(4).Answer);
            var spendOnCar = int.Parse(repository.Get(5).Answer);
            var spendOnOther = int.Parse(repository.Get(6).Answer);
            var spendEachMonth = spendOnHouse + spendOnCar + spendOnOther;
            var totalNeededMonthly = spendEachMonth * 12.5;
            var monthsToSave = (totalNeededMonthly - netWorth) / (makeEachMonth - spendEachMonth);
             
            var lastNetWorthDate = repository.Get(2).CreatedAt;
            var saveEachMonth = "";
        }

        private void MakeSureAllQuestionsAnswered()
        {
            for(int i = 1; i < 6; i++)
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
        private void HandleButtonClear(object sender, EventArgs ea)
        {
            for(int i = 1; i < 7; i++)
            {
                GetQuestion(i);
                record.Answer = "";
                repository.Update(record);
            }
            Transition(1);
        }
    }
}
