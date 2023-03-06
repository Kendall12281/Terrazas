using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infraestructure.Model.ViewModel.Information
{
    public class ViewModelInformation
    {
        public int Id { get; set; }
        public int IdResident { get; set; }
        public int IdInformationType { get; set; }
        public string InformationTypeString { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime Date { get; set; }
        public byte[] Image { get; set; }

        
    }
}
