using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LSM.ModelValidations;
using System.Linq;
using System.Web;

namespace LSM.Models
{
    public class Course
    {
        public int Id { get; set; }
        //public int Place { get; set; }              // This is the place, 0 means no place.
        [Required]       
        [StringLength(120, ErrorMessage = "Name must be between 2 and 120 characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DateGreaterEqualToToday(ErrorMessage = "Start date can't be earlier than today.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StopDate { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}