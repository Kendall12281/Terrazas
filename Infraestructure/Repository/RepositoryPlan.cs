using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryPlan : IRepositoryPlan
    {
        public void DeletePlan(int id)
        {
            try
            {
                MyContext db = new MyContext();

                db.Plan.Find(id).Active = false;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Plan GetPlan(int id)
        {
            try
            {

                MyContext db = new MyContext();
                Plan plan = db.Plan.Find(id);
                return plan;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Plan> GetPlans()
        {
            try
            {
                List<ViewModelIndexPlan> plans = new List<ViewModelIndexPlan>();
                List<Collection> collections = new List<Collection>();

                MyContext db = new MyContext();

                var a = db.Plan
                    .Include("Collection")
                    .Where(x => x.Active != false)
                    .ToList();

                return a;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void NewPlan(Plan plan)
        {
            try
            {
                
                MyContext db = new MyContext();
                 db.Plan.Add(new Plan { Name = plan.Name, Description = plan.Description });
                db.SaveChanges();

                var addedPlan = db.Plan.OrderByDescending(p => p.Id).FirstOrDefault(p => p.Name == plan.Name);

                foreach (var item in plan.Collection)
                {
                    
                    db.Database.ExecuteSqlCommand("Insert into CollectionPlan Values ("+addedPlan.Id+","+item.Id+")");
                }
            }

            catch (Exception)
            {

                throw;
            }
        }
    }

    public class CollectionPlan
    {
        public int IdPlan { get; set; }
        public int IdCollection { get; set; }
    }
}
