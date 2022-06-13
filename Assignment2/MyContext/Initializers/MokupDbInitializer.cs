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

            Trainer t1 = new Trainer() { FirstName = "Dimitris", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 1200, HireDate= new DateTime(2022,01,03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Trainer t2 = new Trainer() { FirstName = "Christos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Trainer t3 = new Trainer() { FirstName = "Katerina", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,05) ,PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Trainer t4 = new Trainer() { FirstName = "Maria", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,07,03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            Trainer t5 = new Trainer() { FirstName = "Kiriaki", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" };
            context.Trainers.AddOrUpdate(t => t.FirstName, t1, t2, t3, t4, t5);
            context.SaveChanges();
            #endregion


            base.Seed(context);
        }
    }
}