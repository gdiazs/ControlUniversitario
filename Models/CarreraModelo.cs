using ControlUniversitario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlUniversitario.Models
{
    public class CarreraModelo
    {

        public List<SelectListItem> Carreras { set; get; }

        public string Carrera { set; get; }

        public List<Curso> Cursos { set; get; }
    }
}