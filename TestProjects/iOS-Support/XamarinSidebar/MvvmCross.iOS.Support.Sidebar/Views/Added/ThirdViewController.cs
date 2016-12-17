using System;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS
{
	[MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, false)]
	[MvxFromStoryboard("MainStoryboard")]
	public partial class ThirdViewController : UIViewController
	{
		public ThirdViewController(IntPtr handle) : base(handle)
		{
		}

		public ThirdViewController()
		{
		}
	}
}

