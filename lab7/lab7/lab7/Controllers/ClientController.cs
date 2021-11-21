using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab7.Models;
using lab7.Services.Int;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientServices;

        public ClientController(
            IClientService clientServices)
        {
            _clientServices = clientServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _clientServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _clientServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Client model)
        {
            _clientServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _clientServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _clientServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Client model)
        {
            _clientServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _clientServices.GetById(id);

            return View("Details", model);
        }
    }
}
