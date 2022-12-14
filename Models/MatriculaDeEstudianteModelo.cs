using ControlUniversitario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Models
{
    public class MatriculaDeEstudianteModelo
    {
        public Estudiante Estudiante { set; get; }

        public int EstudianteId { set; get; }

        public string NombreCarrera { set; get; }

        public List<Carrera> Carreras;

        public String CursoAMatricular { set; get; }

        public List<Curso> CursosMatriculados;

        public Decimal TotalAPagar { set; get; }
    }


}