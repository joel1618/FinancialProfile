using FinancialProfile.Repositories;
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
        private int Id = 2;
        public OtherQuestionController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
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
                //TODO: Set QuestionId in observer
                this.PerformSegue("OtherQuestionController", this);
            }
            else
            {
                this.PerformSegue("OverviewController", this);
            }
        }

        private void GetQuestion(int Id)
        {
            record = repository.Get(Id);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
