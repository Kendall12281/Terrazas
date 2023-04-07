using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Information;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.Security.Filters;

namespace Web.Controllers
{

    [LoginFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Information(int id)
        {
            ServiceInformation service = new ServiceInformation();
            return View(service.GetInformationByTypeId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModelInformation model, HttpPostedFileBase ImageFile)
        {

            if (ModelState.IsValid)
            {
                ServiceInformation service = new ServiceInformation();
                Infraestructure.Model.Information information = new Infraestructure.Model.Information()
                {
                    Title = model.Title,
                    Date = model.Date,
                    Description = model.Description
                };

                switch (model.InformationTypeString)
                {
                    case "News":
                        information.IdInformationType = 1;
                        break;
                    case "Reminders":
                        information.IdInformationType = 2;
                        break;
                    case "Documents":
                        information.IdInformationType = 3;
                        break;
                }
                Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
                if (resident != null) { information.IdResident = resident.Id; } else { information.IdResident = 1; }
                if (ImageFile != null)
                {
                    MemoryStream target = new MemoryStream();
                    ImageFile.InputStream.CopyTo(target);
                    information.Image = target.ToArray();
                }

                service.CreateInformation(information);
                return RedirectToAction("/");
            }
            else
            {
                return View(model);


            }
        }


        public ActionResult InformationResident(int id)
        {
            ServiceInformation service = new ServiceInformation();
            return View(service.GetInformationByResidentId(id));
        }

        public ActionResult Detail(int id)
        {
            ServiceInformation service = new ServiceInformation();
            Information information = service.GetInformationById(id);
            
            ViewModelInformation model = new ViewModelInformation()
            {
                Id = information.Id,
                Title = information.Title,
                Description = information.Description,
                IdInformationType = information.IdInformationType,
                Image = information.Image

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(ViewModelInformation model, HttpPostedFileBase ImageFile)
        {
            if(ModelState.IsValid)
            {
                ServiceInformation service = new ServiceInformation();
                Infraestructure.Model.Information information = new Infraestructure.Model.Information()
                {
                    Id  = model.Id,
                    Title = model.Title,
                    Date = model.Date,
                    Description = model.Description
                };

                switch (model.InformationTypeString)
                {
                    case "News":
                        information.IdInformationType = 1;
                        break;
                    case "Reminders":
                        information.IdInformationType = 2;
                        break;
                    case "Documents":
                        information.IdInformationType = 3;
                        break;
                }
                Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
                if (resident != null) { information.IdResident = resident.Id; } else { information.IdResident = 1; }
                if (ImageFile != null)
                {
                    MemoryStream target = new MemoryStream();
                    ImageFile.InputStream.CopyTo(target);
                    information.Image = target.ToArray();
                }
                else
                {  
                    information.Image = service.GetInformationById(model.Id).Image;
                }

                service.UpdateInformation(information);
                return RedirectToAction("/");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}