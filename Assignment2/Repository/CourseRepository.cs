using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Repository
{
    public class CourseRepository
    {
        ApplicationContext db;

        public CourseRepository(ApplicationContext context)
        {
            db = context;   
        }
        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }
    }
}