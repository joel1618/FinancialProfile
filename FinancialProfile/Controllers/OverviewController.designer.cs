// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FinancialProfile
{
	[Register ("OverviewController")]
	partial class OverviewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonClear { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelSummary { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField textboxInterestToday { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField textboxTimeRemaining { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (buttonClear != null) {
				buttonClear.Dispose ();
				buttonClear = null;
			}
			if (labelSummary != null) {
				labelSummary.Dispose ();
				labelSummary = null;
			}
			if (textboxInterestToday != null) {
				textboxInterestToday.Dispose ();
				textboxInterestToday = null;
			}
			if (textboxTimeRemaining != null) {
				textboxTimeRemaining.Dispose ();
				textboxTimeRemaining = null;
			}
		}
	}
}
