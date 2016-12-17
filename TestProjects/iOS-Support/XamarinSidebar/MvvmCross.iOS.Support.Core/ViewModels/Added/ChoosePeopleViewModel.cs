using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Network;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels
{
    public class ChoosePeopleViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeUI> mEmployeesUi;
        private List<Employee> mBackendEmployees;

        private bool mAreAllPeopleSelected;
        private DateTime mLocalStartDateTime = DateTime.Now.AddDays(1);
        private DateTime mLocalEndDateTime = DateTime.Now.AddDays(1).AddHours(2);
        private int mNumberOfPeopleNeeded;

        private int mAvailablePeopleCount;
        private Action mOnUpdateTextAction;

        private ICommand mItemTappedCommand;
        private ICommand mItemSelectedCommand;
        private ICommand mCreateShiftCommand;
        private ICommand mSelectAllAvailableCommand;

        public const string DATETIME_PARSE_FORMAT = "MM/dd/yyyy HH:mm";

        public ChoosePeopleViewModel()
        {
            WasViewModelInitialized = false;
        }

        #region Properties

        public ObservableCollection<EmployeeUI> Employees
        {
            get { return mEmployeesUi; }
            set
            {
                mEmployeesUi = value;
                RaisePropertyChanged(() => Employees);
            }
        }

        public int AvailablePeopleCount
        {
            get { return mAvailablePeopleCount; }
            set
            {
                mAvailablePeopleCount = value;
                RaisePropertyChanged(() => AvailablePeopleCount);
            }
        }

        public string SelectedPeopleCountDisplay
        {
            get
            {
                if (Employees == null)
                {
                    return string.Empty;
                }

                var selectPeopleCount = Employees.Where(employee => employee.Selected).ToList().Count;

                return $"Selected {selectPeopleCount} /{mNumberOfPeopleNeeded}";
            }
        }

        public bool AreAllPeopleSelected
        {
            get
            {
                mAreAllPeopleSelected = Employees?.All(employee => employee.Selected) ?? false;
                return mAreAllPeopleSelected;
            }
            set
            {
                mAreAllPeopleSelected = value;
                ToggleAllAvailableAction();
            }
        }

        public bool AreEnoughPeopleSelected
        {
            get
            {
                if (Employees == null)
                {
                    return false;
                }

                return mNumberOfPeopleNeeded == Employees.Count(employee => employee.Selected) ||
                    AreAllPeopleSelected;
            }
        }

        public bool ShowOfferShiftButton => AreEnoughPeopleSelected;

        public bool ShowReadvertiseShiftButton => AreEnoughPeopleSelected;

        public bool WasViewModelInitialized { get; set; }

        #endregion

        #region commands

        public ICommand CreateShiftCommand
        {
            get
            {
                mCreateShiftCommand = mCreateShiftCommand ?? new MvxCommand(CreateShiftAction);
                return mCreateShiftCommand;
            }
        }

        public ICommand ItemSelectedCommand
        {
            get
            {
                mItemSelectedCommand = mItemSelectedCommand ?? new MvxCommand<EmployeeUI>(ItemSelectedAction);
                return mItemSelectedCommand;
            }
        }

        public ICommand SelectAllAvailableCommand
        {
            get
            {
                mSelectAllAvailableCommand = mSelectAllAvailableCommand ?? new MvxCommand(ToggleAllAvailableAction);
                return mSelectAllAvailableCommand;
            }
        }

        #endregion

        #region public methods

        public void GetAvailablePeople()
        {
            Task.Run(async () => await GetPeopleAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }

        public void SetOnTextUpdateAction(Action onUpdateTextAction)
        {
            mOnUpdateTextAction = onUpdateTextAction;
        }

        public void GoToHomeScreen()
        {
            ShowViewModel<CenterPanelViewModel>();
            Close(this);
        }

        #endregion

        #region private methods

        private void GoToShiftSummary()
        {
            //ShowViewModel<ShiftSummaryViewModel>();
        }

        private void ToggleAllAvailableAction()
        {
            if (AreAllPeopleSelected)
            {
                SelectNobodyAction();
            }
            else
            {
                SelectAllAction();
            }

            RefreshUi();
            mOnUpdateTextAction();
        }

        private void SelectAllAction()
        {
            foreach (var employee in Employees)
            {
                employee.Selected = true;
            }
        }

        private void SelectNobodyAction()
        {
            foreach (var employee in Employees)
            {
                employee.Selected = false;
            }
        }

        private void ItemSelectedAction(EmployeeUI employeeUi)
        {
            if (!WasViewModelInitialized)
            {
                return;
            }

            if (employeeUi == null)
            {
                return;
            }

            RefreshUi();
            mOnUpdateTextAction();
        }

        private async Task GetPeopleAsync()
        {
            try
            {
                var response = await ChoosePeople(
                    "A00C0B20-A1E4-42C9-8157-1AE27AFA02F2",
                    "9EDFCF04-06AC-44DF-A3A9-A6327D646A24",
                    "CFE13495-8DC3-43F1-A4DA-3A78E169B03A",
                    mLocalStartDateTime, mLocalEndDateTime);

                mBackendEmployees = response.Data.OrderBy(ee => !ee.IsInTalentPool).ToList();
                var employeesUi = new ObservableCollection<EmployeeUI>(ConvertToEmployeesUi(mBackendEmployees, ItemSelectedAction));

                RequestMainThreadAction(() =>
                {
                    Employees = employeesUi;
                    AvailablePeopleCount = Employees.Count;
                });

                RefreshUi();

                WasViewModelInitialized = true;
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.ToString);
            }
        }

        private async Task<Response<List<Employee>>> ChoosePeople(string skillId, string employerId,
            string areaId, DateTime localStartDateTime, DateTime localEndDateTime)
        {
            var parameters = new Dictionary<string, string>
            {
                {"skillId", skillId},
                {"employerId", employerId},
                {"areaId", areaId},
                {"localStartDateTime", localStartDateTime.ToString(DATETIME_PARSE_FORMAT, CultureInfo.InvariantCulture)},
                {"localEndDateTime", localEndDateTime.ToString(DATETIME_PARSE_FORMAT, CultureInfo.InvariantCulture)}
            };

            return await HttpClientManager.ExecuteGetAsync<List<Employee>>(
                "Shift/ChoosePeople",parameters).ConfigureAwait(false);
        }

        private void CreateShiftAction()
        {
            GoToShiftSummary();
        }

        #endregion

        public void RefreshUi()
        {
            RequestMainThreadAction(() =>
            {
                RaisePropertyChanged(() => AreAllPeopleSelected);
                RaisePropertyChanged(() => AreEnoughPeopleSelected);
                RaisePropertyChanged(() => SelectedPeopleCountDisplay);
                RaisePropertyChanged(() => ShowOfferShiftButton);
                RaisePropertyChanged(() => ShowReadvertiseShiftButton);
            });
        }

        public List<EmployeeUI> ConvertToEmployeesUi(List<Employee> employeeList, Action<EmployeeUI> offerShiftCallback)
        {
            var employeeUIs = new List<EmployeeUI>();
            if (employeeList == null)
            {
                return employeeUIs;
            }

            foreach (var employee in employeeList)
            {
                var employeeUi = new EmployeeUI
                {
                    Id = employee.Id,
                    Name = $"{employee.FirstName} {employee.LastName}",
                    ProfilePicture = employee.ProfilePictureUrl,
                    Skills = employee.Skills,
                    SkillsString = employee.Skills.Select(skill => skill.Name).ToList(),
                    Selected = false,
                    IsInTalentPool = employee.IsInTalentPool,
                    VideoUrl = employee.VideoUrl,
                    ThumbsUp = employee.ThumbsUp,
                    ThumbsDown = employee.ThumbsDown,
                    Nationality = employee.Nationality,
                    OfferShiftCallback = offerShiftCallback
                };
                employeeUIs.Add(employeeUi);
            }
            return employeeUIs;
        }
    }
}