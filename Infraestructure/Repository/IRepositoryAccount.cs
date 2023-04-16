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
        IEnumerable<Charge> GetPendingChargesByResidentEmail(string email);
        IEnumerable<Charge> GetCancelledChargesByResidentEmail(string email); 
        IEnumerable<Charge> GetChargesByResidentId(int id);
        IEnumerable<Charge> GetPendingChargesByResidentId(int id);
        IEnumerable<Charge> GetCancelledChargesByResidentId(int id);
        Charge GetChargeByChargeId(int id);

        void MarkAsPaid(int id);
    }
}
