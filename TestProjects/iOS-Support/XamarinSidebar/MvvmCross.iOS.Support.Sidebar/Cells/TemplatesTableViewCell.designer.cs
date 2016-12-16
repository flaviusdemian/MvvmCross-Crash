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
    [Register ("TemplatesTableViewCell")]
    partial class TemplatesTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_arrow_right { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_cancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView iv_location { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_date_and_hour { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_location { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_people_count { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_skill_title { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_title_container { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_whole_container { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (iv_arrow_right != null) {
                iv_arrow_right.Dispose ();
                iv_arrow_right = null;
            }

            if (iv_cancel != null) {
                iv_cancel.Dispose ();
                iv_cancel = null;
            }

            if (iv_location != null) {
                iv_location.Dispose ();
                iv_location = null;
            }

            if (lbl_date_and_hour != null) {
                lbl_date_and_hour.Dispose ();
                lbl_date_and_hour = null;
            }

            if (lbl_location != null) {
                lbl_location.Dispose ();
                lbl_location = null;
            }

            if (lbl_people_count != null) {
                lbl_people_count.Dispose ();
                lbl_people_count = null;
            }

            if (lbl_skill_title != null) {
                lbl_skill_title.Dispose ();
                lbl_skill_title = null;
            }

            if (v_title_container != null) {
                v_title_container.Dispose ();
                v_title_container = null;
            }

            if (v_whole_container != null) {
                v_whole_container.Dispose ();
                v_whole_container = null;
            }
        }
    }
}