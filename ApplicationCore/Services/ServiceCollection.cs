using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCollection : IServiceCollection
    {
        public void AddCollection(Collection collection)
        {
           IRepositoryCollection repository = new RepositoryCollection();
            repository.AddCollection(collection);
        }

        public void DeleteCollection(int id)
        {
            IRepositoryCollection repository = new RepositoryCollection();
            repository.DeleteCollection(id);
        }

        public Collection GetCollection(int id)
        {
            RepositoryCollection respository = new RepositoryCollection();
            return respository.GetCollection(id);
        }

        public IEnumerable<Collection> GetCollections()
        {
            IRepositoryCollection repository = new RepositoryCollection();
            return repository.GetCollections();
        }
    }
}
