using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceIncident : IServiceIncident
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
            IRepositoryIncident repositoryIncident = new RepositoryIncident();
            return repositoryIncident.GetIncidentById(id);
        }

        public List<Incident> GetIncidents()
        {
            IRepositoryIncident repositoryIncident = new RepositoryIncident();
           return  repositoryIncident.GetIncidents();
        }

        public List<Incident> GetIncidentsByIdResident(int id)
        {
            IRepositoryIncident repositoryIncident = new RepositoryIncident();
            return repositoryIncident.GetIncidentsByIdResident(id);
        }

        public void NewIncident(Incident incident)
        {
            IRepositoryIncident repositoryIncident = new RepositoryIncident();
            repositoryIncident.NewIncident(incident);
        }
    }
}
