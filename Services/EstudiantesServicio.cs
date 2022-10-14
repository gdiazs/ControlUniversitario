using ControlUniversitario.Entities;
using ControlUniversitario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class EstudiantesServicio
    {
        private readonly EstudiantesRepositorio _estudiantesRepositorio;

        public EstudiantesServicio(EstudiantesRepositorio estudiantesRepositorio)
        {
            _estudiantesRepositorio = estudiantesRepositorio;
        }

        public List<Estudiante> ObtenerTodos() {
            return _estudiantesRepositorio.Todos();
        }
    }
}