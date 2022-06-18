using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Assignment2.Models.Queries;

namespace Assignment2.Repository
{
    public class StudentRepository
    {
        ApplicationContext db;

        public StudentRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public List<Student> GetAllWithTrainers()
        {
            return db.Students.Include(s => s.Trainers).ToList();
        }

        public Student GetById(int? id)
        {
            var student = db.Students.Find(id);
            return student;
        }
        public Student GetByIdWithTrainers(int? id)
        {
            var student = GetAllWithTrainers().Find(s => s.Id == id);
            return student;
        }

        public void Delete(Student student)
        {
            db.Entry(student).State = EntityState.Deleted;  //set the state of this entity in deleted state
            db.SaveChanges();
        }

        public void Add(Student student)
        {
            db.Entry(student).State = EntityState.Added; //set the state of this entity in added state
            db.SaveChanges();
        }

        public void Edit(Student student)
        {
            db.Entry(student).State = EntityState.Added;
            db.SaveChanges();
        }
        public List<Student> Filter(StudentFilterSettings filterSettings, out (int minSalary, int maxSalary) studentSalaryRange)
        {
            List<Student> students = GetAllWithTrainers();


            int minSalary = students.Min(t => t.Salary);
            int maxSalary = students.Max(t => t.Salary);
            studentSalaryRange = (minSalary, maxSalary);

            //searchName
            if (!string.IsNullOrWhiteSpace(filterSettings.searchFirstName)) //null or "    " or ""
            {
                //trainers = trainers.Where(t => t.FirstName.ToUpper() == searchName.ToUpper()).ToList();
                students = students.Where(t => t.FirstName.ToUpper().Contains(filterSettings.searchFirstName.ToUpper())).ToList();
            }

            //searchCountry
            if (!string.IsNullOrWhiteSpace(filterSettings.searchCountry))
            {
                students = students.Where(x => x.Country.ToString() == filterSettings.searchCountry).ToList();
            }

            //searchSalaryMin
            if (!(filterSettings.searchSalaryMin is null))
            {
                students = students.Where(t => t.Salary >= filterSettings.searchSalaryMin).ToList();
            }

            //searchSalaryMax
            if (!(filterSettings.searchSalaryMax is null))
            {
                students = students.Where(t => t.Salary <= filterSettings.searchSalaryMax).ToList();
            }


            return students;
        }
    }
}