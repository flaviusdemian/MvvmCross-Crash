using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
    public abstract class BaseMvxTableViewController : MvxTableViewController
    {

        public BaseMvxTableViewController(IntPtr handle) : base(handle)
        {
            Handle = handle;
        }

        public BaseMvxTableViewController()
        {
        }
    }

    public abstract class BaseMvxTableViewController<TViewModel> : BaseMvxTableViewController
        where TViewModel : class, IMvxViewModel
    {

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected BaseMvxTableViewController(IntPtr handle) : base(handle)
        {
        }

        public BaseMvxTableViewController()
        {
        }
    }
}