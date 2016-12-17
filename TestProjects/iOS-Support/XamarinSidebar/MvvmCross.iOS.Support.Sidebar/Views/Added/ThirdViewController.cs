using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core;
using MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS
{
	[MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, false)]
	[MvxFromStoryboard("MainStoryboard")]
	public partial class ThirdViewController : BaseMvxViewController<ThirdViewModel>
	{
		public ThirdViewController(IntPtr handle) : base(handle)
		{
		}

		public ThirdViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var bindingSet = this.CreateBindingSet<ThirdViewController, ThirdViewModel>();
			bindingSet.Apply();
		}
	}
}

