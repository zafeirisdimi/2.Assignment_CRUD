using Assignment2.Models;
using Assignment2.Models.Queries;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2.Repository
{
    public class TrainerRepository
    {
        ApplicationContext db;
        public TrainerRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }

        public List<Trainer> GetAllWithStudent()
        {
            return db.Trainers.Include(s => s.Student).ToList() ;
        }

        public List<Trainer> GetAllWithStudentAndCourses()
        {
            return db.Trainers.Include(s => s.Student).Include(x=>x.Courses).ToList();
        }


        public Trainer GetById(int? id)
        {
            var trainer = db.Trainers.Find(id);
            return trainer;
        }

        public void Delete(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Deleted;  //set the state of this entity in deleted state
            db.SaveChanges();
        }

        public void Add(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Trainer train,List<int> coursesIds)
        {
            //step 1) asked from database, do you have this trainer with this.id?
            //and the tables with trainers included needed
            var trainer = db.Trainers.
                Include(x=>x.Student).
                Include(x=>x.Courses).
                FirstOrDefault(x=>x.Id == train.Id);
            if(trainer == null)
            {
                throw new ArgumentNullException();
            }
            if (train == null)
            {
                throw new ArgumentNullException();
            }

            //step 1b) Data Mapping
            trainer.FirstName = train.FirstName;
            trainer.LastName = train.LastName;
            trainer.Courses = train.Courses;
            trainer.Email = train.Email;
            trainer.HireDate = train.HireDate;
            trainer.Country = train.Country;
            trainer.Salary = train.Salary;
            trainer.Phone = train.Phone;
            trainer.Student = train.Student;

            //step 2) Clean the old table of trainers
            trainer.Courses.Clear();
            db.SaveChanges();

            //step 3) Clean the old table of trainers
            if (coursesIds != null)
            {
                foreach (var id in coursesIds)
                {
                    var course = db.Courses.Find(id);
                    if (course != null)
                    {
                        trainer.Courses.Add(course);
                    }
                }
            }
      
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }
        

        //-----filtering-----
        public List<Trainer> Filter (TrainerFilterSettings filterSettings, out (decimal minSalary, decimal maxSalary) trainerSalaryRange)
        {
            List<Trainer> trainers = GetAllWithStudent();


            decimal minSalary = trainers.Min(t => t.Salary);
            decimal maxSalary = trainers.Max(t => t.Salary);
            trainerSalaryRange = (minSalary, maxSalary);
           
            //searchName
            if (!string.IsNullOrWhiteSpace(filterSettings.searchFirstName)) //null or "    " or ""
            {
                //trainers = trainers.Where(t => t.FirstName.ToUpper() == searchName.ToUpper()).ToList();
                trainers = trainers.Where(t => t.FirstName.ToUpper().Contains(filterSettings.searchFirstName.ToUpper())).ToList();
            }

            //searchCountry
            if (!string.IsNullOrWhiteSpace(filterSettings.searchCountry))
            {
                trainers = trainers.Where(x => x.Country.ToString() == filterSettings.searchCountry).ToList();
            }

            //searchSalaryMin
            if (!(filterSettings.searchSalaryMin is null))
            {
                trainers = trainers.Where(t => t.Salary >= filterSettings.searchSalaryMin).ToList();
            }

            //searchSalaryMax
            if (!(filterSettings.searchSalaryMax is null))
            {
                trainers = trainers.Where(t => t.Salary <= filterSettings.searchSalaryMax).ToList();
            }


            return trainers;
        }
            
    }
}