using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public  interface IServiceAccount
    {
        IEnumerable<Charge> GetCharges();
        IEnumerable<Charge> GetChargesByResidentEmail(string email);
    }
}
