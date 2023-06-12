using Common.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modles.UserDetails
{
    public class UserLogin : CommonClass
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string SAP_Id { get; set; }
        public string Password { get; set; }
        public string LastLoginDate { get; set; }
        public Int32 User_Type { get; set; }
        public string User_FName { get; set; }
        public string User_MName { get; set; }
        public string User_LName { get; set; }
        public string User_Gender { get; set; }
        public string User_DOB { get; set; }
        public string User_BloodGroup { get; set; }
        public string User_Religion { get; set; }
        public string User_Cast { get; set; }
        public string User_Citizenship { get; set; }
        public string User_PrimaryEmail { get; set; }
        public string User_PrimaryMobile { get; set; }
        public string User_MaritalStatus { get; set; }
        public int Is_AthorizedForLogin { get; set; }
	}
}
