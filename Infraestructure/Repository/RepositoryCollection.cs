using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryCollection : IRepositoryCollection
    {
        public void AddCollection(Collection collection)
        {
			try
			{
				MyContext db = new MyContext();
				db.Collection.AddOrUpdate(collection);
				db.SaveChanges();
			}
			catch (Exception)
			{

				throw;
			}
        }

        public Collection GetCollection(int id)
        {
			try
			{
				MyContext db = new MyContext();
				return db.Collection.Find(id);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public IEnumerable<Collection> GetCollections()
        {
			try
			{
				MyContext db = new MyContext();
				return db.Collection.ToList();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
