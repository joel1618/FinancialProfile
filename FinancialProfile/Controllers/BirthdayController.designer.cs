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
	[Register ("BirthdayController")]
	partial class BirthdayController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonSave { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIDatePicker dateBirthday { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelQuestion { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (buttonSave != null) {
				buttonSave.Dispose ();
				buttonSave = null;
			}
			if (dateBirthday != null) {
				dateBirthday.Dispose ();
				dateBirthday = null;
			}
			if (labelQuestion != null) {
				labelQuestion.Dispose ();
				labelQuestion = null;
			}
		}
	}
}
