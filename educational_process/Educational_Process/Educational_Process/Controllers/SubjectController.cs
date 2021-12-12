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
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectServices;
        private readonly ITeacherService _teacherService;

        private readonly EducationalProcessContext _educationalProcessContext;

        public SubjectController(
            ISubjectService subjectServices,
            ITeacherService teacherService,
            EducationalProcessContext educationalProcessContext)
        {
            _subjectServices = subjectServices;
            _educationalProcessContext = educationalProcessContext;
            _teacherService = teacherService;
        }
        // GET: ProductController/Index
        public IActionResult Index(string SearchString)
        {
            var model = _subjectServices.GetAll();
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.Name.Contains(SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _subjectServices.GetById(id);
            ViewBag.Teacher = new SelectList(_teacherService.GetAll(), "Id", "SecondName");

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Subject model)
        {
            _subjectServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _subjectServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _subjectServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Subject model)
        {
            _subjectServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _subjectServices.GetById(id);

            return View("Details", model);
        }
    }
}
