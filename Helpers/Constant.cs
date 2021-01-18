using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Helpers
{
    public class Constant
    {
        public const string PASSWORD = "1q2w3e#";
        public const string JSONRESPONSE = "application/json";
        public static class UploadPath
        {
            public const string AVATARS = "avatars\\";
            public const string PROFILES = "profiles/";
            public const string FORMS = "forms/";
            public const string FILES = "../files/";
            // public const string CONNECTIONSTRING = "Data Source=DESKTOP-CLHUG8O;Initial Catalog=TMT_HR_NEW;Integrated Security=True";
        }

        public static class HTTPMethods
        {
            public const string GET = "GET";
            public const string POST = "POST";
            public const string PUT = "PUT";
            public const string DELETE = "DELETE";
        }
        public static class CustomClaims
        {
          
            public const string ROLE = "Role";
            public const string EMAIL = "Email";
            public const string USERNAME = "UserName";
            public const string USERID = "USERID";
        }
        public static Dictionary<int, string> FormType = new Dictionary<int, string>
        {
            {1,"Test1" },
            {2,"Test2" }
        };
        public static List<string> RELATEDPROPERTIES = new List<string>
        {
            "Departments",
            "Employees",
            "BlogTags",
            "Employee",
            "ChildComments",
            "Comments",
            "Tags",
            "Blogs",
            "Roles",
            "RefreshTokens",
            "PositionHistories",
            "RequestApprovals",
            "ShiftWork",
            "Department",
            "Role"
        };

        public static class ProfileMail
        {
            public const string SENDERNAME = "F And F";
            public const string SENDEROFMAIL = "tinhnguyenleader@gmail.com";
            public const string SENDERPW = "tinh123456";
            public const string SUBJECT = "Reset Your Password";
            public const string URLIMAGELOGO = @"Images\logo.png";
            public const string HOSTEMAIL = "smtp.gmail.com";
            public const int PORTEMAIL = 587;
        }


        public static class RolePolicy
        {
            public const string NHANVIEN = "NHANVIEN";
            public const string CANBO = "CANBO";
            public const string NGUOIDUNG = "NGUOIDUNG";
        }
       

    }
}

