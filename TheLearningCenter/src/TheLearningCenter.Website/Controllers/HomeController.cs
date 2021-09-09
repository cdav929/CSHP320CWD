using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLearningCenter.Business;
using TheLearningCenter.Website.Models;

namespace TheLearningCenter.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var classes = ClassManager.Classes
                                       .Select(t => new TheLearningCenter.Website.Models.ClassModel(t.Id, t.Name))
                                    .ToArray();
             var model = new IndexModel { Classes = classes };
             return View(model);
            //return View();
        }



        private readonly IClassManager ClassManager;
        public HomeController(IClassManager ClassManager)
        {
            this.ClassManager = ClassManager;
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}