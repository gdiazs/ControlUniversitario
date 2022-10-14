using ControlUniversitario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlUniversitario.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudiantesServicio _estudiantesServicio;

        public EstudiantesController(EstudiantesServicio estudiantesServicio) {
            _estudiantesServicio = estudiantesServicio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}