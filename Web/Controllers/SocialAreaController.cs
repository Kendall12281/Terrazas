using ApplicationCore.Services;
using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Security.Filters;

namespace Web.Controllers
{
    [LoginFilter]
    [AuthorizationFilter]
    public class SocialAreaController : Controller
    {
        // GET: BookingAdmin
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SocialArea model, HttpPostedFileBase ImageFile)
        {
            ServiceSocialArea service = new ServiceSocialArea();

            model.IdSchedule = 1;

            MemoryStream target = new MemoryStream();
            ImageFile.InputStream.CopyTo(target);
            model.Image = target.ToArray();

            service.NewSocialArea(model);


            return View();
        }
    }
}