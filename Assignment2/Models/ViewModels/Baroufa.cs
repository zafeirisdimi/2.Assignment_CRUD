using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models.ViewModels
{
    public class Baroufa
    {
        public string Title { get; set; }
        public List<Student> Students { get; set; }
        public List<Trainer> Trainers { get; set; }
        public int StudentsCount { get; set; }
        public int TrainersCount { get; set; }
    }
}