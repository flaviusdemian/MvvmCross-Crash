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

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
    [Register ("ChoosePeopleViewController")]
    partial class ChoosePeopleViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_choose_people_all { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_choose_people_continue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel l_choose_people_available { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel l_choose_people_selected { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tv_choose_people1 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_choose_people_all != null) {
                btn_choose_people_all.Dispose ();
                btn_choose_people_all = null;
            }

            if (btn_choose_people_continue != null) {
                btn_choose_people_continue.Dispose ();
                btn_choose_people_continue = null;
            }

            if (l_choose_people_available != null) {
                l_choose_people_available.Dispose ();
                l_choose_people_available = null;
            }

            if (l_choose_people_selected != null) {
                l_choose_people_selected.Dispose ();
                l_choose_people_selected = null;
            }

            if (tv_choose_people1 != null) {
                tv_choose_people1.Dispose ();
                tv_choose_people1 = null;
            }
        }
    }
}