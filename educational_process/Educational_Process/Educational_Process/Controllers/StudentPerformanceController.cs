using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Educational_Process.Controllers
{
    public class StudentPerformanceController : Controller
    {
        private readonly IStudentPerformanceService _studentPerformanceServices;
        private readonly IStudentService _studentServices;
        private readonly ISubjectService _subjectServices;
        private readonly ITeacherService _teacherServices;
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentPerformanceController(
            IStudentPerformanceService studentPerformanceServices,
            IStudentService studentServices,
            ISubjectService subjectServices,
            ITeacherService teacherServices,
            EducationalProcessContext educationalProcessContext)
        {
            _teacherServices = teacherServices;
            _studentPerformanceServices = studentPerformanceServices;
            _studentServices = studentServices;
            _subjectServices = subjectServices;
            _educationalProcessContext = educationalProcessContext;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _studentPerformanceServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _studentPerformanceServices.GetById(id);
            var students = _studentServices.GetAll();
            var subjects = _subjectServices.GetAll();

            ViewBag.Students = new SelectList(students, "Id", "SecondName");
            ViewBag.Subjects = new SelectList(subjects, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(StudentPerformance model)
        {
            _studentPerformanceServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentPerformanceServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _studentPerformanceServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(StudentPerformance model)
        {
            _studentPerformanceServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _studentPerformanceServices.GetById(id);

            StudentPerformanceViewModel studentPerformanceViewModel = new StudentPerformanceViewModel()
            {
                Id = model.Id,
                StudentSecondName = model.Student.SecondName,
                SubjectName = model.Subject.Name,
                ExamDate = model.ExamDate,
                Mark = model.Mark
            };

            return View("Details", studentPerformanceViewModel);
        }
    }
}
