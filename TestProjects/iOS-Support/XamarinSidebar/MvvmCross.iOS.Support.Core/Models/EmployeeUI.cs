using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MvvmCross.iOS.Support.XamarinSidebarSample.Core.Models
{
    public class EmployeeUI : MvxViewModel
    {
        #region private members

        private string mName;
        protected bool mSelected;

        private const int MAXIMUM_SKILL_LIMIT = 2;

        private string mProfilePicture;
        private string mNationality;
        private string mVideoUrl;

        private int mThumbsUp;
        private int mThumbsDown;

        #endregion

        #region public Properties

        public Guid Id { get; set; }

        public string ProfilePicture
        {
            get { return mProfilePicture; }
            set
            {
                mProfilePicture = value;
                RaisePropertyChanged(() => ProfilePicture);
            }
        }

        public string Nationality
        {
            get { return mNationality; }
            set
            {
                mNationality = value;
                RaisePropertyChanged(() => Nationality);
            }
        }

        public string SkillSet
        {
            get
            {
                var skillSetStringBuilder = new StringBuilder();
                if (Skills == null || Skills.Count == 0)
                {
                    return "None set";
                }
                foreach (var skill in Skills.Take(MAXIMUM_SKILL_LIMIT))
                {
                    skillSetStringBuilder.Append($"{skill.Name}, ");
                }
                var skillSet = skillSetStringBuilder.ToString();
                return skillSet.Substring(0, skillSet.Length - 2);
            }
        }

        public string VideoUrl
        {
            get { return mVideoUrl; }
            set
            {
                mVideoUrl = value;
                RaisePropertyChanged(() => VideoUrl);
            }
        }

        public int ThumbsUp
        {
            get { return mThumbsUp; }
            set
            {
                mThumbsUp = value;
                RaisePropertyChanged(() => ThumbsUp);
            }
        }

        public int ThumbsDown
        {
            get { return mThumbsDown; }
            set
            {
                mThumbsDown = value;
                RaisePropertyChanged(() => ThumbsDown);
            }
        }

        public string Name
        {
            get { return mName; }
            set
            {
                mName = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public bool Selected
        {
            get { return mSelected; }
            set
            {
                mSelected = value;
                RaisePropertyChanged(() => Selected);
            }
        }

        public float Rating => 3.2f;

        public ICollection<Skill> Skills { get; set; }

        public ICollection<string> SkillsString { get; set; }

        public bool IsInTalentPool { get; set; }

        public Action<EmployeeUI> OfferShiftCallback { get; set; }

        #endregion
    }
}