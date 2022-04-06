using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tmdt.Controllers
{
    public class Sanpham2Controller : Controller
    {
        // GET: Sanpham2
        public PartialViewResult _Sanpham2()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}