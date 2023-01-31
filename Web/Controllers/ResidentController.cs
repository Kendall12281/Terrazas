using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Resident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ResidentController : Controller
    {

        // GET: Resident
        public ActionResult Index()
        {
            IEnumerable<Resident> list;
            try
            {
                ServiceResident service = new ServiceResident();
                list = service.GetResidents();
            }
            catch (Exception)
            {

                throw;
            }
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                RedirectToAction("Index");
            }
            ServiceResident serviceResident = new ServiceResident();
            ServiceHouseState serviceHouseState = new ServiceHouseState();

            Resident resident = serviceResident.GetResident(id);

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in serviceHouseState.GetHouseStates())
            {
                bool active = false;
                if (resident.HouseState == item.Name) { active = true; }
                SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name, Selected = active };

                items.Add(houseState);
            }

            ViewBag.houseStates = items;

            return View(resident);
        }

        public ActionResult Add(Resident resident)
        {
            //if (ModelState.IsValid)
            //{
            ServiceResident service = new ServiceResident();
            service.AddResident(resident);
            return RedirectToAction("Index");
            //}



        }

        //[HttpPost]
        //public ActionResult Add02(ViewModelResident model)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    Resident resident = new Resident()
        //    {
        //        UserEmail = model.UserEmail,
        //        HouseNumber = model.HouseNumber,
        //        Name = model.Name,
        //        LastName = model.LastName,
        //        PersonCount = model.PersonCount,
        //        CarsCount = model.CarsCount,
        //        StartedDate = model.StartedDate,
        //        HouseState = model.HouseState,
        //        Active = model.Active
        //    };
        //    ServiceResident service = new ServiceResident();
        //    service.AddResident(resident);
        //    return RedirectToAction("/");
        //}


        //public ActionResult New()
        //{
        //    ServiceHouseState serviceHouseState = new ServiceHouseState();
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    foreach (var item in serviceHouseState.GetHouseStates())
        //    {
        //        SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name };

        //        items.Add(houseState);
        //    }

        //    ViewBag.houseStates = items;
        //    return View();
        //}

        public ActionResult New()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            ServiceHouseState serviceHouseState = new ServiceHouseState();
            foreach (var item in serviceHouseState.GetHouseStates())
            {
                SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name };

                items.Add(houseState);
            }

            ViewBag.houseStates = items;
            return View();
        }
        [HttpPost]
        public ActionResult New(ViewModelResident model)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> items = new List<SelectListItem>();

                ServiceHouseState serviceHouseState = new ServiceHouseState();
                foreach (var item in serviceHouseState.GetHouseStates())
                {
                    SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name };

                    items.Add(houseState);
                }

                ViewBag.houseStates = items;
                return View(model);
            }
            Resident resident = new Resident()
            {
                UserEmail = model.UserEmail,
                HouseNumber = model.HouseNumber,
                Name = model.Name,
                LastName = model.LastName,
                PersonCount = model.PersonCount,
                CarsCount = model.CarsCount,
                StartedDate = model.StartedDate,
                HouseState = model.HouseState,
                Active = model.Active
            };
            ServiceResident service = new ServiceResident();
            service.AddResident(resident);
            return RedirectToAction("/");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ServiceHouseState serviceHouseState = new ServiceHouseState();
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in serviceHouseState.GetHouseStates())
            {
                SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name };

                items.Add(houseState);
            }

            ViewBag.houseStates = items;

            ServiceResident serviceResident = new ServiceResident();
            return View(serviceResident.GetResident(id));
        }

        [HttpPost]
        public ActionResult Delete(Resident resident)
        {
            ServiceResident service = new ServiceResident();
            service.DeleteResident(resident);
            return RedirectToAction("Index");
        }
    }
}