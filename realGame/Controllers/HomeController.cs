using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace realGame.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         //return RedirectToAction("Index", "Games");
         return View();
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

      public ActionResult ToDo()
      {
         return View();
      }

      public ActionResult HowTo()
      {
         return View();
      }

      public ActionResult Browse()
      {
         return View();
      }
   }
}