using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells
{
	public partial class MenuViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("MenuViewCell");

		public MenuViewCell()
		{
			Bind();
		}

		public MenuViewCell(IntPtr handle): base(handle)
		{
			Bind();
		}


		public UILabel CountLabel
		{
			get { return lbl_number; }
			set { lbl_number = value; }
		}

		public UIImageView IconImage
		{
			get { return iv_icon; }
			set { iv_icon = value; }
		}

		internal static nfloat GetCellHeight()
		{
			return 80f;
		}

		#region private methods

		private void Bind()
		{
			this.DelayBind(() =>
			{
				lbl_text.TextColor = UIColor.White;

				var bindingSet = this.CreateBindingSet<MenuViewCell, MenuItem>();
				bindingSet.Bind(lbl_text).To(vm => vm.Text);
				bindingSet.Bind(lbl_number).To(vm => vm.NotificationsCount);

				bindingSet.Apply();
			});
		}

		#endregion
	}
}
