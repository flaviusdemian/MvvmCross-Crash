using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells
{
	public partial class ChoosePeopleTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ChoosePeopleTableViewCell");
		private MvxImageViewLoader mImageHelper;
		public UIView RatingView => rv_stars;

		public ChoosePeopleTableViewCell()
		{
			InitialiseImageHelper();
			Bind();
		}

		public ChoosePeopleTableViewCell(IntPtr handle) : base(handle)
		{
			InitialiseImageHelper();
			Bind();
		}

		public UIImageView ProfileImageView => iv_image;

		public static nfloat GetCellHeight()
		{
			return 100f;
		}

		#region private methods

		private void InitialiseImageHelper()
		{
			mImageHelper = new MvxImageViewLoader(() => iv_image);
		}

		private void Bind()
		{
			this.DelayBind(() =>
			{
				var bindingSet = this.CreateBindingSet<ChoosePeopleTableViewCell, EmployeeUI>();
				bindingSet.Bind(l_name).To(vm => vm.Name);
				bindingSet.Bind(l_skills).To(vm => vm.SkillSet);
				bindingSet.Bind(mImageHelper).To(vm => vm.ProfilePicture);
				bindingSet.Bind(sw_selected).For(v => v.On).To(vm => vm.Selected);

				bindingSet.Apply();
			});
		}

		#endregion
	}
}
