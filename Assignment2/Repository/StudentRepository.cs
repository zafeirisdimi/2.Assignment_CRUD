using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
    }
}