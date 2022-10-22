using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlUniversitario.Models
{
    public class ReporteModelo
    {
        public List<SelectListItem> ListaDeReportes { set; get; }
        public string ReporteSeleccionado { set; get; }
    }
}