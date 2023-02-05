using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceResident : IServiceResident
    {
        public void AddResident(Resident resident)
        {
            IRepositoryResident repository = new RepositoryResident();
            repository.AddResident(resident);
        }

        public void DeleteResident(Resident resident)
        {
            IRepositoryResident repository = new RepositoryResident();
            repository.DeleteResident(resident);
        }

        public Resident FindResidentByEmail(string email)
        {
            IRepositoryResident repository = new RepositoryResident();
           return  repository.FindResidentByEmail(email);
        }

        public Resident GetResident(int id)
        {
            IRepositoryResident repository = new RepositoryResident();
            return repository.GetResident(id);
        }

        public IEnumerable<Resident> GetResidents()
        {
            IRepositoryResident respository = new RepositoryResident();
            return respository.GetResidents();
        }
    }
}
