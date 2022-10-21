using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using ControlUniversitario.Services;

namespace ControlUniversitario.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly EstudiantesServicio _estudiantesServicio;
        private readonly CarrerasServicio _carrerasServicio;

        public MatriculasController(EstudiantesServicio estudiantesServicio, CarrerasServicio carrerasServicio)
        {
            _estudiantesServicio = estudiantesServicio;
            _carrerasServicio = carrerasServicio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new MatriculaModelo());
        }

        [HttpPost]
        public ActionResult BuscarEstudiante(MatriculaModelo matriculaModelo) {

            var estudiantesPorCedula = _estudiantesServicio.BuscarPorCedula(matriculaModelo.Cedula);
            var estudiantesPorNombre = _estudiantesServicio.BuscarPorNombre(matriculaModelo.Nombre);

            if (estudiantesPorCedula.Count > 0) {
                matriculaModelo.Estudiantes = estudiantesPorCedula;
            }

            if (estudiantesPorNombre.Count > 0)
            {
                matriculaModelo.Estudiantes = estudiantesPorNombre;
            }
            matriculaModelo.Cedula = "";
            matriculaModelo.Nombre = "";

            return View("Index", matriculaModelo);

        }

        [HttpGet]
        public ActionResult Matricular(int estudianteId) {

            var estudiante = _estudiantesServicio.BuscarPorId(estudianteId);
            var cursosMatriculados = estudiante.MatriculaDeCursoes.Select(matricula => matricula.Curso).ToList();


            var matriculaEstudiante = new MatriculaDeEstudianteModelo() {
                Estudiante = estudiante,
                CursosMatriculados = cursosMatriculados
            };

            return View(matriculaEstudiante);
        }

        public ActionResult BuscarCarrera(MatriculaDeEstudianteModelo matriculaDeEstudianteModelo) {

            var estudiante = _estudiantesServicio.BuscarPorId(matriculaDeEstudianteModelo.EstudianteId);
            var carreras = _carrerasServicio.BuscarCarreraPorNombre(matriculaDeEstudianteModelo.NombreCarrera);
            var cursosMatriculados = estudiante.MatriculaDeCursoes.Select(matriculados => matriculados.Curso).ToList();

            matriculaDeEstudianteModelo.Carreras = carreras;
            matriculaDeEstudianteModelo.Estudiante = estudiante;
            matriculaDeEstudianteModelo.CursosMatriculados = cursosMatriculados;


            return View("Matricular", matriculaDeEstudianteModelo);
        }
    }
}