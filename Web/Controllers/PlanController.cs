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

            List<CollectionPlan> list = new List<CollectionPlan>();

            foreach (var item in model.listCollections)
            {
                CollectionPlan collectionPlan = new CollectionPlan()
                {
                    IdCollection = int.Parse(item.Value)
                };
                list.Add(collectionPlan);
            }
            ServicePlan service = new ServicePlan();
            service.NewPlan(plan, list);

            return RedirectToAction("/");
        }

        public ActionResult Edit(int id)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServicePlan servicePlan = new ServicePlan();
            ViewModelEditPlan model = servicePlan.GetPlan(id);

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in serviceCollection.GetCollections())
            {
                if (model.listCollections.Contains(item))
                {
                    SelectListItem item1 = new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = true

                    };
                    listItems.Add(item1);
                }
                else
                {

                    SelectListItem item2 = new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = false

                    };
                    listItems.Add(item2);
                }


            }

            




            return View();
        }
    }
}
