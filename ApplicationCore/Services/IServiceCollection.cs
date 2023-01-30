using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceCollection
    {
        void AddCollection(Collection collection);
        IEnumerable<Collection> GetCollections();
        Collection GetCollection(int id);

    }
}
