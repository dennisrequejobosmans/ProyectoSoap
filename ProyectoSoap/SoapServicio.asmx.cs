using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProyectoSoap;

namespace ProyectoSoap
{
    /// <summary>
    /// Descripción breve de SoapServicio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapServicio : System.Web.Services.WebService
    {

        private PersonasSoapEntities db = new PersonasSoapEntities();

        [WebMethod]
        public List<personas> GetPersonas()
        {
            var listaPersonas = db.personas;

            return listaPersonas.ToList();
        }

        [WebMethod]

        public personas GetPersonaSingular(string nif)
        {
            var listaPersonas = db.personas.Where(u=>u.Nif==nif).First();

            return listaPersonas;
        }

        [WebMethod]

        public List<personas> PostPersona(personas p)
        {
            var listaPersonas = db.personas;

            listaPersonas.Add(new personas()
            {
                Nif= p.Nif,
                Nombre=p.Nombre,
                Apellidos=p.Apellidos,
                Direccion=p.Direccion,
                Ciudad=p.Ciudad,
                Estado_Civil=p.Estado_Civil,
                Sexo=p.Sexo,
                Codigo_Postal=p.Codigo_Postal,
                Provincia=p.Provincia

            });

            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            return listaPersonas.ToList();
        }

        [WebMethod]

        public List<personas> UpdatePersona(personas p)
        {
            var listaPersonas = db.personas;

            var personaSelect = db.personas.Where(u => u.Nif == p.Nif).First();
            listaPersonas.Remove(personaSelect);
            
                

            listaPersonas.Add(new personas()
            {
                Nif = personaSelect.Nif,
                Nombre = p.Nombre,
                Apellidos = p.Apellidos,
                Direccion = p.Direccion,
                Ciudad = p.Ciudad,
                Estado_Civil = p.Estado_Civil,
                Sexo = p.Sexo,
                Codigo_Postal = p.Codigo_Postal,
                Provincia = p.Provincia

            });

            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return listaPersonas.ToList();
        }

        [WebMethod]

        public List<personas> DeletePersona(string nif)
        {
            var listaPersonas = db.personas;

            var personaSelect = db.personas.Where(u => u.Nif == nif).First();
            listaPersonas.Remove(personaSelect);


            db.Entry(personaSelect).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            

            return listaPersonas.ToList();
        }







    }
}
