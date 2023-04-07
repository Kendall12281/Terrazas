using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryBooking : IRepositoryBooking
    {
        public List<Booking> CheckAvailability(int id,DateTime date)
        {
            List<Booking> list = new List<Booking>();
            try
            {

                using (MyContext db = new MyContext())
                {
                    var result = db.Booking.Include("SocialArea").Where(x => x.Id == id && x.Date == date).ToList();
                    
                    if(result.Count > 0)
                    {
                        list = result;
                    }
                    else
                    {
                        list = db.Booking.Include("SocialArea").Where(x=>x.Id == id).ToList();
                    }
                }
            }
            catch (Exception err)
            {

            }
            return list;
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
