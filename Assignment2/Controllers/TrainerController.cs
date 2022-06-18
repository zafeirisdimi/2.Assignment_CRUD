using Assignment2.Models;
using Assignment2.Models.Queries;
using Assignment2.MyContext;
using Assignment2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;


namespace Assignment2.Controllers
{
    public class TrainerController : Controller
    {

        private ApplicationContext db = new ApplicationContext();
        private TrainerRepository trainerRepository;
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;


        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
            studentRepository = new StudentRepository(db);
            courseRepository = new CourseRepository(db);
        }
        // GET: Trainer
        public ActionResult Index(TrainerFilterSettings filterSettings,string sortOrder,int? page,int? pSize)
        {
            //current state of search form
            ViewBag.currentFirstName = filterSettings.searchFirstName;
            ViewBag.currentCountry = filterSettings.searchCountry;
            ViewBag.currentSalaryMin = filterSettings.searchSalaryMin;
            ViewBag.currentSalaryMax = filterSettings.searchSalaryMax;

            //filtering
            (decimal minSalary, decimal maxSalary) trainerSalaryRange;
            var trainersFilter = trainerRepository.Filter(filterSettings, out trainerSalaryRange);
            ViewBag.MinSalary = trainerSalaryRange.minSalary;
            ViewBag.MaxSalary = trainerSalaryRange.maxSalary;


            //sorting
            ViewBag.IdSortParam = sortOrder == "IdAsc" ? "IdDesc" : "IdAsc";   //per id
            ViewBag.FirstNameSortParam = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : ""; //per FirstName
            ViewBag.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "";   //per LastName
            ViewBag.SalarySortParam = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";     //per Salary
            ViewBag.HireDateSortParam = sortOrder == "HireDateAsc" ? "HireDateDesc" : "HireDateAsc";    //per HireDate
            ViewBag.StudentSortParam = sortOrder == "StudentAsc" ? "StudentDesc" : "StudentAsc";        //per Studen.LastName
            ViewBag.CountrySortParam = sortOrder == "CountryAsc" ? "CountryDesc" : "CountryAsc";        //per Country(den emfanizetai pros to paron)

            switch (sortOrder)
            {
                case "IdAsc": trainersFilter = trainersFilter.OrderBy(t => t.Id).ToList(); break;
                case "IdDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.Id).ToList();
                    break;
                
                case "FirstNameAsc": trainersFilter = trainersFilter.OrderBy(t =>t.FirstName).ToList();break;
                case "FirstNameDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.FirstName).ToList(); break;
                
                case "LastNameAsc": trainersFilter = trainersFilter.OrderBy(t => t.LastName).ToList(); break;
                case "LastNameDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.LastName).ToList(); break;
                
                case "SalaryAsc": trainersFilter = trainersFilter.OrderBy(t => t.Salary).ToList(); break;
                case "SalaryDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.Salary).ToList(); break;

                case "HireDateAsc": trainersFilter = trainersFilter.OrderBy(t => t.HireDate).ToList(); break;
                case "HireDateDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.HireDate).ToList(); break;

                case "StudentAsc": trainersFilter = trainersFilter.OrderBy(t => t.Student.LastName).ToList(); break;
                case "StudentDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.Student.LastName).ToList(); break;

                case "CountryAsc": trainersFilter = trainersFilter.OrderBy(t => t.Country).ToList(); break;
                case "CountryDesc": trainersFilter = trainersFilter.OrderByDescending(t => t.Country).ToList(); break;

                default:
                    trainersFilter = trainersFilter.OrderBy(t => t.FirstName).ToList();
                    ViewBag.TotalTrainers = trainersFilter.Count();
                    break;
            }

            //pagination

            int pageSize = pSize ?? 3; //nullable coalescing operator c#
            int pageNumber = page ?? 1; //nullable coalescing operator c#


            //ViewBag.TotalTrainers = trainersFilter.Count();
            return View(trainersFilter.ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetStudents();
            GetCourses();
            Trainer testTrainer = new Trainer() { FirstName = "Katerina", LastName = "Karapostolou", Email = "Karapostolou@gmail.com", Phone = "6978636606", Salary = 1400, HireDate = new DateTime(2022, 02, 04), PhotoUrl = "https://i1.rgstatic.net/ii/profile.image/586432527745024-1516827818338_Q512/Stavroula-Karapapa.jpg" };

            return View(testTrainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer,List<int> coursesIds)
        {
            
            if (ModelState.IsValid) // BackEnd Validation
            {
                if(coursesIds == null)
                {
                    trainerRepository.Add(trainer);
                }
                else
                {
                    trainerRepository.Add(trainer);
                }
                trainerRepository.Add(trainer);
                ShowAlert($" You have successfully created trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}");
                return RedirectToAction("Index");
            }
            GetStudents();
            GetCourses();
            return View(trainer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trainer = trainerRepository.GetById(id);

            if(trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            GetStudents();
            GetCourses();
            return View(trainer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer, List<int> coursesIds)
        {
            if (ModelState.IsValid) //Back End Validation
            {
                try
                {
                    trainerRepository.Edit(trainer,coursesIds);
                }
                catch (Exception)
                {

                    
                }
                ShowAlert($" You have successfully updated trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}");
                return RedirectToAction("Index");
            }
            GetStudents();
            GetCourses();
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
            ShowAlert($" You have successfully deleted trainer with name: {trainer.FirstName} {trainer.LastName} and id: {trainer.Id}") ;

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
        public void GetCourses()
        {
            var courses = courseRepository.GetAll();
            ViewBag.Courses = courses;
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