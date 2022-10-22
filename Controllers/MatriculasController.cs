using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
                CursosMatriculados = cursosMatriculados,
                TotalAPagar = cursosMatriculados.Select(curso => curso.Precio).Sum()

            };

            return View(matriculaEstudiante);
        }

        [HttpPost]
        public ActionResult MatricularCurso(MatriculaDeEstudianteModelo matriculaDeEstudianteModelo) {

            _carrerasServicio.AgregarCursoAEstudiante(matriculaDeEstudianteModelo.EstudianteId, int.Parse( matriculaDeEstudianteModelo.CursoAMatricular), DeterminarCuatrimestre());

            return View("Matricular", ObtenerEstadoDeMatricula(matriculaDeEstudianteModelo));
        }

        [HttpPost]
        public ActionResult DesmatricularCurso(MatriculaDeEstudianteModelo matriculaDeEstudianteModelo)
        {


            _carrerasServicio.RemoverCursoAEstudiante(matriculaDeEstudianteModelo.EstudianteId, int.Parse(matriculaDeEstudianteModelo.CursoAMatricular));

            return View("Matricular", ObtenerEstadoDeMatricula(matriculaDeEstudianteModelo));
        }

        private string DeterminarCuatrimestre()
        {
            var now = DateTime.Now;
            if (now.Month >= 1 && now.Month <= 4) {
                return "I cuatrimestre";
            }

            if (now.Month >= 5 && now.Month <= 8)
            {
                return "II cuatrimestre";
            }

            if (now.Month >= 9 && now.Month <= 12)
            {
                return "III cuatrimestre";
            }

            return "";
        }

        public ActionResult BuscarCarrera(MatriculaDeEstudianteModelo matriculaDeEstudianteModelo)
        {

            return View("Matricular", ObtenerEstadoDeMatricula(matriculaDeEstudianteModelo));
        }

        private MatriculaDeEstudianteModelo ObtenerEstadoDeMatricula(MatriculaDeEstudianteModelo matriculaDeEstudianteModelo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cr-CR", false);

            var estudiante = _estudiantesServicio.BuscarPorId(matriculaDeEstudianteModelo.EstudianteId);
            var carreras = _carrerasServicio.BuscarCarreraPorNombre(matriculaDeEstudianteModelo.NombreCarrera);
            var cursosMatriculados = estudiante.MatriculaDeCursoes.Select(matriculados => matriculados.Curso).ToList();


            matriculaDeEstudianteModelo.Estudiante = estudiante;
            matriculaDeEstudianteModelo.CursosMatriculados = cursosMatriculados;
            matriculaDeEstudianteModelo.TotalAPagar = cursosMatriculados.Select(curso => curso.Precio).Sum();

            matriculaDeEstudianteModelo.Carreras = carreras;


            return matriculaDeEstudianteModelo;
        }
    }
}