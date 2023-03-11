using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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
                using (MyContext db = new MyContext())
                {

                    db.Plan.Find(id).Active = false;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditPlan(Plan plan)
        {
            try
            {
                using (MyContext db = new MyContext())
                {
                    List<Collection> collectionPlan = new List<Collection>();
                    foreach (Collection item in plan.Collection)
                    {
                        collectionPlan.Add(item);
                    }
                    plan.Collection.Clear();
                    db.Plan.Add(plan);
                    db.Entry(plan).State = EntityState.Modified;
                    db.SaveChanges();

                    string[] selected = new string[collectionPlan.Count()];

                    for(int i = 0; i < collectionPlan.Count(); i++)
                    {
                        selected[i] = collectionPlan.ElementAt(i).Id.ToString();
                    }


                    var selectedCollection = new HashSet<string>(selected);
                    db.Entry(plan).Collection(p => p.Collection).Load();
                    var newCollection = db.Collection
                        .Where(x => selectedCollection.Contains(x.Id.ToString())).ToList();

                    plan.Collection = newCollection;

                    db.Entry(plan).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Plan GetPlan(int id)
        {
            Plan plan = null;
            try
            {

                using (MyContext db = new MyContext())
                {
                     plan = db.Plan.Where(x=>x.Id == id).Include("Collection").FirstOrDefault();
                }
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

                using (MyContext db = new MyContext())
                {

                    var a = db.Plan
                        .Include("Collection")
                        .Where(x => x.Active != false)
                        .ToList();

                    return a;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void NewPlan(Plan plan, ICollection<Collection> collection)
        {
            try
            {

                using (MyContext db = new MyContext())
                {




                    RepositoryCollection repositoryCollection = new RepositoryCollection();

                    foreach (var collectionItem in collection)
                    {
                        db.Collection.Attach(collectionItem);
                        plan.Collection.Add(collectionItem);
                    }



                    db.Plan.Add(plan);

                    db.SaveChanges();


                }

            }

            catch (Exception)
            {

                throw;
            }
        }
    }



}
