using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment2.Models;
using System.Data.Entity.Migrations;

namespace Assignment2.MyContext.Initializers
{
    public class MockupDBInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {


        protected override void Seed(ApplicationContext context) // the control Of Seed be taken from this class now,instead of Migrations/Configuration.cs
        {

            #region Seeding Trainer data


            Trainer t1 = new Trainer() { FirstName = "Dimitris", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 1200};
            Trainer t2 = new Trainer() { FirstName = "Christos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200};
            Trainer t3 = new Trainer() { FirstName = "Katerina", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200};
            Trainer t4 = new Trainer() { FirstName = "Maria", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1200};
            Trainer t5 = new Trainer() { FirstName = "Kiriaki", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200};
            context.Trainers.AddOrUpdate(t => t.FirstName, t1, t2, t3, t4, t5);
            context.SaveChanges();
            #endregion


            base.Seed(context);
        }
    }
}