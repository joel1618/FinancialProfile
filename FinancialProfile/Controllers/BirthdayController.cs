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
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            if (record.Answer != null && record.Answer != "")
            {
                //redirect to other questions
                //TODO: Set observer id
                this.PerformSegue("OtherQuestionController", this);
            }
            else
            {
                labelQuestion.Text = record.Question;
            }
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}