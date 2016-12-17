using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        #region private fields

        private int mNotificationsCount;

        private ICommand mMenuItemClickedCommand;

        public List<MenuItem> MenuItems { get; set; }

        #endregion

        public MenuViewModel() : base()
        {
            CalculateNotificationsCount();

            MenuItems = new List<MenuItem>
            {
                new MenuItem()
                {
                    IconPath = "Images/ic_nav_talent_pool",
                    Text = "Talent Pool",
                    ViewModelType = "TalentPoolViewModel" // nameof(TalentPoolViewModel)
                },
                new MenuItem()
                {
                    IconPath = "Images/ic_nav_templates",
                    Text = "Shift Templates",
                    ViewModelType = "ShiftTemplatesViewModel" // nameof(ShiftTemplatesViewModel)
                },
                 new MenuItem()
                {
                    IconPath = "Images/ic_nav_templates",
                    Text = "Menu View 1",
                    ViewModelType = "MenuViewModel1" // nameof(ShiftTemplatesViewModel)
                },
                  new MenuItem()
                {
                    IconPath = "Images/ic_nav_templates",
                    Text = "Menu View 1",
                    ViewModelType = "MenuViewModel2" // nameof(ShiftTemplatesViewModel)
                },
                   new MenuItem()
                {
                    IconPath = "Images/ic_nav_templates",
                    Text = "Menu View 2",
                    ViewModelType = "MenuViewModel3" // nameof(ShiftTemplatesViewModel)
                },
            };
        }

        public string EmployerName => "Crash User";

        public int NotificationsCount
        {
            get { return mNotificationsCount; }
            set
            {
                mNotificationsCount = value;
                RaisePropertyChanged(() => NotificationsCount);
            }
        }

        public void CalculateNotificationsCount()
        {
            NotificationsCount = 6;
        }

        #region private methods

        private void OnLogoutSuccess()
        {
        }

        #endregion

        public ICommand MenuItemClickedCommand
        {
            get
            {
                mMenuItemClickedCommand = mMenuItemClickedCommand ?? new MvxCommand<MenuItem>(MenuItemClickedAction);
                return mMenuItemClickedCommand;
            }
        }

        #region public methods

        public void GoToCreateShift()
        {
            ShowViewModel<CenterPanelViewModel>();
        }

        public void OnLogout()
        {
            OnLogoutSuccess();
        }

        public void ShowViewModel(Type viewModel, object navigationBundle = null)
        {
            base.ShowViewModel(viewModel, navigationBundle);
        }

        public void GoToShiftTemplate()
        {
            ShowViewModel(typeof(ShiftTemplatesViewModel));
        }

        #endregion

        #region private methods

        private void MenuItemClickedAction(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                return;
            }

            MvxTrace.Warning($"|||||||||||||||||||||||||||||||||Tapped on {menuItem.ViewModelType}||||||||||||||||||||||");
            switch (menuItem.ViewModelType)
            {
                case "TalentPoolViewModel": //nameof(TalentPoolViewModel):
                    //ShowViewModel<TalentPoolViewModel>();
                    break;

                case nameof(ShiftTemplatesViewModel):
                    ShowViewModel<ShiftTemplatesViewModel>();
                    break;
                case "ViewModel1": //nameof(TalentPoolViewModel):
                    //ShowViewModel<TalentPoolViewModel>();
                    break;
                case "ViewModel2": //nameof(TalentPoolViewModel):
                    //ShowViewModel<TalentPoolViewModel>();
                    break;
                case "ViewModel3": //nameof(TalentPoolViewModel):
                    //ShowViewModel<TalentPoolViewModel>();
                    break;
            }
        }

        #endregion
    }

    public class MenuItem
    {
        public string IconPath { get; set; }
        public string Text { get; set; }
        public int NotificationsCount { get; set; }
        public string ViewModelType { get; set; }

        public MenuItem()
        {
            NotificationsCount = -1;
        }
    }
}