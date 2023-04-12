using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Booking
{
    public class ViewModelShowBooking
    {

        public string Name { get; set; }
        public int HouseNumber { get; set; }
        public DateTime date { get; set; }
        public string dateString
        {
            get
            {
                return date.ToString("d");
            }
        }
        public TimeSpan startDate { get; set; }
        public TimeSpan endDate { get; set; }

        public bool? confirmed { get; set; }

        public string confirmedString
        {
            get
            {
                string result = "Yes";
                if(confirmed == null) { result = "Pending"; }
                if(confirmed == false) { result = "No"; }


                return result;
            }
        }
    }
}
