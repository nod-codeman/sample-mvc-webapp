using System;
using System.ComponentModel.DataAnnotations;

namespace FirstEFSampleApp.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City  { get; set; }

        [StringLength(maximumLength: 2)]
        public string State { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

    }
}
