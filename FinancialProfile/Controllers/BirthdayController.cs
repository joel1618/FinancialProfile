using CoreGraphics;
using FinancialProfile.Repositories;
using System;
using UIKit;
using Foundation;
using FinancialProfileDomain = FinancialProfile.Models.FinancialProfile;

namespace FinancialProfile
{
    public partial class BirthdayController : UIViewController
    {
        private FinancialProfileRepository repository = new FinancialProfileRepository();
        private FinancialProfileDomain record = null;
        public BirthdayController(IntPtr handle) : base(handle)
        {
            record = repository.Get(1);
            if (record.Answer != null && record.Answer != "")
            {
                //redirect to other questions
                //TODO: Set observer id
                PerformSegue("OtherQuestionController", this);
            }
            else
            {
                labelQuestion.Text = record.Question;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            buttonSave.TouchUpInside += HandleTouchUpInsideSave;
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "OtherQuestionController")
            {
                var controller = (OtherQuestionController)segue.DestinationViewController;
                controller.Id = 2;
            }
        }

        private void HandleTouchUpInsideSave(object sender, EventArgs ea)
        {
            record.Answer = DateTime.Parse(dateBirthday.Date.ToString()).ToShortDateString();
            repository.Update(record);
            this.PerformSegue("OtherQuestionController", this);
            //new UIAlertView("Touch3", "TouchUpInside handled", null, "OK", null).Show();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}