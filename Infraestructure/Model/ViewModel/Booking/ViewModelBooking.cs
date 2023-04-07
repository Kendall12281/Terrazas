using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Booking
{
    public class ViewModelBooking
    {
        [UIHint("DateTime")]
        public DateTime Date { get; set; }
    }
}
