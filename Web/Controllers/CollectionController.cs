using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            ServiceCollection service = new ServiceCollection();
            return View(service.GetCollections());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(ViewModelCollection model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Collection collection = new Collection()
            {
                Name = model.Name,
                Description = model.Description
            };

            ServiceCollection service = new ServiceCollection();
            service.AddCollection(collection);

            return RedirectToAction("/");
        }

        public ActionResult Edit(int id)
        {
            ServiceCollection service = new ServiceCollection();
            Collection collection = service.GetCollection(id);

            ViewModelCollection model = new ViewModelCollection()
            {
                Name = collection.Name,
                Description = collection.Description
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelCollection model) 
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Collection collection = new Collection()
            {
                Id= model.Id,
                Name = model.Name,
                Description = model.Description
            };
            ServiceCollection service = new ServiceCollection();
            service.AddCollection(collection);

            return RedirectToAction("/");
        }


    }
}