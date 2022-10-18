using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class EstudianteModelo
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Identificación es requerida")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Nombre del estudiante requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Primero apellido es requerido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Segundo apellido es requerido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Fecha de nacimiento es requerido")]
        public string FechaDeNacimiento { get; set; }
    }
}