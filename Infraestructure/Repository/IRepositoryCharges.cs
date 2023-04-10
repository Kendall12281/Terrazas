using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Model;

namespace Infraestructure.Repository
{
    public interface IRepositoryCharges
    {
        List<Resident> SelectDate(DateTime date);
        void SaveCharges(List<Charge> charges);

    }
}
