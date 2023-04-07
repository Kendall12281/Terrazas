using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositorySocialArea
    {
        void NewSocialArea(SocialArea socialArea);
        void NewBooking(Booking booking);
        List<SocialArea> GetSocialAreas();
        SocialArea GetSocialAreaById(int socialAreaId);
        bool GetAvaibility(int startTime, int endTime, DateTime date, int socialAreaId);
    }
}
