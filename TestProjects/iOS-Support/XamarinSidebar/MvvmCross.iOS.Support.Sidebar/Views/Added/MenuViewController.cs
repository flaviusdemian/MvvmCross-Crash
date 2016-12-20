using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
	[MvxPanelPresentation(MvxPanelEnum.Left, MvxPanelHintType.ActivePanel, false)]
	public partial class MenuViewController :  BaseMvxTableViewController<MenuViewModel>, IMvxSidebarMenu
	{
		public virtual UIImage MenuButtonImage => UIImage.FromBundle("Images/threelines");

		public virtual bool HasShadowing => true;
		private int MaxMenuWidth = 300;
		private int MinSpaceRightOfTheMenu = 55;

		public int MenuWidth => UserInterfaceIdiomIsPhone ?
		int.Parse(UIScreen.MainScreen.Bounds.Width.ToString()) - MinSpaceRightOfTheMenu : MaxMenuWidth;

		private bool UserInterfaceIdiomIsPhone
		{
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public MenuViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.Gray;

			var source = new MenuItemTableSource(TableView, this);
			TableView.Source = source;

            var bindingSet = this.CreateBindingSet<MenuViewController, MenuViewModel>();
			bindingSet.Bind(source).To(vm => vm.MenuItems);
			bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.MenuItemClickedCommand);

			bindingSet.Apply();

			TableView.ReloadData();

			SearchDisplayController?.Dispose();
		}

		private void OnSignOutAction(bool success, int statusCode)
		{
		}
	}

	public class MenuItemTableSource : MvxTableViewSource
	{

		public MenuItemTableSource(UITableView tableView, BaseMvxTableViewController viewController)
            : base(tableView)
        {
			tableView.RegisterNibForCellReuse(UINib.FromName(MenuViewCell.Key, NSBundle.MainBundle), MenuViewCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
				var entry = item as MenuItem;

				var castedCell = (MenuViewCell)tableView.DequeueReusableCell(MenuViewCell.Key, indexPath);
				if (castedCell.IconImage.Image == null)
				{
					castedCell.IconImage.Image = UIImage.FromFile(entry.IconPath);
				}
				if (entry.NotificationsCount == -1)
				{
					castedCell.CountLabel.Hidden = true;
				}
				else
				{
					var size = castedCell.CountLabel.Bounds.Size.Height;
					castedCell.CountLabel.Layer.CornerRadius = size / 2;
					castedCell.CountLabel.Layer.MasksToBounds = true;
					castedCell.CountLabel.ClipsToBounds = true;
					castedCell.CountLabel.Hidden = false;
					castedCell.CountLabel.Text = entry.NotificationsCount.ToString();
				}
				return castedCell;
		}
	}
}