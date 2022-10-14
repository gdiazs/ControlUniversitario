using ControlUniversitario.Models;
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
            return View("EstudianteFormulario");
        }

        [HttpGet]
        public ActionResult Editar(int id) {
            var estudianteEncontrado = this._estudiantesServicio.ObtenerPorId(id);
            return View("EstudianteFormulario", estudianteEncontrado);
        }

        [HttpPost]
        public ActionResult Agregar( EstudianteModelo estudianteModelo)
        {
            var vistaNuevo = View("EstudianteFormulario", estudianteModelo);
            if (ModelState.IsValid)
            {
                try
                {
                    this._estudiantesServicio.Agregar(estudianteModelo);
                }
                catch (EstudiantesServicioExcepcion ex) {
                    ViewData["MensajeError"] = ex.Message;
                    return vistaNuevo;
                }
                return RedirectToAction("Index");

            }
            else
            {
                ViewData["message"] = "La solcitud es inválida";
                return vistaNuevo;
            }
            
        }

    }
}