using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required,MinLength(2),MaxLength(42)]
        public string Title { get; set; }

        [Range(30,360)]
        public int Duration { get; set; }

        public Course()
        {
            Trainers = new HashSet<Trainer>();
        }

        //Navigation Properties
        public ICollection<Trainer> Trainers { get; set; }
    }
}