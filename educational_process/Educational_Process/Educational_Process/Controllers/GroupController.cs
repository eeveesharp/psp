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
    public class GroupController : Controller
    {
        private readonly IGroupService _groupServices;
        private readonly EducationalProcessContext _educationalProcessContext;

        public GroupController(
            IGroupService groupServices,
            EducationalProcessContext educationalProcessContext)
        {
            _groupServices = groupServices;
            _educationalProcessContext = educationalProcessContext;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _groupServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _groupServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Group model)
        {
            _groupServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _groupServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _groupServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Group model)
        {
            _groupServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _groupServices.GetById(id);

            return View("Details", model);
        }
    }
}
