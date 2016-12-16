using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models
{
    public class Employee
    {
        public System.Guid Id { get; set; }
        public string AspNetUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime Birthday { get; set; }
        public string CurrentAddressName { get; set; }
        public string Nationality { get; set; }
        public bool RequireWorkingVisa { get; set; }
        public string PPSNumber { get; set; }
        public int ThumbsUp { get; set; }
        public int ThumbsDown { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public double ProfileCompleteness { get; set; }
        public long Number { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public bool IsInTalentPool { get; set; }
    }
}
