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

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS
{
    [Register ("TalentPoolViewController")]
    partial class TalentPoolViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_empty_talent_pool_ct { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_container { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_empty_talent_pool { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbl_empty_talent_pool_ct != null) {
                lbl_empty_talent_pool_ct.Dispose ();
                lbl_empty_talent_pool_ct = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }

            if (v_container != null) {
                v_container.Dispose ();
                v_container = null;
            }

            if (v_empty_talent_pool != null) {
                v_empty_talent_pool.Dispose ();
                v_empty_talent_pool = null;
            }
        }
    }
}