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
    }
}
