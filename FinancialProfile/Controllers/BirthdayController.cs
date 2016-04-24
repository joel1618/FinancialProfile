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
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            buttonSave.TouchUpInside += HandleTouchUpInsideSave;

            record = repository.Get(1);
            labelQuestion.Text = record.Question;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        private void HandleTouchUpInsideSave(object sender, EventArgs ea)
        {
            record.Answer = DateTime.Parse(dateBirthday.Date.ToString()).ToShortDateString();
            repository.Update(record);
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            var controller = (OtherQuestionController)storyboard.InstantiateViewController("OtherQuestionController");
            for(int i = 2; i < 7; i++)
            {
                record = repository.Get(i);
                if(record.Answer == null || record.Answer == "")
                {
                    controller.Id = i;
                    this.PresentViewController(controller, true, null);
                    break;
                }
                if(i == 7)
                {
                    controller.Id = 7;
                    this.PresentViewController(controller, true, null);
                    break;
                }
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}