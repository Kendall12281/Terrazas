using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Charge;
using Infraestructure.Model.ViewModel.Plan;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ChargesAdminController : Controller
    {
        // GET: ChargesAdmin
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SelectDate(string date)
        {





                DateTime date1 = DateTime.Parse(date);

                ServiceCharges service = new ServiceCharges();


                List<Resident> charges = service.SelectDate(date1);

                List<ViewModelCharge> chargesModel = new List<ViewModelCharge>();



                ServicePlan servicePlan = new ServicePlan();
                List<ViewModelPlan> plans = new List<ViewModelPlan>();

                foreach (Plan plan in servicePlan.GetPlans())
                {
                    ViewModelPlan newPlan = new ViewModelPlan()
                    {
                        Id = plan.Id,
                        Name = plan.Name,
                        

                    };
                plans.Add(newPlan);
            }



            
            foreach (var item in charges)
                {

                string html = $"<select id=\"selected{item.Id}\">";

                foreach (ViewModelPlan item2 in plans)
                {
                    html += $"<option value=\"{item2.Id}\">{item2.Name}</option>";
                }
                html += "</select>";


                ViewModelCharge model = new ViewModelCharge()
                    {
                        Id = item.Id,
                        HouseNumber = item.HouseNumber,
                        Name = item.Name,
                        getHtml = html
                        
                    };

                    chargesModel.Add(model);
                }


            ViewBag.date = date1;


                //return Json(chargesModel, JsonRequestBehavior.AllowGet);
                return View(chargesModel);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SaveCharges([FromBody]  List<ViewModelCharge> list)
        {


            ServicePlan servicePlan = new ServicePlan();
            ServiceCharges serviceCharges = new ServiceCharges();
            List<Charge> charges = new List<Charge>();

            foreach (ViewModelCharge item in list)
            {
                ViewModelIndexPlan viewModelPlan = new ViewModelIndexPlan()
                {
                    listCollections = servicePlan.GetPlan(item.IdPlan).Collection.ToList()
                };

                Charge charge = new Charge()
                {
                    IdPlan = item.IdPlan,
                    IdResident = item.Id,
                    Year = item.Date.Year,
                    Month = item.Date.Month,
                    Total = viewModelPlan.Total

                };
                charges.Add(charge);
            }
            
            serviceCharges.SaveCharges(charges);

            return View();
        }

        public ActionResult DataTables()
        {
            return View();
        }

        public ActionResult DataTable(string date) {

            

                


                DateTime date1 = DateTime.Parse(date);

                ServiceCharges service = new ServiceCharges();


                List<Resident> charges = service.SelectDate(date1);

                List<ViewModelCharge> chargesModel = new List<ViewModelCharge>();



                ServicePlan servicePlan = new ServicePlan();
                List<ViewModelPlan> plans = new List<ViewModelPlan>();

                foreach (Plan plan in servicePlan.GetPlans())
                {
                    ViewModelPlan newPlan = new ViewModelPlan()
                    {
                        Id = plan.Id,
                        Name = plan.Name,

                    };
                    plans.Add(newPlan);

                }


                foreach (var item in charges)
                {
                    ViewModelCharge model = new ViewModelCharge()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        HouseNumber = item.HouseNumber,
                    };
                    chargesModel.Add(model);
                }





            //return Json(chargesModel, JsonRequestBehavior.AllowGet);
            //return View(chargesModel);

            return PartialView("", chargesModel);
            
        }


    }
}