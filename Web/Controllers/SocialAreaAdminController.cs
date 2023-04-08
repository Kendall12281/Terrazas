using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Web.Controllers
{
    public class SocialAreaAdminController : Controller
    {
        // GET: SocialAreaAdmin
        public ActionResult Index()
        {
            ServiceSocialArea service = new ServiceSocialArea();

            return View(service.GetAllBooking());
        }

        public ActionResult PendingBooking()
        {
            ServiceSocialArea service = new ServiceSocialArea();

            return View(service.GetPendinglBooking());
        }

        public ActionResult Accept(int id)
        {
            ServiceSocialArea service = new ServiceSocialArea();
            service.ChangeBookingStatus(id, true);

            return RedirectToAction("PendingBooking");
        }
        public ActionResult Deny(int id)
        {
            ServiceSocialArea service = new ServiceSocialArea();
            service.ChangeBookingStatus(id, false);

            return RedirectToAction("PendingBooking");
        }


    }
}