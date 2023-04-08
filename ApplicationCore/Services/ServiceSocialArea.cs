using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceSocialArea : IServiceSocialArea
    {
        public void ChangeBookingStatus(int idBooking, bool status)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            repository.ChangeBookingStatus(idBooking, status);
        }

        public List<Booking> GetAllBooking()
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetAllBooking();
        }

        public bool GetAvaibility(int startTime, int endTime, DateTime date, int socialAreaId)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetAvaibility(startTime, endTime, date, socialAreaId);
        }

        public List<Booking> GetBookingById(int residentId)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetBookingById(residentId);
        }

        public List<Booking> GetPendinglBooking()
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetPendinglBooking();
        }

        public SocialArea GetSocialAreaById(int socialAreaId)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetSocialAreaById(socialAreaId);
        }

        public List<SocialArea> GetSocialAreas()
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            return repository.GetSocialAreas();
        }

        public void NewBooking(Booking booking)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            repository.NewBooking(booking);
        }

        public void NewSocialArea(SocialArea socialArea)
        {
            IRepositorySocialArea repository = new RepositorySocialArea();
            repository.NewSocialArea(socialArea);
        }
    }
}
