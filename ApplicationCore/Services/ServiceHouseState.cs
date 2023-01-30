using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceHouseState : IServiceHouseState
    {
        public IEnumerable<HouseState> GetHouseStates()
        {
			try
			{
				IRepositoryHouseState repository = new RepositoryHouseState();
				return repository.GetHouseStates();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
