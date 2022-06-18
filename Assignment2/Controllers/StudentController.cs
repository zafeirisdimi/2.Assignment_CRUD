using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.Models.Queries;
using Assignment2.MyContext;
using Assignment2.Repository;
using PagedList;

namespace Assignment2.Controllers
{
    public class StudentController : Controller
    {

        private ApplicationContext db = new ApplicationContext();
        private TrainerRepository trainerRepository;
        private StudentRepository studentRepository;

        public StudentController()
        {
            trainerRepository = new TrainerRepository(db);
            studentRepository = new StudentRepository(db);
        }


        // GET: Student
        public ActionResult Index(StudentFilterSettings filterSettings, string sortOrder, int? page, int? pSize)
        {
            //current state of search form
            ViewBag.currentFirstName = filterSettings.searchFirstName;
            ViewBag.currentCountry = filterSettings.searchCountry;
            ViewBag.currentSalaryMin = filterSettings.searchSalaryMin;
            ViewBag.currentSalaryMax = filterSettings.searchSalaryMax;

            //filtering
            (int minSalary, int maxSalary) studentSalaryRange;
            var studentsFilter = studentRepository.Filter(filterSettings, out studentSalaryRange);
            ViewBag.MinSalary = studentSalaryRange.minSalary;
            ViewBag.MaxSalary = studentSalaryRange.maxSalary;


            //sorting
            ViewBag.IdSortParam = sortOrder == "IdAsc" ? "IdDesc" : "IdAsc";   //per id
            ViewBag.FirstNameSortParam = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : ""; //per FirstName
            ViewBag.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "";   //per LastName
            ViewBag.SalarySortParam = sortOrder == "SalaryAsc" ? "SalaryDesc" : "SalaryAsc";     //per Salary
            ViewBag.HireDateSortParam = sortOrder == "HireDateAsc" ? "HireDateDesc" : "HireDateAsc";    //per HireDate
            ViewBag.TrainerSortParam = sortOrder == "TrainerAsc" ? "TrainerDesc" : "TrainerAsc";        //per Studen.LastName
            ViewBag.CountrySortParam = sortOrder == "CountryAsc" ? "CountryDesc" : "CountryAsc";        //per Country(den emfanizetai pros to paron)

            switch (sortOrder)
            {
                case "IdAsc": studentsFilter = studentsFilter.OrderBy(t => t.Id).ToList(); break;
                case "IdDesc":
                    studentsFilter = studentsFilter.OrderByDescending(t => t.Id).ToList();
                    break;

                case "FirstNameAsc": studentsFilter = studentsFilter.OrderBy(t => t.FirstName).ToList(); break;
                case "FirstNameDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.FirstName).ToList(); break;

                case "LastNameAsc": studentsFilter = studentsFilter.OrderBy(t => t.LastName).ToList(); break;
                case "LastNameDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.LastName).ToList(); break;

                case "SalaryAsc": studentsFilter = studentsFilter.OrderBy(t => t.Salary).ToList(); break;
                case "SalaryDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.Salary).ToList(); break;

                case "HireDateAsc": studentsFilter = studentsFilter.OrderBy(t => t.HireDate).ToList(); break;
                case "HireDateDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.HireDate).ToList(); break;

               // case "TrainerAsc": studentsFilter = studentsFilter.OrderBy(t => t.Trainers.).ToList(); break;
               // case "TrainerDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.Trainers.LastName).ToList(); break;

                case "CountryAsc": studentsFilter = studentsFilter.OrderBy(t => t.Country).ToList(); break;
                case "CountryDesc": studentsFilter = studentsFilter.OrderByDescending(t => t.Country).ToList(); break;

                default:
                    studentsFilter = studentsFilter.OrderBy(t => t.FirstName).ToList();
                    ViewBag.TotalTrainers = studentsFilter.Count();
                    break;
            }

            //pagination

            int pageSize = pSize ?? 3; //nullable coalescing operator c#
            int pageNumber = page ?? 1; //nullable coalescing operator c#


            //ViewBag.TotalStudents = studentsFilter.Count();
            return View(studentsFilter.ToPagedList(pageNumber, pageSize));
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = studentRepository.GetById(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            GetTrainers();
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Phone,Salary,HireDate,PhotoUrl,Country")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(student);
                ShowAlert($" You have successfully created trainer with name: {student.FirstName} {student.LastName} and id: {student.Id}");
                return RedirectToAction("Index");
                
            }
            GetTrainers();
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            GetTrainers();
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone,Salary,HireDate,PhotoUrl,Country")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Edit(student);
                ShowAlert($" You have successfully updated student with name: {student.FirstName} {student.LastName} and id: {student.Id}");
                return RedirectToAction("Index");
            }
            GetTrainers();
            return View(student);
        }
        

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetByIdWithTrainers(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentRepository.GetById(id);
            studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
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
            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            ViewBag.TotalStudents = students.Count();
        }

        [NonAction]
        public void GetTrainersCount()
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
