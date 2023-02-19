using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Account
{
    public class ViewModelAccount
    {
        public int Id { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Month")]
        public int month { get; set; }
        [Display(Name = "Year")]
        public int year { get; set; }
        [Display(Name = "Total")]
        public double total { get; set; }
        public string PlanName { get; set; }
        [Display(Name = "Collection")]
        public IEnumerable<Infraestructure.Model.Collection> collection { get; set; }
        [Display(Name = "Cancelled")]
        public bool cancelled { get; set; }
        [Display(Name = "Notes")]
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
