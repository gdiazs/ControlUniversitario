using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using ControlUniversitario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
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
        public ActionResult Agregar( EstudianteModelo estudianteModelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this._estudiantesServicio.Agregar(estudianteModelo);
                }
                catch (EstudiantesServicioExcepcion ex) {
                    ViewData["MensajeError"] = ex.Message;
                    return View("Nuevo", estudianteModelo);
                }
                TempData["MensajeExito"] = $"Estudiante con cédula {estudianteModelo.Identificacion} ha sido agregado satisfactoriamente";
                return RedirectToAction("Nuevo");

            }
            else
            {
                ViewData["MensajeAdvertencia"] = "La solcitud es inválida";
                return View("Nuevo", estudianteModelo); ;
            }
            
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var estudianteEncontrado = this._estudiantesServicio.ObtenerPorId(id);
            return View(estudianteEncontrado);
        }

        [HttpPost]
        public ActionResult Actualizar(EstudianteModelo estudianteModelo)
        {
            this._estudiantesServicio.Actualizar(estudianteModelo);
            return View("Editar");
        }


    }
}