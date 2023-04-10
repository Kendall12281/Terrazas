using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.ViewModel.Charge
{
    public class ViewModelCharge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseNumber { get; set; }

        public Infraestructure.Model.Charge Charge { get; set; }
        public int IdPlan { get; set; }

        public string getHtml { get; set; }

        public DateTime Date { get; set; }
       

    }
}
