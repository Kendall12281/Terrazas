using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["User"] = null;
            Session["Resident"] = null;

            ViewBag.isUserDisabled = false;
            ViewBag.wrongCredentials = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ViewModelLogin model) 
        {           
            if (!ModelState.IsValid) 
            {
                ViewBag.isUserDisabled = false;
                ViewBag.wrongCredentials = false;

                return View(model);
            }
            ServiceLogin service = new ServiceLogin();
            if (!service.IsUserDisabled(model.Email))
            {
                var user = service.SignIn(model.Email, model.Password);
                if (user != null)
                {
                    Session["User"] = user;
                    if(user.IdRol == 2)
                    {
                        ServiceResident serviceResident = new ServiceResident();
                        Session["Resident"] = serviceResident.FindResidentByEmail(model.Email);
                    }
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ViewBag.isUserDisabled = false;
                    ViewBag.wrongCredentials = true;

                    return View(model);
                }
            }
            else
            {
                ViewBag.isUserDisabled = true;
                ViewBag.wrongCredentials = false;

                return View(model);
            }
            return View();
        }

    }
}