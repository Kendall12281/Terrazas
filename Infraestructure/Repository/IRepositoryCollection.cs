using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryCollection
    {
        void AddCollection(Collection collection);
        IEnumerable<Collection> GetCollections();
        Collection GetCollection(int id);
        void DeleteCollection(int id);

    }
}
