using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class ReportesServicio
    {

        public List<Curso> ObtenerEstudiantesPorCursos() {

            using (var entitites = new ControlUniversitarioDBEntities())
            {
                return entitites.Cursoes.Include("MatriculaDeCursoes.Estudiante").ToList();
            }


        }

        public PeriodoDeMatriculaModelo CalcularIngresosPorCuatrimestre(String cuatrimestre) {

            using (var entitites = new ControlUniversitarioDBEntities())
            {
                var matriculas = entitites.MatriculaDeCursoes.
                    Where(matricula => matricula.FechaDeMatricula.Year == DateTime.Now.Year && matricula.Cuatrimestre.Equals(cuatrimestre));

                var cursosMatriculados = matriculas.Count();

                return new PeriodoDeMatriculaModelo() {
                    Periodo = cuatrimestre,
                    TotalGanancia = matriculas.Select(matricula => matricula.PrecioMatricula).Sum(),
                    CantidadCursosMatriculados = cursosMatriculados
                };
            }
        }

        public EstadisticaCursosModelo CalcularEstadisticaDeCursos(String cuatrimestre)
        {
            using (var entitites = new ControlUniversitarioDBEntities()) {

                var totalCursos = entitites.Cursoes.Count();

                var matriculas = entitites.MatriculaDeCursoes.
                Where(matricula => matricula.FechaDeMatricula.Year == DateTime.Now.Year && matricula.Cuatrimestre.Equals(cuatrimestre));
               
                var cursos = matriculas.Select(matri => matri.Curso.CursoID).Distinct();

                var estadisticaCursosModelo = new EstadisticaCursosModelo() {
                    PorcentajeDeCursosMatriculados = (cursos.Count() * 100) / totalCursos,
                    TotalCursos = totalCursos,
                    TotalCursosMatriculados = cursos.Count()
                };

                return estadisticaCursosModelo;

            }
                    
        }
    }
}