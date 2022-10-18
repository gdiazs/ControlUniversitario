using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class CarrerasServicio
    {
        private readonly List<CarreraModelo> carreras;

        public CarrerasServicio()
        {
            //Según los requisitos ya existen.
            carreras = new List<CarreraModelo>
            {
                new CarreraModelo() { CarreraID = 1, NombreCarrera = "Informática" },
                new CarreraModelo() { CarreraID = 1, NombreCarrera = "Administración" },
                new CarreraModelo() { CarreraID = 1, NombreCarrera = "Diseño Gráfico" }
            };
        }

        public List<CarreraModelo> ObtenerCarreras()
        {

            return carreras;
        }
    }
}