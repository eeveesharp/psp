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
    public class CardController : Controller
    {
        private readonly ICardService _cardServices;

        public CardController(
            ICardService cardServices)
        {
            _cardServices = cardServices;

        }
        // GET: ProductController/Index
        public IActionResult Index()
        {
            var model = _cardServices.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = _cardServices.GetById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Card model)
        {
            _cardServices.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _cardServices.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _cardServices.GetById(id);

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Card model)
        {
            _cardServices.Edit(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _cardServices.GetById(id);

            return View("Details", model);
        }
    }
}
