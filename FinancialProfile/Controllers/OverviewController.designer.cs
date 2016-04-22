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

		void ReleaseDesignerOutlets ()
		{
			if (buttonClear != null) {
				buttonClear.Dispose ();
				buttonClear = null;
			}
		}
	}
}
