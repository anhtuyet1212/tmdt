using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;
namespace tmdt.Controllers
{
    public class HomeController : Controller
    {
        csdlbh db = new csdlbh();
        public PartialViewResult _Slide()
        {
            //Lấy ra 10 sp mới nhất
         var spmoi = db.sps.OrderBy(s => s.ngaydang).Take(10).ToList();
           return PartialView(spmoi);
        }
        //public PartialViewResult _Blog()
        //{
        //    //Lấy ra 10 tt mới nhất
        //    var ttmoi = db.tintucs.OrderBy(s => s.ngaydang).Take(10).ToList();
        //    return PartialView(ttmoi);
        //}
        //public PartialViewResult _Product()
        //{
        //    return PartialView();
        //}

        public ActionResult Index()
        {
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
    }
}