using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositorySocialArea : IRepositorySocialArea
    {
        public bool GetAvaibility(int startTime, int endTime, DateTime date, int socialAreaId)
        {
            bool booking = false;
            try
            {
                using (MyContext db = new MyContext())
                {
                    TimeSpan startTime1 = new TimeSpan(startTime, 0, 0);
                    TimeSpan endTime1 = new TimeSpan(endTime, 0, 0);

                    var list = db.Booking.Where(x => x.IdSocialArea == socialAreaId && x.Date == date &&
                         ((startTime1 >= x.StartTime && startTime1 <= x.EndTime)) &&
                         ((endTime1 >= x.StartTime && endTime1 <= x.EndTime))
                    ).FirstOrDefault();


                    if(list == null) { booking = true; }

                }

            }
            catch (Exception)
            {

            }
            return booking;
        }

        public SocialArea GetSocialAreaById(int socialAreaId)
        {
            SocialArea socialArea = null;
            try
            {
                 using(MyContext db = new MyContext())
                {
                        socialArea =  db.SocialArea.Include("Schedule").Where(x => x.Id == socialAreaId).SingleOrDefault();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return socialArea;
        }

        public List<SocialArea> GetSocialAreas()
        {
            List<SocialArea> list = new List<SocialArea>();
            try
            {
                using (MyContext db = new MyContext())
                {
                    list = db.SocialArea.Include("Schedule").ToList();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return list;
        }

        public void NewBooking(Booking booking)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    db.Booking.Add(booking);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void NewSocialArea(SocialArea socialArea)
        {
            try
            {

                using (MyContext db = new MyContext())
                {
                    db.SocialArea.Add(socialArea);
                    db.SaveChanges();

                }
            }
            catch (Exception ex) { }

        }
    }
}
