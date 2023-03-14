using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Resident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using Web.Security.Filters;

namespace Web.Controllers
{
    [LoginFilter]
    [AuthorizationFilter]
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

            ViewModelEditResident modelResident = new ViewModelEditResident()
            {
                Id = id,
                UserEmail = resident.EmailUser,
                HouseNumber = resident.HouseNumber,
                Name = resident.Name,
                LastName = resident.LastName,
                PersonCount = resident.PersonCount,
                CarsCount = resident.CarsCount,
                StartedDate = resident.StartedDate,
                HouseState = resident.HouseState,
                Active = resident.Active
            };

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in serviceHouseState.GetHouseStates())
            {
                bool active = false;
                if (resident.HouseState == item.Name) { active = true; }
                SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name, Selected = active };

                items.Add(houseState);
            }

            ViewBag.houseStates = items;

            return View(modelResident);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelEditResident model)
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
                Id = model.Id,
                EmailUser = model.UserEmail,
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
                EmailUser = model.UserEmail,
                HouseNumber = model.HouseNumber,
                Name = model.Name,
                LastName = model.LastName,
                PersonCount = model.PersonCount,
                CarsCount = model.CarsCount,
                StartedDate = model.StartedDate,
                HouseState = model.HouseState,
                Active = true,
                User = new User() { 
                    Email = model.UserEmail,
                    IdRol = 2,
                    Password = "Changeme23.",
                    Active= true,
                }
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
            Resident resident = serviceResident.GetResident(id);
            ViewModelDeleteResident deleteResident = new ViewModelDeleteResident
            {
                Name = resident.Name,
                LastName = resident.LastName,
                UserEmail = resident.EmailUser,
                HouseNumber = resident.HouseNumber,
                PersonCount = resident.PersonCount,
                CarsCount = resident.CarsCount,
                StartedDate = resident.StartedDate,
                HouseState = resident.HouseState,
                Active = resident.Active,
            };
            return View(deleteResident);
        }

        [HttpPost]
        public ActionResult Delete(ViewModelDeleteResident model)
        {
        

            ServiceResident serviceResident = new ServiceResident();
            Resident resident = serviceResident.GetResident(model.Id);
            resident.Deleted = true;   

            ServiceResident service = new ServiceResident();
            service.DeleteResident(resident);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            ServiceResident serviceResident = new ServiceResident();
            ServiceHouseState serviceHouseState = new ServiceHouseState();

            Resident resident = serviceResident.GetResident(id);

            ViewModelEditResident modelResident = new ViewModelEditResident()
            {
                Id = id,
                UserEmail = resident.EmailUser,
                HouseNumber = resident.HouseNumber,
                Name = resident.Name,
                LastName = resident.LastName,
                PersonCount = resident.PersonCount,
                CarsCount = resident.CarsCount,
                StartedDate = resident.StartedDate,
                HouseState = resident.HouseState,
                Active = resident.Active
            };

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var item in serviceHouseState.GetHouseStates())
            {
                bool active = false;
                if (resident.HouseState == item.Name) { active = true; }
                SelectListItem houseState = new SelectListItem() { Text = item.Name, Value = item.Name, Selected = active };

                items.Add(houseState);
            }

            ViewBag.houseStates = items;

            return View(modelResident);
        }
    }
}