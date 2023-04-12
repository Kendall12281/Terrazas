using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryIncident : IRepositoryIncident
    {
        public void DeleteIncident(int id)
        {
            throw new NotImplementedException();
        }

        public void EditIncident(Incident incident)
        {
            throw new NotImplementedException();
        }

        public Incident GetIncidentById(int id)
        {
            Incident incident = new Incident();
            try
            {
                using(MyContext db = new MyContext())
                {
                    incident = db.Incident.Include("IncidentState").Include("Resident")
                        .Where(x=>x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                
            }
            return incident;
        }

        public List<Incident> GetIncidents()
        {
            List <Incident> list = new List<Incident>();
            try
            {
                using(MyContext db = new MyContext())
                {
                     list = db.Incident.Include("Resident").Include("IncidentState")
                        .ToList();
                }
            }
            catch (Exception)
            {

                
            }
            return list;
        }

        public List<Incident> GetIncidentsByIdResident(int id)
        {
            List<Incident> list = new List<Incident> ();
            try
            {
                using(MyContext db = new MyContext())
                {
                    list = db.Incident.Include("IncidentState")
                        .Where(x=> x.IdResident == id).ToList();
                }
            }
            catch (Exception)
            {


            }

            return list;
        }

        public void MarkIncidentAsSolved(int id)
        {
            try
            {
                using(MyContext db = new MyContext())
                {
                    db.Incident.Find(id).IdIncidentState = 2;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void NewIncident(Incident incident)
        {
            try
            {
                using(MyContext db = new MyContext())
                {
                    db.Incident.Add(incident);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
