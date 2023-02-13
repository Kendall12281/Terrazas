using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryAccount : IRepositoryAccount
    {
        public IEnumerable<Charge> GetCharges()
        {
            try
            {
                MyContext db = new MyContext();
                return db.Charge
                    .Include("Resident")
                    .Where(x => x.Resident.Active != false)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Charge> GetChargesByResidentEmail(string email)
        {
            try
            {
                MyContext db = new MyContext();
                return db.Charge
                    .Include("Resident")
                    .Where(x => x.Resident.Active != false && x.Resident.EmailUser == email)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
