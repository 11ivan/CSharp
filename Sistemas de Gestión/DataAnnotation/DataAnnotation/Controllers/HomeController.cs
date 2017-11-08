using DataAnnotation.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace DataAnnotation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            /*if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                //ModelForView2 modelForView2 = new ModelForView2();
                //modelForView2.nombre = model.nombre;
                return View("ModifyPerson");
            }*/
            HtmlInputPassword htmlInputPassword = new HtmlInputPassword();
            ModelForView modelForView = new ModelForView();
            //Page.Controls.Add(htmlInputPassword);
            
            
            return View(modelForView);
        }     

        [HttpPost]
        public ActionResult Index(ModelForView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                ModelForView2 modelForView2 = new ModelForView2();
                modelForView2.nombre = model.nombre;
                return View("ModifyPerson", modelForView2);
            }                                     
        }

    }
}