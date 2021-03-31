using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJCSC.App.UI.poc.DTO
{
    public class EmploymentApplicatonDTO
    {
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
