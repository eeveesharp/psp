using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
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
        private delegate string Foo(int st);
        private XLWorkbook _xLWorkbook;
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

        [HttpGet]
        public IActionResult Download(string subjectId)
        {
            if (int.TryParse(subjectId, out int id))
            {
                _xLWorkbook = _studentPerformanceServices.GetWorkbookBySubject(id);
            }
            else
            {
                _xLWorkbook = _studentPerformanceServices.GetFullWorkbook();
            }

            using var stream = new MemoryStream();
            _xLWorkbook.SaveAs(stream);
            var content = stream.ToArray();

            _xLWorkbook.Dispose();
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Успеваемось.xlsx");
        }

        // GET: ProductController/Index
        public IActionResult Index(string SearchString, string sort)
        {
            var model = _studentPerformanceServices.GetAll();
            ViewBag.Subject = new SelectList(_subjectServices.GetAll(), "Id", "Name");
            switch (sort)
            {
                case "with3":
                    model = model.Where(x => x.Mark == 3).ToList();
                    break;
                case "without3":
                    model = model.Where(x => x.Mark > 3).ToList();
                    break;
                case "higherThan8":
                    model = model.Where(x => x.Mark > 8).ToList();
                    break;
                case "notpassed":
                    model = model.Where(x => x.Mark < 3).ToList();
                    break;
            }

            if (int.TryParse(SearchString, out int a))
            {
                model = model.Where(x => x.Mark == a).ToList();
            }
            else if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Subject.Name.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase)
                || x.Student.Group.Name.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return View(model);
        }

        public IActionResult Raiting()
        {
            var model = _studentPerformanceServices.GetAll().ToList();

            Foo foo = (int studentId) => {
                var Ball = _studentPerformanceServices.GetAll()
                        .Where(x => x.StudentId == studentId)
                        .Select(x => x.Mark).Sum();
                var quantity = _studentPerformanceServices.GetAll()
                    .Where(x => x.StudentId == studentId)
                    .Select(x => x.Mark).Count();
                var sredniyBall = Math.Round(Convert.ToDouble(Ball) / quantity, 2).ToString();
                return sredniyBall;
            };

            model.ForEach(x => x.Subject.Name = foo(x.StudentId));
            model = model.GroupBy(x => x.Student.SecondName).Select(x => x.First()).OrderByDescending(x => Convert.ToDouble(x.Subject.Name)).ToList();
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
            var students = _studentServices.GetAll();
            var subjects = _subjectServices.GetAll();

            ViewBag.Students = new SelectList(students, "Id", "SecondName");
            ViewBag.Subjects = new SelectList(subjects, "Id", "Name");

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

            var subject = string.Join(";",_studentPerformanceServices.GetAll()
                .Where(x => x.StudentId == model.StudentId)
                .Select(x => $"{x.Subject.Name} - {x.Mark}," +
                $" Преподаватель: {x.Subject.Teacher.SecondName} {x.Subject.Teacher.FirstName} {x.Subject.Teacher.ThirdName}," +
                $" Дата сдачи: {x.ExamDate}"));

            var Ball = _studentPerformanceServices.GetAll()
                 .Where(x => x.StudentId == model.StudentId)
                 .Select(x => x.Mark).Sum();
            var quantity = _studentPerformanceServices.GetAll()
                 .Where(x => x.StudentId == model.StudentId)
                 .Select(x => x.Mark).Count();
            var sredniyBall = Math.Round(Convert.ToDouble(Ball) / quantity, 2).ToString();
            model.Subject.Name = $"{subject};Средний балл: {sredniyBall}";

            return View("Details", model);
        }
    }
}
