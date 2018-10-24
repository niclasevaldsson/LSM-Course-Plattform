using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LSM.ModelValidations
{
    public class DateGreaterEqualToToday : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime dateAsDateTime = (DateTime)date;
            return dateAsDateTime > DateTime.Now;
        }
    }

}