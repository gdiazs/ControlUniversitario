using ControlUniversitario.Models;
using ControlUniversitario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlUniversitario.Controllers
{
    public class ReportesController : Controller
    {
        private const string EstudiantesPorCurso = "estudiantes_x_curso";
        private const string CursosPorEstudiantes = "cursos_x_estudiantes";
        private const string TotalCuatrimestre = "total_x_cuatrimestre";
        private const string EstadisticaCursosMatriculados = "estadistica_cursos_matriculados";

        private readonly ReportesServicio _reportesServicio;

        public ReportesController(ReportesServicio reportesServicio)
        {
            _reportesServicio = reportesServicio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listaDeReportes = ObtenerListaDeReportes();

            return View(new ReporteModelo() { ListaDeReportes = listaDeReportes });
        }

        [HttpPost]
        public ActionResult BuscarReporte(ReporteModelo reporteModelo)
        {

            var listaDeReportes = ObtenerListaDeReportes();


            if (reporteModelo.ReporteSeleccionado.Equals(EstudiantesPorCurso))
            {

                return View("EstudiantesPorCursos", ObtenerEstudiantesPorCursos());
            }

            if (reporteModelo.ReporteSeleccionado.Equals(CursosPorEstudiantes))
            {

                return View("CursosPorEstudiantes", new ReporteModelo() { ListaDeReportes = listaDeReportes });
            }

            if (reporteModelo.ReporteSeleccionado.Equals(TotalCuatrimestre))
            {

                return View("TotalIngresosPorCuatrimestre", new ReporteModelo() { ListaDeReportes = listaDeReportes });
            }


            if (reporteModelo.ReporteSeleccionado.Equals(EstadisticaCursosMatriculados))
            {

                return View("EstadisticaDeCursos", new ReporteModelo() { ListaDeReportes = listaDeReportes });
            }

            


            return View("Index", new ReporteModelo() { ListaDeReportes = listaDeReportes });
        }

        private ReporteModelo ObtenerEstudiantesPorCursos()
        {

            _reportesServicio.ObtenerEstudiantesPorCursos();

            return new ReporteModelo() { ListaDeReportes = ObtenerListaDeReportes() };
        }

        private static List<SelectListItem> ObtenerListaDeReportes()
        {
            var listaDeReportes = new List<SelectListItem>();

            listaDeReportes.Add(new SelectListItem()
            {
                Value = EstudiantesPorCurso,
                Text = "Lista de estudiantes matriculados por curso"

            });

            listaDeReportes.Add(new SelectListItem()
            {
                Value = CursosPorEstudiantes,
                Text = "Lista de cursos con estudiantes matriculados"

            });

            listaDeReportes.Add(new SelectListItem()
            {
                Value = TotalCuatrimestre,
                Text = "Total de ingresos por matricula del cuatrimestre"
            });

            listaDeReportes.Add(new SelectListItem()
            {
                Value = EstadisticaCursosMatriculados,
                Text = "Estadísitca de los cursos que fueron matriculados"
            });
            return listaDeReportes;
        }


    }
}