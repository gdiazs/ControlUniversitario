using ControlUniversitario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlUniversitario.Controllers
{
    public class CarrerasController : Controller
    {

        private readonly CarrerasServicio _carrerasServicio;

        public CarrerasController(CarrerasServicio carrerasServicio)
        {
            _carrerasServicio = carrerasServicio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}