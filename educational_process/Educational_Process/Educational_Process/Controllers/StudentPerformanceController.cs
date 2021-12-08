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
    public class StudentPerformanceController : Controller
    {
        private readonly IStudentPerformanceService _studentPerformanceServices;
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentPerformanceController(
            IStudentPerformanceService studentPerformanceServices,
            EducationalProcessContext educationalProcessContext)
        {
            _studentPerformanceServices = studentPerformanceServices;
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

            return View("Details", model);
        }
    }
}
