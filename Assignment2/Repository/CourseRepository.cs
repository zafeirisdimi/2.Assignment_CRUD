using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment2.Models.Queries;

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
        public List<Course> GetAllWithTrainers()
        {

            return db.Courses.Include(c => c.Trainers).ToList();
        }
        public Course GetById(int? id)
        {
            var course = db.Courses.
                Include(x => x.Trainers).
                FirstOrDefault(x => x.Id == id);
            return course;
        }
        public void Delete(Course course)
        {
            db.Entry(course).State = EntityState.Deleted;  //set the state of this entity in deleted state
            db.SaveChanges();
        }
        public void Add(Course course)
        {
            db.Entry(course).State = EntityState.Added;
            db.SaveChanges();
        }
        public List<Course> Filter(CourseFilterSettings filterSettings, out (int minDuration, int maxDuration) courseDurationRange)
        {
            List<Course> courses = GetAllWithTrainers();


            int minDuration = courses.Min(t => t.Duration);
            int maxDuration = courses.Max(t => t.Duration);
            courseDurationRange = (minDuration, maxDuration);

            //searchName
            if (!string.IsNullOrWhiteSpace(filterSettings.searchTitle)) //null or "    " or ""
            {
                //courses = courses.Where(t => t.FirstName.ToUpper() == searchName.ToUpper()).ToList();
                courses = courses.Where(t => t.Title.ToUpper().Contains(filterSettings.searchTitle.ToUpper())).ToList();
            }

            //searchCountry
            if (!string.IsNullOrWhiteSpace(filterSettings.searchCategory))
            {
                courses = courses.Where(x => x.Category.ToString() == filterSettings.searchCategory).ToList();
            }

            //searchSalaryMin
            if (!(filterSettings.searchDurationMin is null))
            {
                courses = courses.Where(c => c.Duration >= filterSettings.searchDurationMin).ToList();
            }

            //searchSalaryMax
            if (!(filterSettings.searchDurationMax is null))
            {
                courses = courses.Where(c => c.Duration <= filterSettings.searchDurationMax).ToList();
            }

            return courses;
        }
        public void Edit(Course cors, List<int> trainersIds)
        {
            if (cors == null)
            {
                throw new ArgumentNullException("Error, this course is not coming");
            }
            //step 1) asked from database, do you have this course with this.id?
            //and the tables with trainers included needed
            var course = db.Courses.//attached mode
                Include(x => x.Trainers).
                FirstOrDefault(x => x.Id == cors.Id);

            //check the course and cors is not null
            if (course == null)
            {
                throw new ArgumentNullException("Error, it is not found course");
            }


            //you have employee and emp for sure!!!
            //step 1b) Data Mapping
            course.Title = cors.Title;
            course.Duration = cors.Duration;
            course.Category = cors.Category;
            course.StartDate = cors.StartDate;
            course.EndDate = cors.EndDate;
            


            //step 2) Clean the old table of trainers
            course.Trainers.Clear();
            db.SaveChanges();

            //step 3) Clean the old table of trainers
            if (trainersIds != null)
            {
                foreach (var id in trainersIds)
                {
                    var trainer = db.Trainers.Find(id);
                    if (trainer != null)
                    {
                        course.Trainers.Add(trainer);
                    }
                }
            }

            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}