using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCharges : IServiceCharges
    {
        public void SaveCharges(List<Charge> charges)
        {
            RepositoryCharges repository = new RepositoryCharges();
            repository.SaveCharges(charges);
        }

        public List<Resident> SelectDate(DateTime date)
        {
            RepositoryCharges repository = new RepositoryCharges();
           return  repository.SelectDate(date);
        }
    }
}
