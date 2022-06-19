using Assignment2.Models;
using Assignment2.Models.Enum;
using Assignment2.Models.Queries;
using Assignment2.MyContext;
using Assignment2.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        private TrainerRepository trainerRepository;
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;

        public CourseController()
        {
            trainerRepository = new TrainerRepository(db);
            studentRepository = new StudentRepository(db);  
            courseRepository = new CourseRepository(db);    
        }


        [HttpGet]
        public ActionResult Create()
        {
            
            GetTrainers();
            //Course testCoure = new Course() { Title = "Programming OOP", Duration = 200, Category = Field.Design_Patterns, StartDate = DateTime.Today, EndDate = DateTime.MaxValue, HireDate = new DateTime(2022, 02, 04));         
           // return View(testCoure);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course, List<int> trainersIds)
        {

            if (ModelState.IsValid) // BackEnd Validation
            {
                if (trainersIds == null)
                {
                    courseRepository.Add(course);
                }
                else
                {
                    courseRepository.Add(course);
                }
                ShowAlert($" You have successfully created trainer with name: {course.Title} {course.Category} and id: {course.Id}");
                return RedirectToAction("Index");
            }
            //GetStudents();
            GetTrainers();
            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var course = courseRepository.GetById(id);

            if (course == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

           // GetStudents();
            GetTrainers();
            return View(course);
        }

        [HandleError(ExceptionType = typeof(ArgumentException), View = "~/Views/Shared/Error1/cshtml")]
        [HandleError(ExceptionType = typeof(ArgumentNullException), View = "~/Views/Shared/Error2/cshtml")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course, List<int> trainersIds)
        {
            if (ModelState.IsValid) //Back End Validation
            {
                courseRepository.Edit(course, trainersIds);
                ShowAlert($" You have successfully updated trainer with name: {course.Title} {course.Category} and id: {course.Id}");
                return RedirectToAction("Index");
            }
           // GetStudents();
            GetTrainers();
            return View(course);
        }

        // GET: Course
        public ActionResult Index(CourseFilterSettings  filterSettings, string sortOrder, int? page, int? pSize)
        {
            ViewBag.currentTitle = filterSettings.searchTitle;
            ViewBag.currentCategory = filterSettings.searchCategory;
            ViewBag.currentDurationMin = filterSettings.searchDurationMin;
            ViewBag.currentDurationMax = filterSettings.searchDurationMax;

            //filtering
            (int minDuration, int maxDuration) courseDurationRange;
            var coursesFilter = courseRepository.Filter(filterSettings, out courseDurationRange);
            ViewBag.minDuration = courseDurationRange.minDuration;
            ViewBag.maxDuration = courseDurationRange.maxDuration;


            //sorting
            ViewBag.IdSortParam = sortOrder == "IdAsc" ? "IdDesc" : "IdAsc";   //per id
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "TitleDesc" : ""; //per title
            ViewBag.DurationSortParam = sortOrder == "DurationAsc" ? "DurationDesc" : "DurationAsc";     //per Duration
            ViewBag.StartDateSortParam = sortOrder == "StartDateAsc" ? "StartDateDesc" : "StartDateAsc";    //per StartDate
            ViewBag.CategorySortParam = sortOrder == "CategoryAsc" ? "CategoryDesc" : "CategoryAsc";        //per Category

            switch (sortOrder)
            {
                case "IdAsc": coursesFilter = coursesFilter.OrderBy(c => c.Id).ToList(); break;
                case "IdDesc":
                    coursesFilter = coursesFilter.OrderByDescending(c => c.Id).ToList();
                    break;

                case "TitleAsc": coursesFilter = coursesFilter.OrderBy(c => c.Title).ToList(); break;
                case "TitleDesc": coursesFilter = coursesFilter.OrderByDescending(c => c.Title).ToList(); break;


                case "DurationAsc": coursesFilter = coursesFilter.OrderBy(c => c.Duration).ToList(); break;
                case "DurationDesc": coursesFilter = coursesFilter.OrderByDescending(c => c.Duration).ToList(); break;

                case "StartDateAsc": coursesFilter = coursesFilter.OrderBy(c => c.StartDate).ToList(); break;
                case "StartDateDesc": coursesFilter = coursesFilter.OrderByDescending(c => c.StartDate).ToList(); break;

                case "CategoryAsc": coursesFilter = coursesFilter.OrderBy(c => c.Category).ToList(); break;
                case "CategoryDesc": coursesFilter = coursesFilter.OrderByDescending(c => c.Category).ToList(); break;

                default:
                    coursesFilter = coursesFilter.OrderBy(c => c.Title).ToList();
                    ViewBag.TotalCourses = coursesFilter.Count();
                    break;
            }

            //pagination

            int pageSize = pSize ?? 3; //nullable coalescing operator c#
            int pageNumber = page ?? 1; //nullable coalescing operator c#


            //ViewBag.TotalTrainers = coursesFilter.Count();
            return View(coursesFilter.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            var course = courseRepository.GetById(id);

            if (course == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(course);
        }
       
        protected override void Dispose(bool disposing) // katastrofi tou context
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }



        [NonAction]
        public void GetTrainers()
        {
            var trainers = trainerRepository.GetAll();
            ViewBag.Students = trainers;
            ViewBag.TotalStudents = trainers.Count();
        }

        [NonAction]
        public void GetTrainersCount()
        {
            var trainers = trainerRepository.GetAll();
            ViewBag.TotalStudents = trainers.Count();
        }
        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}