using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tmdt.Controllers
{
    public class Banner2Controller : Controller
    {
        // GET: Banner2
       
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _Banner2()
        {
            return PartialView();
        }
    }
}