using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryPlan
    {
        void NewPlan(Plan plan, ICollection<Collection> collection);
        List<Plan> GetPlans();

        Plan GetPlan(int id);

        void DeletePlan(int id);

        void EditPlan(Plan plan);

    }
}
