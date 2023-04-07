using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceBooking
    {
        List<Booking> CheckAvailability(int id, DateTime date);
        Booking CheckAvailability(string date, int startTime, int endTime);
        void CreateBooking(Booking booking);
    }
}
