using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthencationDemo.Model
{
    public class Auth
    {
        public int ServiceRequestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }
        public string EnquiryPurpose { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }



    }

    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class AuthUser
    {
        public static string UserId { get; set; }
        public static string EmailId { get; set; }
        public static string Name { get; set; }
        public static string Bearer_token { get; set; }
        public static string AuthUserId { get; set; }
        public static string ServerName { get; set; }
    }
}
