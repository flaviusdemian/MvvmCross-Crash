using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreGraphics;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
    public abstract class BaseMvxViewController : MvxViewController
    {

        public BaseMvxViewController(IntPtr handle)
        {
            Handle = handle;
        }

        public BaseMvxViewController()
        {
        }

        public void RemoveTableViewSeparator(UITableView tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }
    }

    public abstract class BaseMvxViewController<TViewModel> : BaseMvxViewController
        where TViewModel : class, IMvxViewModel
    {

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected BaseMvxViewController(IntPtr handle) : base(handle)
        {
        }

        public BaseMvxViewController() : base()
        {
        }
    }
}