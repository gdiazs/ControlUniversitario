using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class EstadisticaCursosModelo
    {
        public int TotalCursos { set; get; }

        public int TotalCursosMatriculados { set; get; }
        public decimal PorcentajeDeCursosMatriculados { set; get; }

    }
}