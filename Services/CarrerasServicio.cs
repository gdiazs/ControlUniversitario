using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class CarrerasServicio
    {


        public List<Carrera> ObtenerCarreras()
        {
            using (var entity = new ControlUniversitarioDBEntities()) {
                return entity.Carreras.ToList();
            }

        }
    }
}