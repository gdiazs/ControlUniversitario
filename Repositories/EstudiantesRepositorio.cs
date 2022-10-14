using ControlUniversitario.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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