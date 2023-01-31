﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Resident
{
    public class ViewModelResident
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string UserEmail { get; set; }
        [Required]
        [Display(Name="House Number")]
        public int HouseNumber { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Person Count")]
        public int PersonCount { get; set; }
        [Required]
        [Display(Name = "Cars Count")]
        public int CarsCount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Started Date")]
        public DateTime StartedDate { get; set; }
        [Required]
        [Display(Name = "House State")]
        public string HouseState { get; set; }
        public bool Active {
            get
            {
                return true;
            }        
        }
    }
}
