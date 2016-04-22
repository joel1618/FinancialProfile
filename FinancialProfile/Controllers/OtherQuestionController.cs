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
            if (record.Answer == null || record.Answer == "")
            {
                labelQuestion.Text = record.Question;
            }
            else if (Id != 7)
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (OtherQuestionController)storyboard.InstantiateViewController("OtherQuestionController");
                controller.Id = Id + 1;
                this.PresentViewController(controller, true, null);
            }
            else
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (OverviewController)storyboard.InstantiateViewController("OverviewController");
                this.PresentViewController(controller, true, null);
            }
        }

        private void GetQuestion(int Id)
        {
            record = repository.Get(Id);
        }

        private void HandleTouchUpInsideSave(object sender, EventArgs ea)
        {
            record.Answer = textboxTotal.Text;
            repository.Update(record);
            if(Id == 7)
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (OverviewController)storyboard.InstantiateViewController("OverviewController");
                this.PresentViewController(controller, true, null);
            }
            else
            {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                var controller = (OtherQuestionController)storyboard.InstantiateViewController("OtherQuestionController");
                controller.Id = Id + 1;
                this.PresentViewController(controller, true, null);
            }
            
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
