using ControlUniversitario.Entities;
using ControlUniversitario.Models;
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
            List<SelectListItem> itemsCarreras = this.ObtenerListaCarreras();

            itemsCarreras.Insert(0, new SelectListItem() { Value = "-1", Text = "Seleccione una carrera", Selected = true });

            return View(new CarreraModelo() { Carreras = itemsCarreras, Cursos = new List<Curso>() });
        }

        [HttpGet]
        public ActionResult Cursos(CarreraModelo carreraCursosModelo)
        {
            List<SelectListItem> itemsCarreras = this.ObtenerListaCarreras();

            foreach (SelectListItem item in itemsCarreras)
            {
                if (item.Value.Equals(carreraCursosModelo.CarreraSeleccionada))
                {
                    item.Selected = true;
                    carreraCursosModelo.NombreCarreraSeleccionada = item.Text;
                }
            }

            var cursos = this._carrerasServicio.ObtenerCursosDeCarrera(int.Parse(carreraCursosModelo.CarreraSeleccionada));
            carreraCursosModelo.Carreras = itemsCarreras;
            carreraCursosModelo.Cursos = cursos;


            return View("Index", carreraCursosModelo);
        }

        [HttpPost]
        public ActionResult EliminarCurso(CarreraModelo carreraCursosModelo)
        {

            this._carrerasServicio.RemoverCurso(int.Parse(carreraCursosModelo.CarreraSeleccionada), int.Parse(carreraCursosModelo.CursoSeleccionado));

            return RedirectToAction("Cursos", carreraCursosModelo);
        }

        [HttpPost]
        public ActionResult AgregarCurso(CarreraModelo carreraModelo)
        {

            _carrerasServicio.AgregarCurso(int.Parse(carreraModelo.CarreraSeleccionada), carreraModelo.NuevoCurso);

            return RedirectToAction("Cursos", carreraModelo);

        }

        private List<SelectListItem> ObtenerListaCarreras()
        {
            var carreras = this._carrerasServicio.ObtenerCarreras();
            var itemsCarreras = carreras.Select(carrera => new SelectListItem()
            {
                Value = carrera.CarreraID.ToString(),
                Text = carrera.NombreCarrera

            }).ToList();

            return itemsCarreras;
        }
    }
}