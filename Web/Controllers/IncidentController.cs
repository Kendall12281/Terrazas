using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Incident;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Web.Security.Filters;

namespace Web.Controllers
{
    [LoginFilter]
    public class IncidentController : Controller
    {
        // GET: Incident
        public ActionResult Index()
        {
            Infraestructure.Model.Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
            ServiceIncident service = new ServiceIncident();

            List<ViewModelIncident> list = new List<ViewModelIncident>();
            foreach (Incident inc in service.GetIncidentsByIdResident(resident.Id))
            {
                list.Add(new ViewModelIncident()
                {
                    Id = inc.Id,
                    IncidentState = inc.IncidentState,
                    Title = inc.Title
                });
            }

            return View(list);


        }
        public ActionResult NewIncident()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewIncident(ViewModelIncident model, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                Infraestructure.Model.Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
                ServiceIncident service = new ServiceIncident();

                if (ImageFile != null)
                {
                    MemoryStream target = new MemoryStream();
                    ImageFile.InputStream.CopyTo(target);
                    Incident incident = new Incident()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        IdResident = resident.Id,
                        Image = target.ToArray(),
                        IdIncidentState = 1
                    };
                    ModelState.Remove("Image");
                    service.NewIncident(incident);
                }
                else
                {
                    Incident incident = new Incident()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        IdResident = resident.Id,
                        IdIncidentState = 1
                    };
                    service.NewIncident(incident);
                }


                return RedirectToAction("/");
            }
            else
            {
                return View(model);
            }


        }

        public ActionResult Detail(int id)
        {
            ServiceIncident service = new ServiceIncident();
            var incident = service.GetIncidentById(id);

            ViewModelIncident incidentModel = new ViewModelIncident()
            {
                Id = id,
                Title = incident.Title,
                Description = incident.Description,
                Image = incident.Image,
                resident = incident.Resident,
                IncidentState = incident.IncidentState
            };

            return View(incidentModel);
        }

        public ActionResult AllIncidents()
        {
            Infraestructure.Model.Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
            ServiceIncident service = new ServiceIncident();

            List<ViewModelIncident> list = new List<ViewModelIncident>();
            foreach (Incident inc in service.GetIncidents())
            {
                list.Add(new ViewModelIncident()
                {
                    Id = inc.Id,
                    IncidentState = inc.IncidentState,
                    resident = inc.Resident,
                    Title = inc.Title
                    
                });
            }
            return View(list);


         }

        public ActionResult Solved(int id)
        {
            ServiceIncident service = new ServiceIncident();
            service.MarkIncidentAsSolved(id);
            return RedirectToAction("AllIncidents");

        }
    }
}