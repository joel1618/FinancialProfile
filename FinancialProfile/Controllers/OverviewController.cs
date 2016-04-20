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
            // Perform any additional setup after loading the view, typically from a nib.
            CalculateFinancialProfile();
        }

        private void CalculateFinancialProfile()
        {
            GetQuestion(1);
        }

        private void GetQuestion(int Id)
        {
            record = repository.Get(Id);
        }

        //TODO
        private void ClearFinancialProfile()
        {
            //clear data and redirect to first question
        }
    }
}
