using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryHouseState : IRepositoryHouseState
    {
        public IEnumerable<HouseState> GetHouseStates()
        {
			try
			{
				MyContext db = new MyContext();
				return db.HouseState.ToList();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
