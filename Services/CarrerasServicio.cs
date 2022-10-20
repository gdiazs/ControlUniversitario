using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
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
                var cursos =  entity.Carreras.Find(carreraSeleccionada).Cursoes.ToList();
                foreach(var curso in cursos)
                {
                    if (curso.CursoID.Equals(cursoSeleccionado)) {
                        carrera.Cursoes.Remove(curso);
                        break;
                    }
                }

                entity.SaveChanges();
            }
        }

        public void AgregarCurso(int carreraSeleccionada, CursoModelo cursoModelo) {

            using (var entity = new ControlUniversitarioDBEntities()) {

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
    }
}