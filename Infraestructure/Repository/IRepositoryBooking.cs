using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryBooking
    {
        List<Booking> CheckAvailability(int id, DateTime date);
        Booking CheckAvailability(string date,int startTime, int endTime);
        void CreateBooking(Booking booking);
        
    }
}
