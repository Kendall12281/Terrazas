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

        public void DeleteCollection(int id)
        {
            try
            {
                using(MyContext db = new MyContext())
                {
                    db.Collection.Find(id).Active = false;
                    db.SaveChanges();
                }
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
                using (MyContext db = new MyContext())
                {

                    return db.Collection.Where(x => x.Active != false).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
