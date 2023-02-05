using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePlan
    {
        List<ViewModelIndexPlan> GetPlans();
        void NewPlan(Plan plan, IEnumerable<CollectionPlan> collectionPlanList);
    }
}
