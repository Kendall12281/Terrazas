using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAccount : IServiceAccount
    {
        public IEnumerable<Charge> GetCancelledChargesByResidentEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Charge> GetCancelledChargesByResidentId(int id)
        {
            IRepositoryAccount repository = new RepositoryAccount();
            return repository.GetCancelledChargesByResidentId(id);
        }

        public Charge GetChargeByChargeId(int id)
        {
            IRepositoryAccount repository = new RepositoryAccount();
            return repository.GetChargeByChargeId(id);
        }

        public IEnumerable<Charge> GetCharges()
        {
            IRepositoryAccount repository = new RepositoryAccount();
            return repository.GetCharges();
        }

        public IEnumerable<Charge> GetChargesByResidentEmail(string email)
        {
            IRepositoryAccount repository = new RepositoryAccount();
            return repository.GetChargesByResidentEmail(email);
        }

        public IEnumerable<Charge> GetChargesByResidentId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Charge> GetPendingChargesByResidentEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Charge> GetPendingChargesByResidentId(int id)
        {
            IRepositoryAccount repository = new RepositoryAccount();
            return repository.GetPendingChargesByResidentId(id);
        }
    }
}
