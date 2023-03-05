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
        public void DeletePlan(int id)
        {
            IRepositoryPlan service = new RepositoryPlan();
             service.DeletePlan(id);
        }

        public void EditPlan(Plan plan)
        {
            IRepositoryPlan planRepository = new RepositoryPlan();
            planRepository.EditPlan(plan);
        }

        public Plan GetPlan(int id)
        {
            IRepositoryPlan service = new RepositoryPlan();
            return service.GetPlan(id);
        }

        public List<Plan> GetPlans()
        {
            IRepositoryPlan repository = new RepositoryPlan();
            return repository.GetPlans();
        }

        public void NewPlan(Plan plan, ICollection<Collection> collection)
        {
            IRepositoryPlan repository= new RepositoryPlan();
            repository.NewPlan(plan, collection);
        }
    }
}
