using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Booking;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            ServiceSocialArea service = new ServiceSocialArea();

            return View(service.GetSocialAreas());
        }

        public ActionResult Book(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetSocialArea(int id, string test)
        {
            ServiceSocialArea service = new ServiceSocialArea();
            SocialArea socialArea = service.GetSocialAreaById(id);


            return Json(socialArea, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckAvaibility(string date, int id)
        {

            ServiceSocialArea service = new ServiceSocialArea();
            SocialArea socialArea = service.GetSocialAreaById(id);

            var data = new
            {
                startTime = socialArea.Schedule.OpenHour,
                endTime = socialArea.Schedule.ClosedHour
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckShedule(string date, int startTime, int endTime, int idSocialArea)
        {
            DateTime date1 = DateTime.Parse(date);
            ServiceSocialArea service = new ServiceSocialArea();
            bool result = service.GetAvaibility(startTime, endTime, date1, idSocialArea);

            var data = new
            {
                busy = result,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PlaceBook(string date, int startTime, int endTime, int idSocialArea)
        {
            Infraestructure.Model.Resident resident = (Infraestructure.Model.Resident)Session["Resident"];
            ServiceSocialArea service = new ServiceSocialArea();
            Booking booking = new Booking
            {
                Date = DateTime.Parse(date),
                StartTime = new TimeSpan(startTime, 0, 0),
                EndTime = new TimeSpan(endTime, 0, 0),
                IdSocialArea = idSocialArea,
                IdResident = resident.Id

            };

            service.NewBooking(booking);

            var data = new
            {
                result = true,
            };


            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}