using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models
{
    public class ShiftTemplateUI : MvxViewModel
    {
        #region private members

        public ShiftTemplateUI() { }
        #endregion
        public ShiftTemplateUI(ShiftTemplate shiftTemplate)
        {
            InitializeMembers(shiftTemplate);
        }

        public System.Guid Id { get; set; }
        public System.Guid EmployerId { get; set; }
        public System.Guid SkillId { get; set; }
        public System.Guid LocationId { get; set; }
        public System.Guid ManagerId { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public double Rate { get; set; }
        public int NumberOfPeopleNeeded { get; set; }
        public string MeetingLocation { get; set; }
        public string SpecialNotes { get; set; }

        public Skill Skill { get; set; }

        public string ShiftTime => $"{StartDateTime.DayOfWeek}, {StartDateTime.Day} {CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(StartDateTime.Month)} {StartDateTime.ToString("HH:mm")} - {EndDateTime.ToString("HH:mm")}";


        #region private methods

        private void InitializeMembers(ShiftTemplate shiftTemplate)
        {
            StartDateTime = shiftTemplate.StartDateTime;
            EndDateTime = shiftTemplate.EndDateTime;

            Id = shiftTemplate.Id;
            EmployerId = shiftTemplate.EmployerId;
            SkillId = shiftTemplate.SkillId;
            LocationId = shiftTemplate.LocationId;
            ManagerId = shiftTemplate.ManagerId;

            Rate = shiftTemplate.Rate;
            NumberOfPeopleNeeded = shiftTemplate.NumberOfPeopleNeeded;
            MeetingLocation = shiftTemplate.MeetingLocation;
            SpecialNotes = shiftTemplate.SpecialNotes;
            Skill = shiftTemplate.Skill;
        }

        #endregion
    }
}
