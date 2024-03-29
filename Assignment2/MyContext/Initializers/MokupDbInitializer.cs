﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment2.Models;
using System.Data.Entity.Migrations;
using Assignment2.Models.Enum;

namespace Assignment2.MyContext.Initializers
{
    public class MockupDBInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {


        protected override void Seed(ApplicationContext context) // the control Of Seed be taken from this class now,instead of Migrations/Configuration.cs
        {

            #region Seeding Student data
            Student s1 = new Student() { FirstName = "Manolis", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678", Country = Country.Greece };
            Student s2 = new Student() { FirstName = "Kiriakos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612", Country = Country.Greece };
            Student s3 = new Student() { FirstName = "Maria", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg", Country = Country.USA };
            Student s4 = new Student() { FirstName = "Danai", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU", Country = Country.France };
            Student s5 = new Student() { FirstName = "Persefoni", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg", Country = Country.France };
            Student s6 = new Student() { FirstName = "Kirio", LastName = "Lemon", Email = "Lemon@gmail.com", Phone = "6978970056", Salary = 1500, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612", Country = Country.USA };
            Student s7 = new Student() { FirstName = "Marianna", LastName = "Kara", Email = "Kara@gmail.com", Phone = "6974246606", Salary = 1700, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg", Country = Country.France };
            Student s8 = new Student() { FirstName = "Niki", LastName = "Mitropoulou", Email = "Mitropoulou@gmail.com", Phone = "6978976606", Salary = 2000, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU", Country = Country.Cyprus };
            Student s9 = new Student() { FirstName = "Kalliopi", LastName = "Petropoulou", Email = "P.Petropoulou@gmail.com", Phone = "6978236606", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg", Country = Country.Cyprus };
            Student s10 = new Student() { FirstName = "Petros", LastName = "Kokkalis", Email = "Kokkalis@gmail.com", Phone = "6978970056", Salary = 1500, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612", Country = Country.Cyprus };
            Student s11 = new Student() { FirstName = "Euvaggelia", LastName = "Paulou", Email = "Paulou@gmail.com", Phone = "6974246606", Salary = 1700, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg", Country = Country.USA };
            Student s12 = new Student() { FirstName = "Dimitra", LastName = "Kalla", Email = "Kalla@gmail.com", Phone = "6978976606", Salary = 2000, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU", Country = Country.Greece };
            Student s13 = new Student() { FirstName = "Elli", LastName = "Kokkinou", Email = "Kokkinou@gmail.com", Phone = "6978236606", Salary = 1200, HireDate = new DateTime(2022, 01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg", Country = Country.Greece };
            
            context.Students.AddOrUpdate(s => s.FirstName, s1, s2, s3, s4, s5, s6,s7 ,s8,s9,s10,s11,s12,s13);
            context.SaveChanges();
            #endregion

            #region Seeding Trainer Data
             Trainer t1 = new Trainer() { FirstName = "Dimitris", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 2000, HireDate= new DateTime(2022,01,03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678", Country = Country.Cyprus};
            Trainer t2 = new Trainer() { FirstName = "Christos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612", Country = Country.Greece };
            Trainer t3 = new Trainer() { FirstName = "Katerina", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,02,05) ,PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" , Country = Country.France };
            Trainer t4 = new Trainer() { FirstName = "Maria", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1750, HireDate = new DateTime(2022,07,03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" , Country = Country.Cyprus };
            Trainer t5 = new Trainer() { FirstName = "Kiriaki", LastName = "Petropoulou", Email = "Petropoulou@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022,01, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg" , Country = Country.USA };
            Trainer t6 = new Trainer() { FirstName = "Nikos", LastName = "Papas", Email = "papas@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Trainer t7 = new Trainer() { FirstName = "Vasilis", LastName = "Lemonankis", Email = "Lemonankis@gmail.com", Phone = "6972276606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612",Country = Country.USA };
            Trainer t8 = new Trainer() { FirstName = "Katerina", LastName = "Karapostolou", Email = "Karapostolou@gmail.com", Phone = "6978636606", Salary = 1400, HireDate = new DateTime(2022, 02, 04), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg", Country = Country.USA };
            Trainer t9 = new Trainer() { FirstName = "Marilena", LastName = "Mitrousiaki", Email = "Mitrousia@gmail.com", Phone = "6978776606", Salary = 1700, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://0.academia-photos.com/63899913/19227968/32368558/s200_eleni.chasioti.jpg",Country = Country.Cyprus };
            Trainer t10 = new Trainer() { FirstName = "Vasiliki", LastName = "Kiriakidi", Email = "Kiriakidi@gmail.com", Phone = "6978776806", Salary = 3000, HireDate = new DateTime(2022, 03, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg", Country = Country.France };
            Trainer t11 = new Trainer() { FirstName = "Nikolaos", LastName = "Petropoulos", Email = "Petropoulos@gmail.com", Phone = "6978778606", Salary = 1200, HireDate = new DateTime(2022, 01, 09), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678", Country = Country.Greece };
            Trainer t12 = new Trainer() { FirstName = "Vasilis", LastName = "Zafeiris", Email = "Zafeiris@gmail.com", Phone = "6971776606", Salary = 1200, HireDate = new DateTime(2022, 02, 01), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612", Country = Country.France };
            Trainer t13 = new Trainer() { FirstName = "Nikoleta", LastName = "Kanakidou", Email = "Kanakidou@gmail.com", Phone = "6978116606", Salary = 1700, HireDate = new DateTime(2022, 02, 08), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg", Country = Country.Greece };
            Trainer t14 = new Trainer() { FirstName = "Marianna", LastName = "Mitrousidi", Email = "Mitrousidi@gmail.com", Phone = "6978771616", Salary = 1700, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU", Country = Country.France };
            Trainer t15 = new Trainer() { FirstName = "Iokasti", LastName = "Adamopoulou", Email = "Adamopoulou@gmail.com", Phone = "6978776116", Salary = 1800, HireDate = new DateTime(2022, 02, 15), PhotoUrl = "https://www.kathimerini.gr//resources/2017-11/img_3730.jpg", Country = Country.Greece };
            #endregion

            #region Seeding Course Data
            Course c1 = new Course() { Title = "Language C# BEGINNER" , Duration = 120};
            Course c2 = new Course() { Title = "Language C# ADVANCED" , Duration = 120};
            Course c3 = new Course() { Title = "Language EF" , Duration = 120};
            Course c4 = new Course() { Title = "Language NETWORKS", Duration = 120};
            Course c5 = new Course() { Title = "Language HTML/CSS" , Duration = 120};
            Course c6 = new Course() { Title = "Language JAVA", Duration = 120};
            Course c7 = new Course() { Title = "Language ANGULAR.JS" , Duration = 120};
            Course c8 = new Course() { Title = "Language REACT.JS", Duration = 120};

            #endregion

            #region Trainer-Course Adding
            t1.Courses.Add(c1);
            t1.Courses.Add(c2);
            t1.Courses.Add(c3);
            t1.Courses.Add(c4);
            t1.Courses.Add(c5);

            t2.Courses.Add(c6);
            t2.Courses.Add(c2);
            t2.Courses.Add(c3);
            t2.Courses.Add(c4);

            t3.Courses.Add(c5);
            t3.Courses.Add(c1);
            t3.Courses.Add(c2);

            t4.Courses.Add(c1);
            t4.Courses.Add(c6);

            t5.Courses.Add(c5);
            t5.Courses.Add(c3);
            t5.Courses.Add(c1);
            context.SaveChanges();
            #endregion


            #region Teacher-Student Adding
            t1.Student = s1;
            t2.Student = s2;
            t3.Student = s3;
            t4.Student = s4;
            t5.Student = s5;
            t6.Student = s6;
            t7.Student = s7;
            t8.Student = s8;
            t9.Student = s9;
            t10.Student = s10;
            t11.Student = s11;
            t12.Student = s12;
            t13.Student = s13;
            #endregion

            context.Trainers.AddOrUpdate(t => t.FirstName, t1, t2, t3, t4,t5,t6, t7, t8, t9, t10, t11,t12,t13);
            context.SaveChanges();
           
      
            base.Seed(context);
        }
    }
}