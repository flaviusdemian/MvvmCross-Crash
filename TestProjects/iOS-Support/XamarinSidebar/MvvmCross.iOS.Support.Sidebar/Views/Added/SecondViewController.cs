using System;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS
{
	[MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, false)]
	[MvxFromStoryboard("MainStoryboard")]
	public partial class SecondViewController : UIViewController
	{
		public SecondViewController(IntPtr handle) : base(handle)
		{
		}

		public SecondViewController()
		{
		}

	}
}

