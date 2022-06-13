using Assignment2.Models;
using Assignment2.MyContext;
using System;
using System.Collections.Generic;
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

        public  Trainer GetById(int? id)
        {
            var trainer = db.Trainers.Find(id);
            return trainer;
        }

        
    }
}