using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryIncident
    {
        List<Incident> GetIncidents();
        List<Incident> GetIncidentsByIdResident(int id);
        Incident GetIncidentById(int id);
        void MarkIncidentAsSolved(int id);
        void NewIncident(Incident incident);
        void EditIncident(Incident incident);
        void DeleteIncident(int id);
    }
}
