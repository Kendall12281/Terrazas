using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            ServicePlan service = new ServicePlan();

            return View(service.GetPlans());
        }
        public ActionResult New()
        {
            ServiceCollection service = new ServiceCollection();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in service.GetCollections())
            {
                SelectListItem item1 = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = false,

                };
                listItems.Add(item1);
            }

            ViewModelNewPlan plan = new ViewModelNewPlan()
            {
                Name = "",
                Description = "",
                listCollections = listItems
            };

            return View(plan);
        }

        [HttpPost]
        public ActionResult New(ViewModelNewPlan model)
        {

            ServiceCollection  serviceCollection= new ServiceCollection();
            int count = 0;
            foreach (var item in model.listCollections)
            {
                if (item.Selected) count++;
            }

            if (!ModelState.IsValid || count <= 0)
            {
                return View(model);
            }

            Plan plan = new Plan()
            {
                Name = model.Name,
                Description = model.Description
            };


            foreach (var item in model.listCollections)
            {

                plan.Collection.Add(serviceCollection.GetCollection(int.Parse(item.Value)));
            }

            ServicePlan service = new ServicePlan();
            service.NewPlan(plan);

            return RedirectToAction("/");
        }

        public ActionResult Edit(int id)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServicePlan servicePlan = new ServicePlan();
            Plan model = servicePlan.GetPlan(id);

            List<SelectListItem> listItems = new List<SelectListItem>();

            return View(model);
        }

      
        public ActionResult Delete(int id)
        {
            ServicePlan serviceCollection = new ServicePlan();
            serviceCollection.DeletePlan(id);

            return RedirectToAction("/");
        }
    }
}
