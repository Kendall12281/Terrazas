using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryResident
    {
        IEnumerable<Resident> GetResidents();
        Resident GetResident(int id);
        Resident FindResidentByEmail(string email);
        void AddResident(Resident resident);
        void DeleteResident(Resident resident);
    }
}
