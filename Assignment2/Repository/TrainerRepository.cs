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

        public void Edit(Trainer trainer)
        {

            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }
        

        //-----filtering-----
        public void Filter (List<Trainer> trainers, TrainerSearchQuery query)
        {

            //searchName
            if (!string.IsNullOrWhiteSpace(query.searchFirstName)) //null or "    " or ""
            {
                //trainers = trainers.Where(t => t.FirstName.ToUpper() == searchName.ToUpper()).ToList();
                trainers = trainers.Where(t => t.FirstName.ToUpper().Contains(query.searchFirstName.ToUpper())).ToList();
            }

            //searchCountry
            if (!string.IsNullOrWhiteSpace(query.searchCountry))
            {
                trainers = trainers.Where(x => x.Country.ToString() == query.searchCountry).ToList();
            }

            //searchSalaryMin
            if (!(query.searchSalaryMin is null))
            {
                trainers = trainers.Where(t => t.Salary >= query.searchSalaryMin).ToList();
            }

            //searchSalaryMax
            if (!(query.searchSalaryMax is null))
            {
                trainers = trainers.Where(t => t.Salary <= query.searchSalaryMax).ToList();
            }



        }
            
    }
}