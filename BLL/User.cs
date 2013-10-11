using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace X3Store.BLL
{
    public class User : BusinessLogicObject
    {
        private readonly MembershipUser _user;
        private readonly ProfileBase _profile;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastLockoutDate { get; set; }
        public DateTime LastPasswordChangedDate { get; set; }
        
        public bool IsEmperor { get; set; }
        public bool IsVassal { get; set; }

        public User() : this(string.Empty) {}

        public User(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                _user = Membership.GetUser();
                _profile = HttpContext.Current.Profile;
            }
            else
            {
                _user = Membership.GetUser(userName);
                _profile = ProfileBase.Create(userName);                
            }

            FillUserData();
        }

        private void FillUserData()
        {
            Name = _profile.UserName;
            IsAuthenticated = !_profile.IsAnonymous;
            LastActivityDate = _profile.LastActivityDate;
            LastUpdateDate = _profile.LastUpdatedDate;

            if (_user == null)
                return;

            Name = _user.UserName;
            Email = _user.Email;
            Comment = _user.Comment;
        }

        public string ChangePassword(string currentPassword)
        {
            return string.Empty;
        }

        public string ResetPassword()
        {
            return string.Empty;
        }

        public void UnlockUser()
        {
            
        }

        public void Update()
        {
            
        }

        public DataTable GetDataTable()
        {
            var userData = new DataTable("UserData");
            userData.Columns.Add("Item");
            userData.Columns.Add("Name");
            userData.Columns.Add("Value");

            userData.AddUserData("Имя", "Name", Name);
            userData.AddUserData("E-mail", "Email", Email);
            userData.AddUserData("Зарегистрирован", "Authenticated", IsAuthenticated.ToString());

            return userData;
        }
    }
}
