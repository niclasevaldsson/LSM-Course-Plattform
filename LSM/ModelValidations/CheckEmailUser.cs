using LSM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LSM.ModelValidations
{
    public class CheckEmailUser : ValidationAttribute
    {
        private ApplicationDbContext dbEmailCheck = new ApplicationDbContext();


        public override bool IsValid(object email)
        {
            string emailString = (string)email;
            var listOfUsersEmails = dbEmailCheck.Users.ToList();
            return listOfUsersEmails.Exists(item => item.Email == emailString);           
           
        }

      
    }
    
    


}