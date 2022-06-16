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
            Student s1 = new Student() { FirstName = "Manolis", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Student s2 = new Student() { FirstName = "Kiriakos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Student s3 = new Student() { FirstName = "Maria", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Student s4 = new Student() { FirstName = "Danai", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            Student s5 = new Student() { FirstName = "Persefoni", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" };
            Student s6 = new Student() { FirstName = "Kirio", LastName = "Lemon", Email = "Lemon@gmail.com", Phone = "6978970056", Salary = 1500, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Student s7 = new Student() { FirstName = "Marianna", LastName = "Kara", Email = "Kara@gmail.com", Phone = "6974246606", Salary = 1700, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Student s8 = new Student() { FirstName = "Dimitra", LastName = "Mitropoulou", Email = "Mitropoulou@gmail.com", Phone = "6978976606", Salary = 2000, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            Student s9 = new Student() { FirstName = "Persa", LastName = "Petropoulou", Email = "P.Petropoulou@gmail.com", Phone = "6978236606", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" };
            context.Students.AddOrUpdate(s => s.FirstName, s1, s2, s3, s4, s5, s6);
            context.SaveChanges();

            Trainer t1 = new Trainer() { FirstName = "Dimitris", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 2000, HireDate= new DateTime(2022,01,03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Trainer t2 = new Trainer() { FirstName = "Christos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Trainer t3 = new Trainer() { FirstName = "Katerina", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,05) ,PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Trainer t4 = new Trainer() { FirstName = "Maria", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1750, HireDate = new DateTime(2022,07,03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            Trainer t5 = new Trainer() { FirstName = "Kiriaki", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" };
            Trainer t6 = new Trainer() { FirstName = "Nikos", LastName = "Papas", Email = "papas@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Trainer t7 = new Trainer() { FirstName = "Vasilis", LastName = "Lemonankis", Email = "Lemonankis@gmail.com", Phone = "6972276606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Trainer t8 = new Trainer() { FirstName = "Kiki", LastName = "Karapostolou", Email = "Karapostolou@gmail.com", Phone = "6978636606", Salary = 1400, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Trainer t9 = new Trainer() { FirstName = "Marilena", LastName = "Mitrousia", Email = "Mitrousia@gmail.com", Phone = "697888606", Salary = 1700, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            Trainer t10 = new Trainer() { FirstName = "Annamaria", LastName = "Petraki", Email = "Petraki@gmail.com", Phone = "6978976001", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" };

            t1.Student = s1;
            t2.Student = s2;
            t3.Student = s3;
            t4.Student = s4;
            t5.Student = s5;
            t6.Student = s6;

           
            
            context.Trainers.AddOrUpdate(t => t.FirstName, t1, t2, t3, t4,t5,t6);
            context.SaveChanges();
           
            #endregion






            base.Seed(context);
        }
    }
}