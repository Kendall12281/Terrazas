using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Account
{
    public class ViewModelAccount
    {
        public string email { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public double total { get; set; }
        public bool cancelled { get; set; }
        public string notes { get; set; } = "Empty notes";
        public string fullName { get { return name + " " + lastName; } }
        public string monthName
        {
            get
            {
                DateTime date = new DateTime(2022, 2, month);
                return date.ToString("MMMM", CultureInfo.CurrentCulture);
            }
        }

        public string totalColones { get { return "₡ " + total; } }

        public string cancelledName { get { return cancelled ? "Yes" : "No"; } }

        public string toString
        {
            get
            {
                return (email,fullName,monthName,year,totalColones,cancelledName,notes).ToString();
            }
        }
    }
}
