using DataAnnotation.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ModelForView modelForView = new ModelForView();
            return View(modelForView);
        }

        [HttpPost]
        public ActionResult modifyPerson(ModelForView model)
        {
            
            return View(model);
        }

    }
}