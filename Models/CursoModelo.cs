using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class CursoModelo
    {
        [Required(ErrorMessage = "Nombre del curso requerido")]
        public string NombreDelCurso { get; set; }
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Precio es requerido")]
        public string Precio { get; set; }

        [Required(ErrorMessage = "Escuela es requerida")]
        public string Escuela { get; set; }

    }
}