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
	[Register ("OtherQuestionController")]
	partial class OtherQuestionController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonSave { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelQuestion { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField textboxTotal { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (buttonSave != null) {
				buttonSave.Dispose ();
				buttonSave = null;
			}
			if (labelQuestion != null) {
				labelQuestion.Dispose ();
				labelQuestion = null;
			}
			if (textboxTotal != null) {
				textboxTotal.Dispose ();
				textboxTotal = null;
			}
		}
	}
}
