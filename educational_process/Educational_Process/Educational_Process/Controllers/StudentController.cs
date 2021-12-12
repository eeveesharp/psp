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
using Microsoft.EntityFrameworkCore;

namespace Educational_Process.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentServices;
        private readonly IGroupService _groupServices;
        private readonly EducationalProcessContext _educationalProcessContext;

        public StudentController(
            IStudentService studentServices,
            IGroupService groupServices,
            EducationalProcessContext educationalProcessContext)
        {
            _studentServices = studentServices;
            _groupServices = groupServices;
            _educationalProcessContext = educationalProcessContext;

        }
        // GET: ProductController/Index
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _educationalProcessContext.Students
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.SecondName.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _studentServices.GetById(id);
            var groups = _groupServices.GetAll();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");

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

            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                ThirdName = model.ThirdName,
                GroupName = model.Group.Name
            };

            return View("Details", studentViewModel);
        }
    }
}
