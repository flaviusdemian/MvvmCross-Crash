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
    [Register ("ChoosePeopleTableViewCell")]
    partial class ChoosePeopleTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel l_name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel l_skills { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rv_stars { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch sw_selected { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iv_image != null) {
                iv_image.Dispose ();
                iv_image = null;
            }

            if (l_name != null) {
                l_name.Dispose ();
                l_name = null;
            }

            if (l_skills != null) {
                l_skills.Dispose ();
                l_skills = null;
            }

            if (rv_stars != null) {
                rv_stars.Dispose ();
                rv_stars = null;
            }

            if (sw_selected != null) {
                sw_selected.Dispose ();
                sw_selected = null;
            }
        }
    }
}