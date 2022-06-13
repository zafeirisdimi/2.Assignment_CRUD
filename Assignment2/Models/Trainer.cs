using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName Required")]
        [StringLength(30, MinimumLength = 5,ErrorMessage = "Validation Problem in FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Validation Problem in LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Validation Problem in Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Validation Problem in Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Salary Required")]
        [Range(1000,2000)]
        public int Salary { get; set; }
        public DateTime HireDate { get; set; }

        public string PhotoUrl { get; set; }



    }
}