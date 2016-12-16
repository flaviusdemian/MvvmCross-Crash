using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells
{
    public partial class TemplatesTableViewCell : MvxTableViewCell
    {
		public static readonly NSString Key = new NSString("TemplatesTableViewCell");

		public TemplatesTableViewCell()
		{
			Bind();
		}

        public TemplatesTableViewCell (IntPtr handle) : base (handle)
        {
			Bind();
        }

		internal static nfloat GetCellHeight()
		{
			return 210f;
		}

		private void Bind()
		{
			this.DelayBind(() =>
			{
				var bindingSet = this.CreateBindingSet<TemplatesTableViewCell, ShiftTemplateUI>();

				bindingSet.Bind(lbl_skill_title).To(vm => vm.Skill.Name);
				bindingSet.Bind(lbl_people_count).To(vm => vm.NumberOfPeopleNeeded);
				bindingSet.Bind(lbl_date_and_hour).To(vm => vm.ShiftTime);

				v_whole_container.Layer.BorderWidth = 2f;
				v_whole_container.Layer.BorderColor = UIColor.FromRGB(243, 242, 242).CGColor;

				bindingSet.Apply();
			});
		}
    }
}