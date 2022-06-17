using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models.Queries
{
    public class TrainerFilterSettings
    {
        public string searchFirstName { get; set; }
        public string searchCountry { get; set; }
        public decimal? searchSalaryMin { get; set; }
        public decimal? searchSalaryMax { get; set; }
    }
}