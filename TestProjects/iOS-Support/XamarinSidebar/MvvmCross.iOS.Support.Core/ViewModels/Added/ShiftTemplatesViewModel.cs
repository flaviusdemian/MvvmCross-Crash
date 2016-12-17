using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models;
using MvvmCross.iOS.Support.XamarinSidebarSample.Core.Network;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.ViewModels
{
    public class ShiftTemplatesViewModel : BaseViewModel
    {
		#region private methods

		private ObservableCollection<ShiftTemplateUI> mShiftTemplates = new ObservableCollection<ShiftTemplateUI>();

        #endregion

        public ObservableCollection<ShiftTemplateUI> ShiftTemplates
        {
            set
            {
                mShiftTemplates = value;
                RaisePropertyChanged(() => ShiftTemplates);
                RaisePropertyChanged(() => ShiftTemplatesCount);
            }
            get { return mShiftTemplates; }
        }

        public int ShiftTemplatesCount
        {
            get
            {
                if (ShiftTemplates == null)
                {
                    return 0;
                }

                return ShiftTemplates.Count;
            }
        }

        #region public methods

        public void GetShiftTemplates()
        {
			Task.Run(() => GetShiftTemplatesAsync().ConfigureAwait(false)).ConfigureAwait(false);
        }

        public void GoToHomeScreen()
        {
            ShowViewModel<CenterPanelViewModel>();
        }

        #endregion

        #region private methods

        private async Task GetShiftTemplatesAsync()
        {
            var response = await CallGetTemplates(Constants.EMPLOYER_ID);
            var resultUiTemplates = response.Data.Select(shift => new ShiftTemplateUI(shift)).ToList();

            RequestMainThreadAction(() =>
            {
                //if (ShiftTemplates == null)
                //{
                //    ShiftTemplates = new ObservableCollection<ShiftTemplateUI>(resultUiTemplates);
                //}
                //else
                //{
                    ShiftTemplates.Clear();
                    foreach (var item in resultUiTemplates)
                    {
                        ShiftTemplates.Add(item);
                    }
                //}
            });
        }

        private async Task<Response<List<ShiftTemplate>>> CallGetTemplates(string employerId)
        {
            var parameters = new Dictionary<string, string>
            {
                {
                    "employerId", employerId
                }
            };

            return await HttpClientManager.ExecuteGetAsync<List<ShiftTemplate>>("ShiftTemplate/GetTemplates", parameters).ConfigureAwait(false);
        }

        #endregion
    }
}
