using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Incident
{
    public class ViewModelIncident
    {
        public int Id { get; set; }
        public int IdResident { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public System.DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public int IdIncidentState { get; set; }

        public IncidentState IncidentState { get; set; }

       public Infraestructure.Model.Resident resident { get; set; }
    }
}
