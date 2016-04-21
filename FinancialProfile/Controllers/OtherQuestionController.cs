using FinancialProfile.Repositories;
using Foundation;
using System;
using UIKit;
using FinancialProfileDomain = FinancialProfile.Models.FinancialProfile;

namespace FinancialProfile
{
    public partial class OtherQuestionController : UIViewController
    {
        private FinancialProfileRepository repository = new FinancialProfileRepository();
        private FinancialProfileDomain record = null;
        //TODO: Read from observer
        public int Id;
        public OtherQuestionController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            buttonSave.TouchUpInside += HandleTouchUpInsideSave;
            // Perform any additional setup after loading the view, typically from a nib.
            HandleQuestion();
        }

        private void HandleQuestion()
        {
            GetQuestion(Id);
            if (record.Answer != null && record.Answer != "")
            {
                labelQuestion.Text = record.Question;
            }
            else if (Id != 7)
            {                
                this.PerformSegue("OtherQuestionController", this);
            }
            else
            {
                this.PerformSegue("OverviewController", this);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "OtherQuestionController")
            {
                var controller = (OtherQuestionController)segue.DestinationViewController;
                controller.Id = Id + 1;
            }
        }

        private void GetQuestion(int Id)
        {
            record = repository.Get(Id);
        }

        private void HandleTouchUpInsideSave(object sender, EventArgs ea)
        {
            record.Answer = "";//TODO: Answer
            repository.Update(record);
            this.PerformSegue("OtherQuestionController", this);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
