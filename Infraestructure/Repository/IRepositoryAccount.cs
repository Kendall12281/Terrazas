using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryAccount
    {
        IEnumerable<Charge> GetCharges();
        IEnumerable<Charge> GetChargesByResidentEmail(string email);
    }
}
