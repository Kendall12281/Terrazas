using ApplicationCore.Services;
using Infraestructure.Model.ViewModel.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.Security.Filters;

namespace Web.Controllers
{
    [LoginFilter]
    [AuthorizationFilter]
    public class SocialAreaAdminController : Controller
    {
        // GET: SocialAreaAdmin
        public ActionResult Index()
        {
            ServiceSocialArea service = new ServiceSocialArea();

            List<ViewModelShowBooking> list = new List<ViewModelShowBooking>();

            foreach (var item in service.GetAllBooking())
            {
                ViewModelShowBooking model = new ViewModelShowBooking()
                {
                    HouseNumber = item.Resident.HouseNumber,
                    Name = item.SocialArea.Name,
                    date = item.Date,
                    startDate = item.StartTime,
                    endDate = item.EndTime,
                    confirmed = item.Confirmed

                };

                list.Add(model);
            }

            return View(list);
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