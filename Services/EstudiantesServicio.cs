using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using ControlUniversitario.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class EstudiantesServicio
    {
        private const string Unico = "UNIQUE";
        private readonly EstudiantesRepositorio _estudiantesRepositorio;

        public EstudiantesServicio(EstudiantesRepositorio estudiantesRepositorio)
        {
            _estudiantesRepositorio = estudiantesRepositorio;
        }

        public List<Estudiante> ObtenerTodos() {
            return _estudiantesRepositorio.Todos();
        }


        public void Agregar(EstudianteModelo estudianteModelo) {

            var estudiante = new Estudiante()
            {
                Identificacion = estudianteModelo.Identificacion,
                Nombre = estudianteModelo.Nombre,
                PrimerApellido = estudianteModelo.PrimerApellido,
                SegundoApellido = estudianteModelo.SegundoApellido,
                FechaDeNacimiento = DateTime.Parse(estudianteModelo.FechaDeNacimiento),
                FechaDeIngreso = DateTime.Now
                
            };

            try
            {
                this._estudiantesRepositorio.Agregar(estudiante);
            }
            catch (DbUpdateException dbUpdateException)
            {
                this.ManejarException(dbUpdateException);
            }


        }

        private void ManejarException(DbUpdateException dbUpdateException)
        {
            var innerEx = dbUpdateException.InnerException?.InnerException;

            if (innerEx.Message.Contains(Unico))
            {
                throw new EstudiantesServicioExcepcion("Ya existe un estudiante con la misma cédula", dbUpdateException.InnerException);
            }
            throw dbUpdateException;
        }

        public EstudianteModelo ObtenerPorId(int id)
        {
            using (var entities = new ControlUniversitarioDBEntities())
            {

                var estudianteEncontrado = entities.Estudiantes.Find(id);

                return this.Convertir(estudianteEncontrado);
            }
           
        }

        private EstudianteModelo Convertir(Estudiante estudianteEncontrado)
        {
            return new EstudianteModelo()
            {
                Identificacion = estudianteEncontrado.Identificacion,
                Nombre = estudianteEncontrado.Nombre,
                FechaDeNacimiento = String.Format("{0:d}", estudianteEncontrado.FechaDeNacimiento.ToShortDateString()), 
                PrimerApellido = estudianteEncontrado.PrimerApellido,   
                SegundoApellido = estudianteEncontrado.SegundoApellido,
    
            };
        }
    }
}