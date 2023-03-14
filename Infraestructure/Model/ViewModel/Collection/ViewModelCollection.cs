using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Collection
{
    public class ViewModelCollection
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public double Total { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
