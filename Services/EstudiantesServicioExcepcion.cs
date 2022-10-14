using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class EstudiantesServicioExcepcion : Exception
    {
        public EstudiantesServicioExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}