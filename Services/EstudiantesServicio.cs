using ControlUniversitario.Entities;
using ControlUniversitario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace ControlUniversitario.Services
{
    public class EstudiantesServicio
    {
        private const string Unico = "UNIQUE";
        private const string DateFormat = "yyyy-MM-dd";


        public List<Estudiante> ObtenerTodos() {
            using (var entitites = new ControlUniversitarioDBEntities())
            {
                return entitites.Estudiantes.ToList();
            }
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
                using (var entities = new ControlUniversitarioDBEntities())
                {
                    var estudianteIngresado = entities.Estudiantes.Add(estudiante);
                    entities.SaveChanges();

                }
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

                var estudianteEntityEncontrado = entities.Estudiantes.Find(id);
                var estudianteModelo = this.Convertir(estudianteEntityEncontrado);
                estudianteModelo.Id = id;
                return estudianteModelo;
            }
           
        }

        private EstudianteModelo Convertir(Estudiante estudianteEncontrado)
        {
            return new EstudianteModelo()
            {
                Id = estudianteEncontrado.EstudianteID,
                Identificacion = estudianteEncontrado.Identificacion,
                Nombre = estudianteEncontrado.Nombre,
                FechaDeNacimiento = estudianteEncontrado.FechaDeNacimiento.ToString(DateFormat), 
                PrimerApellido = estudianteEncontrado.PrimerApellido,   
                SegundoApellido = estudianteEncontrado.SegundoApellido,
    
            };
        }



        public void Actualizar(EstudianteModelo estudianteModelo)
        {
            using (var entities = new ControlUniversitarioDBEntities()) {

                var estudianteEncontrado = entities.Estudiantes.Find(estudianteModelo.Id);
                estudianteEncontrado.Identificacion = estudianteModelo.Identificacion;
                estudianteEncontrado.Nombre = estudianteModelo.Nombre;
                estudianteEncontrado.PrimerApellido = estudianteModelo.PrimerApellido;
                estudianteEncontrado.SegundoApellido = estudianteModelo.SegundoApellido;
                estudianteEncontrado.FechaDeNacimiento = Convert.ToDateTime(estudianteModelo.FechaDeNacimiento);
                entities.SaveChanges();
            }
        }


        public void Eliminar(int id) {
            using (var entitites = new ControlUniversitarioDBEntities()) {
                entitites.Estudiantes.Remove(entitites.Estudiantes.Find(id));
                entitites.SaveChanges();
            }
        }
    }
}