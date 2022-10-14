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
            var estudiantes = this._estudiantesServicio.ObtenerTodos();
            return View(estudiantes);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar()
        {
            return RedirectToAction("Index");
        }

    }
}