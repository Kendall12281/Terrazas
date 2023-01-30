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

        public void DeleteResident(Resident resident)
        {
			try
			{
                MyContext db = new MyContext();
				db.Resident.Attach(resident);
				db.Resident.Remove(resident);
				db.SaveChanges();
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
				return db.Resident.ToList();
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
