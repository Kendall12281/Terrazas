using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePlan : IServicePlan
    {
        public ViewModelEditPlan GetPlan(int id)
        {
            IRepositoryPlan service = new RepositoryPlan();
            return service.GetPlan(id);
        }

        public List<ViewModelIndexPlan> GetPlans()
        {
            IRepositoryPlan repository = new RepositoryPlan();
            return repository.GetPlans();
        }

        public void NewPlan(Plan plan, IEnumerable<CollectionPlan> collectionPlanList)
        {
            IRepositoryPlan repository= new RepositoryPlan();
            repository.NewPlan(plan, collectionPlanList);
        }
    }
}
