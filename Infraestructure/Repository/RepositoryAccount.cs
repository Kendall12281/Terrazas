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
        public IEnumerable<Charge> GetCancelledChargesByResidentEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Charge> GetCancelledChargesByResidentId(int id)
        {
            try
            {
                MyContext db = new MyContext();
                return db.Charge.Include("Resident").Include("Plan").Where(x => x.IdResident == id && x.Cancelled == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Charge GetChargeByChargeId(int id)
        {
            try
            {
                MyContext db = new MyContext();
                return db.Charge.Include("Resident").Include("Plan")
                    .Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

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
            try
            {
                MyContext db = new MyContext();
                return db.Charge.Include("Resident").Include("Plan").Where(x=> x.IdResident == id && x.Cancelled != true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
