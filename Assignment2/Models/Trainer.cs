using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Assignment2.Models.Enum;

namespace Assignment2.Models
{
    public class Trainer
    {
        [Key]//model validations
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName Required")]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [MaxLength(60)]
        [MinLength(7)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [MaxLength(20)]
        [MinLength(10)]
        public string Phone { get; set; }

        [Range(1000,30000)]
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public string PhotoUrl { get; set; }

        public Country Country { get; set; }


        //foreign key
        public int StudentId { get; set; }
        //navigation properties
        public Student Student { get; set; }
    }
}