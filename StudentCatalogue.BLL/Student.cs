using sun.security.util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalogue.BLL
{
    public class Student
    {
        [Required]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PckMoney { get; set; }

       [Required]
        public string Password { get; set; }

        public string Age { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
