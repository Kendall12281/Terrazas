using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infraestructure.Model.ViewModel.Resident
{
    public class ViewModelDeleteResident
    {
        public int Id { get; set; }

        
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }
        
        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Person Count")]
        public int PersonCount { get; set; }
        
        [Display(Name = "Cars Count")]
        public int CarsCount { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Started Date")]
        public DateTime StartedDate { get; set; }
        
        [Display(Name = "House State")]
        public string HouseState { get; set; }
        [Display(Name = "Acitve")]
        

        public bool? Active { get; set; }
        public bool Deleted
        {
            get
            {
                return true;
            }
        }
    }
}
