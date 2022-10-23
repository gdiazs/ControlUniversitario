using ControlUniversitario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class ReportesServicio
    {

        public List<Curso> ObtenerEstudiantesPorCursos() {

            using (var entitites = new ControlUniversitarioDBEntities())
            {
                return entitites.Cursoes.ToList();
            }


        }
    }
}