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

        public ActionResult Create()
        {
            return View();
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

        public ActionResult Delete()
        {
            return View();
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