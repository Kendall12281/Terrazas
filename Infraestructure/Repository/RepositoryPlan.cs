using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryPlan : IRepositoryPlan
    {
        public List<ViewModelIndexPlan> GetPlans()
        {
            try
            {
                List<ViewModelIndexPlan> plans = new List<ViewModelIndexPlan>();
                List<Collection> collections= new List<Collection>();

              MyContext db = new MyContext();

                foreach (var item in db.Plan.ToList())
                {
                    //collectionPlans = db.CollectionPlan.ToList().Where(x => x.IdPlan == item.Id).ToList();

                    foreach (var collectionPlanItem in db.CollectionPlan.ToList().Where(x => x.IdPlan == item.Id).ToList())
                    {
                        collections.Add(db.Collection.Find(collectionPlanItem.IdCollection));
                    }

                    ViewModelIndexPlan viewModelPlan = new ViewModelIndexPlan()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        listCollections = new List<Collection>(collections)
                    };

                    plans.Add(viewModelPlan);
                    collections.Clear();

                }

                return plans;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void NewPlan(Plan plan, IEnumerable<CollectionPlan> collectionPlanList)
        {
            try
            {
                MyContext db = new MyContext();
                db.Plan.Add(plan);
                db.SaveChanges();


                foreach (var item in collectionPlanList)
                {
                    using (MyContext db2 = new MyContext())
                    {

                        item.IdPlan = plan.Id;
                        db2.CollectionPlan.Add(item);
                        db2.SaveChanges();

                    }

                }
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
