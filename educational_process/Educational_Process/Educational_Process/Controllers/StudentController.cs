using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Process.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentServices;
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentController(
            IStudentService studentServices,
            EducationalProcessContext educationalProcessContext)
        {
            _studentServices = studentServices;
            _educationalProcessContext = educationalProcessContext;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _studentServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _studentServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Student model)
        {
            _studentServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _studentServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            _studentServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _studentServices.GetById(id);

            return View("Details", model);
        }
    }
}
