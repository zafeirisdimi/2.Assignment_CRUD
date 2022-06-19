using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models.Queries
{
    public class CourseFilterSettings
    {
        public string searchTitle { get; set; }
        public string searchCategory { get; set; }
        public int? searchDurationMin { get; set; }
        public int? searchDurationMax { get; set; }
    }
}