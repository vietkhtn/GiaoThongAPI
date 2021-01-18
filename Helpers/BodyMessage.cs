using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace HR.Helpers
{
    public class BodyMessage
    {
        public static string MessBodyEmail(User employee,string newPassword)
        {
            var mess = "<p style='margin-bottom:80px'>Hi " + employee.CitizenShipProfile.FirstName+" "+employee.CitizenShipProfile.LastName + ".<br>We send you a new password as per your request. <br>Please do not disclose your password to anyone. <br>Your new password is: " + newPassword + @"</p> <hr> <h3>Liên lệ với chúng tôi</h3> <h4>SDT:0123456789</h4><h4>Email: tinh121999g@gmail.com</h4> <img src=""cid:{0}""> ";
            return mess;
        }
     
     
    }
}

