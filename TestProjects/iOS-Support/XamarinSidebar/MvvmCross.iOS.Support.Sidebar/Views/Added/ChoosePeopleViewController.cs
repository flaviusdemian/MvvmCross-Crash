using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Cells;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "MainStoryboard")]
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ActivePanel, true)]
    public partial class ChoosePeopleViewController : BaseMvxViewController<ChoosePeopleViewModel>
    {
        private static string SELECT_ALL_PEOPLE_TEXT = "Select all";
        private static string DESELECT_ALL_PEOPLE_TEXT = "Deselect all";

        public ChoosePeopleViewController()
        {
        }

        public ChoosePeopleViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            RemoveTableViewSeparator(tv_choose_people1);

            var source = new ChoosePeopleTableSource(tv_choose_people1);
            tv_choose_people1.Source = source;

            var bindingSet = this.CreateBindingSet<ChoosePeopleViewController, ChoosePeopleViewModel>();
            bindingSet.Bind(l_choose_people_available).To(vm => vm.AvailablePeopleCount).WithConversion("AvailablePeople");
            bindingSet.Bind(source).To(vm => vm.Employees);
            bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
            bindingSet.Bind(btn_choose_people_continue).To(vm => vm.CreateShiftCommand);
            bindingSet.Bind(btn_choose_people_all).To(vm => vm.SelectAllAvailableCommand);
            bindingSet.Bind(l_choose_people_selected).To(vm => vm.SelectedPeopleCountDisplay);
            bindingSet.Bind(btn_choose_people_continue).For(Constants.VISIBILITY).To(vm => vm.AreEnoughPeopleSelected)
                .WithConversion(Constants.VISIBILITY);

            bindingSet.Apply();

            tv_choose_people1.ReloadData();

            NavigationItem?.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Cancel, CancelCreateShift), true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel?.GetAvailablePeople();
            ViewModel?.SetOnTextUpdateAction(OnUpdateSwitchText);

            OnUpdateSwitchText();
        }

        #region private methods

        private void CancelCreateShift(object sender, EventArgs e)
        {
            ViewModel.GoToHomeScreen();
        }

        private void OnUpdateSwitchText()
        {
            if (ViewModel.AreEnoughPeopleSelected)
            {
                l_choose_people_selected.TextColor = UIColor.Black;
            }
            else
            {
                l_choose_people_selected.TextColor = UIColor.Red;
            }

            if (ViewModel.AreAllPeopleSelected)
            {
                btn_choose_people_all.SetTitle(DESELECT_ALL_PEOPLE_TEXT, UIControlState.Normal);
                return;
            }
            btn_choose_people_all.SetTitle(SELECT_ALL_PEOPLE_TEXT, UIControlState.Normal);
        }

        #endregion

    }

    public class ChoosePeopleTableSource : MvxTableViewSource
    {
        public ChoosePeopleTableSource(UITableView tableView) : base(tableView)
        {
            tableView.RegisterNibForCellReuse(UINib.FromName(ChoosePeopleTableViewCell.Key, NSBundle.MainBundle), ChoosePeopleTableViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var castedCell = (ChoosePeopleTableViewCell)tableView.DequeueReusableCell(ChoosePeopleTableViewCell.Key, indexPath);

            return castedCell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return ChoosePeopleTableViewCell.GetCellHeight();
        }
    }
}