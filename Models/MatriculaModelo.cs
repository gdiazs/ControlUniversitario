using ControlUniversitario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class MatriculaModelo
    {
        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public List<Estudiante> Estudiantes { get; set; }
    }
}