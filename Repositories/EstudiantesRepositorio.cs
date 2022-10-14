using ControlUniversitario.Entities;
using ControlUniversitario.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Repositories
{
    public class EstudiantesRepositorio : Repositorio<Estudiante, long>
    {
        public Estudiante Actualizar(Estudiante t)
        {
            throw new NotImplementedException();
        }

        public Estudiante Agregar(Estudiante t)
        {
 
            using (var entities = new ControlUniversitarioDBEntities())
            {
                var estudianteIngresado = entities.Estudiantes.Add(t);
                entities.SaveChanges();
                return estudianteIngresado;

            }
        }

        public bool Elimninar(long id)
        {
            throw new NotImplementedException();
        }

        public List<Estudiante> Todos()
        {
            using (var entitites = new ControlUniversitarioDBEntities()) {
               return  entitites.Estudiantes.ToList();
            }
        }
    }
}