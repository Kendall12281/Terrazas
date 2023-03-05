using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceIncident
    {
        List<Incident> GetIncidents();
        List<Incident> GetIncidentsByIdResident(int id);
        Incident GetIncidentById(int id);
        void NewIncident(Incident incident);
        void EditIncident(Incident incident);
        void DeleteIncident(int id);
    }
}
