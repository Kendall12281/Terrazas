using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infraestructure.Model.ViewModel.Plan
{
    public class ViewModelNewPlan
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Collection List")]
        [Required]
        public List<SelectListItem> listCollections { get; set; }

    }
}
