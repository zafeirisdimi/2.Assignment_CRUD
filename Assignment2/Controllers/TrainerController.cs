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


        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
        }
        // GET: Trainer
        public ActionResult Index()
        {
            var trainers = trainerRepository.GetAll();
            return View(trainers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid) // BackEnd Validation
            {
                trainerRepository.Add(trainer);
                TempData["message"] = $" You have successfully created trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}";
                return RedirectToAction("Index");
            }

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

    }
}