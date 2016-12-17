using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
	[MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, false)]
	[MvxFromStoryboard("MainStoryboard")]
	public partial class TemplatesViewController : BaseMvxViewController<ShiftTemplatesViewModel>
	{
		public TemplatesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var source = new TemplatesTableViewSource(TableView);
			TableView.Source = source;
		    TableView.Hidden = false;

            var bindingSet = this.CreateBindingSet<TemplatesViewController, ShiftTemplatesViewModel>();
			bindingSet.Bind(source).To(vm => vm.ShiftTemplates);


			bindingSet.Apply();
			TableView.ReloadData();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			ViewModel?.GetShiftTemplates();
		}
	}

	public class TemplatesTableViewSource : MvxTableViewSource
	{
		public TemplatesTableViewSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse(UINib.FromName(TemplatesTableViewCell.Key, NSBundle.MainBundle), TemplatesTableViewCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			var castedCell = (TemplatesTableViewCell)tableView.DequeueReusableCell(TemplatesTableViewCell.Key, indexPath);
			return castedCell;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return TemplatesTableViewCell.GetCellHeight();
		}
	}
}

