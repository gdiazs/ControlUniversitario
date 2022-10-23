using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class CarrerasServicio
    {


        public List<Carrera> ObtenerCarreras()
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {
                return entity.Carreras.ToList();
            }

        }

        public List<Carrera> BuscarCarreraPorNombre(string carreraNombre)
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {
                return entity.Carreras.Include("Cursoes").Where(carrera => carrera.NombreCarrera.Contains(carreraNombre)).ToList();
            }

        }

        public List<Curso> ObtenerCursosDeCarrera(int carreraID)
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {
                return entity.Carreras.Find(carreraID).Cursoes.ToList();
            }
        }

        public void RemoverCurso(int carreraSeleccionada, int cursoSeleccionado)
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {
                var carrera = entity.Carreras.Find(carreraSeleccionada);
                var cursos = entity.Carreras.Find(carreraSeleccionada).Cursoes.ToList();
                foreach (var curso in cursos)
                {
                    if (curso.CursoID.Equals(cursoSeleccionado))
                    {
                        carrera.Cursoes.Remove(curso);
                        break;
                    }
                }

                entity.SaveChanges();
            }
        }

        public void AgregarCurso(int carreraSeleccionada, CursoModelo cursoModelo)
        {
            try
            {
                using (var entity = new ControlUniversitarioDBEntities())
                {

                    var carrera = entity.Carreras.Find(carreraSeleccionada);

                    carrera.Cursoes.Add(new Curso()
                    {
                        NombreDelCurso = cursoModelo.NombreDelCurso,
                        Escuela = cursoModelo.Escuela,
                        Precio = decimal.Parse(cursoModelo.Precio),
                        Descripcion = cursoModelo.Descripcion
                    });

                    entity.SaveChanges();

                }
            }
            catch (DbUpdateException ex)
            {
                throw new CarrerasServicioExcepcion("Ha ocurrido un error al actualizar la carrera", ex);
            }


        }

        public void AgregarCursoAEstudiante(long estudianteID, int cursoID, string cuatrimestre)
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {

                var curso = entity.Cursoes.Find(cursoID);

                var matriculaCurso = new MatriculaDeCurso()
                {
                    CursoID = cursoID,
                    EstudianteID = estudianteID,
                    Cuatrimestre = cuatrimestre,
                    FechaDeMatricula = DateTime.Now,
                    PrecioMatricula = curso.Precio
                };


                entity.MatriculaDeCursoes.Add(matriculaCurso);
                entity.SaveChanges();

            }
        }

        public void RemoverCursoAEstudiante(long estudianteID, int cursoID)
        {
            using (var entity = new ControlUniversitarioDBEntities())
            {

                var estudiante = entity.Estudiantes.Find(estudianteID);

                var curso = estudiante.MatriculaDeCursoes.Where(matriculaCurso => matriculaCurso.CursoID == cursoID).First();

                estudiante.MatriculaDeCursoes.Remove(curso);

                entity.SaveChanges();

            }
        }

        public static string DeterminarCuatrimestre()
        {
            var now = DateTime.Now;
            if (now.Month >= 1 && now.Month <= 4)
            {
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
    }
}