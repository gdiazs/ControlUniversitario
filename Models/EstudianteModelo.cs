using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class EstudianteModelo
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public System.DateTime FechaDeNacimiento { get; set; }
    }
}