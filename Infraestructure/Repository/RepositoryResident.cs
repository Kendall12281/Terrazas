using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryResident : IRepositoryResident
    {
        public void AddResident(Resident resident)
        {
			try
			{
				MyContext db = new MyContext();
				db.Resident.AddOrUpdate(resident);
				db.SaveChanges();

			}
			catch (Exception error)
			{

				throw error;
			}
        }
		public void EditResident(Resident resident)
        {
			try
			{
				MyContext db = new MyContext();
				var resident2 = db.Resident.FirstOrDefault(r =>r.Id == resident.Id);
				resident2 = resident;
				db.SaveChanges();

			}
			catch (Exception error)
			{

				throw error;
			}
        }

        public void DeleteResident(Resident resident)
        {
			try
			{
                MyContext db = new MyContext();
                db.Resident.AddOrUpdate(resident);
                db.SaveChanges();
            }
			catch (Exception)
			{

				throw;
			}
        }

        public Resident FindResidentByEmail(string email)
        {
			try
			{
				MyContext db = new MyContext();
				Resident resident = (from r in db.Resident
									where(r.EmailUser == email.Trim())
									select r).FirstOrDefault();
				return resident;

				
			}
			catch (Exception)
			{

				throw;
			}
        }

        public Resident GetResident(int id)
        {
			try
			{
				MyContext db = new MyContext();
				return db.Resident.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public IEnumerable<Resident> GetResidents()
        {
			try
			{
				MyContext db = new MyContext();
				return db.Resident.ToList<Resident>().Where(r => r.Deleted == null || r.Deleted == false);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
