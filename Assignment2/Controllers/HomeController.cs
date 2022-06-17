using Assignment2.Models;
using Assignment2.Models.ViewModels;
using Assignment2.MyContext;
using Assignment2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Student stu1 = new Student() { FirstName = "Manolis", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Student stu2 = new Student() { FirstName = "Kiriakos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Student stu3 = new Student() { FirstName = "Maria", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Student stu4 = new Student() { FirstName = "Danai", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            List<Student> studentsExample = new List<Student>() { stu1, stu2, stu3, stu4 };

            Trainer t1 = new Trainer() { FirstName = "Dimitris", LastName = "Papadopoulos", Email = "papadopoulos@gmail.com", Phone = "6978976606", Salary = 2000, HireDate = new DateTime(2022, 01, 03), PhotoUrl = "https://media.gettyimages.com/photos/dimitrios-papadopoulos-greece-picture-id651371678" };
            Trainer t2 = new Trainer() { FirstName = "Christos", LastName = "Lemonis", Email = "Lemonis@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 03), PhotoUrl = "https://media.gettyimages.com/photos/panagiotis-lemonis-head-coach-of-piraeus-poses-prior-the-uefa-league-picture-id77179559?s=612x612" };
            Trainer t3 = new Trainer() { FirstName = "Katerina", LastName = "Karapappa", Email = "Karapappa@gmail.com", Phone = "6978976606", Salary = 1200, HireDate = new DateTime(2022, 02, 05), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };
            Trainer t4 = new Trainer() { FirstName = "Maria", LastName = "Mitraki", Email = "Mitraki@gmail.com", Phone = "6978976606", Salary = 1750, HireDate = new DateTime(2022, 07, 03), PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRu0UPJar51CJIZD9M9E6lT6obTHYndhVEKiw&usqp=CAU" };
            List<Trainer> trainersExample = new List<Trainer>() { t1, t2, t3, t4 };
            Baroufa ba = new Baroufa()
            {
                Title = "BAROUFA",
                Students = studentsExample,
                StudentsCount = studentsExample.Count(),
                Trainers = trainersExample,
                TrainersCount = trainersExample.Count()
            };
            return View(ba);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}