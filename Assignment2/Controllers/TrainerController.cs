using Assignment2.Models;
using Assignment2.MyContext;
using Assignment2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {

        private ApplicationContext db = new ApplicationContext();
        private TrainerRepository trainerRepository;
        private StudentRepository studentRepository;


        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
            studentRepository = new StudentRepository(db);
        }
        // GET: Trainer
        public ActionResult Index()
        {
            var trainers = trainerRepository.GetAllWithStudent();
            ViewBag.TotalTrainers = trainers.Count();
            return View(trainers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetStudents();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid) // BackEnd Validation
            {
                trainerRepository.Add(trainer);
                return RedirectToAction("Index");
                ShowAlert($" You have successfully created trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}");

            }
            GetStudents();
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trainer = trainerRepository.GetById(id);

            if(trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            GetStudents();
            return View(trainer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid) //Back End Validation
            {
                trainerRepository.Edit(trainer);
                ShowAlert($" You have successfully updated trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}");
                return RedirectToAction("Index");
            }
            GetStudents();
            return View(trainer);
        }



        public ActionResult Details(int? id)
        {
            var trainer = trainerRepository.GetById(id);

            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(trainer);
        }

        public ActionResult Edit()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var trainer = trainerRepository.GetById(id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            trainerRepository.Delete(trainer);
            TempData["message"] = $" You have successfully deleted trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) // katastrogi tou context
        {
            if (disposing)
            {
                db.Dispose();
            }
            
            base.Dispose(disposing);
        }

        [NonAction]
        public void GetStudents()
        {
            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            ViewBag.TotalStudents = students.Count();
        }

        [NonAction]
        public void GetStudentsCount()
        {
            var students = studentRepository.GetAll();
            ViewBag.TotalStudents = students.Count();
        }
        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }

    }
}