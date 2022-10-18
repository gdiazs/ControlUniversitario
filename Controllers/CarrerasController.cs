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
            var carreras = this._carrerasServicio.ObtenerCarreras();
            var itemsCarreras  =  carreras.Select(carrera => new SelectListItem() {
                Value = carrera.CarreraID.ToString(),
                Text = carrera.NombreCarrera

            }).ToList();

            itemsCarreras.Insert(0, new SelectListItem() { Value = "-1", Text = "Seleccione una carrera", Selected = true });

            return View(itemsCarreras);
        }
    }
}