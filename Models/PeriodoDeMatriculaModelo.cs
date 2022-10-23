using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class PeriodoDeMatriculaModelo
    {
        public string Periodo { get; set; }
        public decimal TotalGanancia { get; set; }
        public int CantidadCursosMatriculados { get; internal set; }
    }
}