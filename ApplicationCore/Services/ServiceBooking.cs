using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceBooking : IServiceBooking
    {
        public List<Booking> CheckAvailability(int id,DateTime date)
        {
            IRepositoryBooking repository = new RepositoryBooking();
            return repository.CheckAvailability(id,date);
        }

        public Booking CheckAvailability(string date, int startTime, int endTime)
        {
            throw new NotImplementedException();
        }

        public void CreateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
