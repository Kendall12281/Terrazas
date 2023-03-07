using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                using (MyContext db = new MyContext())
                {
                    db.Collection.AddOrUpdate(collection);
                    db.SaveChanges();
                }
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
                using (MyContext db = new MyContext())
                {
                    return db.Collection.Find(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Collection> GetCollections()
        {
            IEnumerable<Collection> collection = null;
            try
            {
                using (MyContext db = new MyContext())
                {

                    collection = db.Collection.Where(x => x.Active != false).ToList();
                }

                return collection;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
