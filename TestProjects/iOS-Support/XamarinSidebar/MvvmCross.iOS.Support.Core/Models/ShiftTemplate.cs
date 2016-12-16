using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models
{
    public partial class ShiftTemplate
    {
        public System.Guid Id { get; set; }
        public System.Guid EmployerId { get; set; }
        public System.Guid SkillId { get; set; }
        public System.Guid LocationId { get; set; }
        public System.Guid ManagerId { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public System.DateTime UtcStartDateTime { get; set; }
        public System.DateTime UtcEndDateTime { get; set; }
        public double Rate { get; set; }
        public int NumberOfPeopleNeeded { get; set; }
        public string MeetingLocation { get; set; }
        public string SpecialNotes { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
