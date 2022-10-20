using System;
using System.Runtime.Serialization;

namespace ControlUniversitario.Services
{
    [Serializable]
    internal class CarrerasServicioExcepcion : Exception
    {
        public CarrerasServicioExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}