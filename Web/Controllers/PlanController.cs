using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Plan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Security.Filters;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Web.Controllers
{
    [LoginFilter]
    [AuthorizationFilter]
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            ServicePlan service = new ServicePlan();
            List<ViewModelIndexPlan> planModel = new List<ViewModelIndexPlan>();
            foreach (var item in service.GetPlans())
            {
                ViewModelIndexPlan planModelIndex = new ViewModelIndexPlan()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    listCollections = item.Collection.ToList()
                };
                planModel.Add(planModelIndex);
            }

            return View(planModel);
        }
        public ActionResult New()
        {
            ServiceCollection service = new ServiceCollection();
            List<SelectListItem> listItems = new List<SelectListItem>();

            var list = service.GetCollections();

            foreach (var item in list)
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

            ServiceCollection serviceCollection = new ServiceCollection();
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

            int counter = 0;
            List<Collection> list = new List<Collection>();
            foreach (var item in serviceCollection.GetCollections())
            {
                if (counter < model.listCollections.Count)
                {

                    if (model.listCollections[counter].Selected)
                    {
                        list.Add(serviceCollection.GetCollection(int.Parse(model.listCollections[counter].Value)));

                    }
                }

                counter++;

            }

            ServicePlan service = new ServicePlan();
            service.NewPlan(plan, list);

            return RedirectToAction("/");
        }

        public ActionResult Edit(int id)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServicePlan servicePlan = new ServicePlan();
            Plan model = servicePlan.GetPlan(id);


            List<SelectListItem> listItems = new List<SelectListItem>();

            int i = 0;
            foreach (var item in serviceCollection.GetCollections())
            {
                if (model.Collection.Count > i)
                {
                    if (model.Collection.ElementAt(i).Name == item.Name)
                    {
                        listItems.Add(new SelectListItem() { Text = item.Name, Selected = true, Value = item.Id.ToString() });
                    }
                    else
                    {
                        listItems.Add(new SelectListItem() { Text = item.Name, Selected = false, Value = item.Id.ToString() });
                    }
                }
                else
                {
                    listItems.Add(new SelectListItem() { Text = item.Name, Selected = false, Value = item.Id.ToString() });
                }

                i++;
            }

            ViewModelEditPlan modelEditPlan = new ViewModelEditPlan()
            {
                Id = model.Id,
                Description = model.Description,
                listSelectedItems = listItems,
                Name = model.Name
            };



            return View(modelEditPlan);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelEditPlan model)
        {
            if (ModelState.IsValid)
            {

                ICollection<Collection> list = new List<Collection>();

                foreach (var item in model.listSelectedItems)
                {
                    if (item.Selected)
                    {

                        ServiceCollection serviceCollection = new ServiceCollection();
                        int id = int.Parse(item.Value);
                        Collection collection = serviceCollection.GetCollection(id);
                        list.Add(collection);
                    }
                }
                Plan plan = new Plan
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Collection = list


                };

                ServicePlan service = new ServicePlan();
                service.EditPlan(plan);

                return RedirectToAction("/");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(Plan plan)
        {
            ServicePlan serviceCollection = new ServicePlan();
            serviceCollection.DeletePlan(plan.Id);
            return RedirectToAction("/");
        }

        public ActionResult Delete(int id)
        {
            ServicePlan serviceCollection = new ServicePlan();


            return View(serviceCollection.GetPlan(id));
        }

        public ActionResult Detail(int id)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServicePlan servicePlan = new ServicePlan();
            Plan model = servicePlan.GetPlan(id);


            return View(model);
        }
    }

}
