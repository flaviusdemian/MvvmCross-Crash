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

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells
{
    [Register ("MenuViewCell")]
    partial class MenuViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_icon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_number { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_text { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iv_icon != null) {
                iv_icon.Dispose ();
                iv_icon = null;
            }

            if (lbl_number != null) {
                lbl_number.Dispose ();
                lbl_number = null;
            }

            if (lbl_text != null) {
                lbl_text.Dispose ();
                lbl_text = null;
            }
        }
    }
}