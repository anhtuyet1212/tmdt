using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Khai báo sử dụng model
using tmdt.Models;
namespace tmdt.Controllers
{
    public class SanphamController : Controller
    {
        //Khai báo dbcontext
        csdlbh db = new csdlbh();
        // GET: Sanpham
        public ActionResult Chitiet(int ma)
        {
            //Lấy sp theo mã
            var sanp = db.sps.Find(ma);
            ViewBag.spcungloai = db.sps.Where(s => s.maloai == sanp.maloai).Take(4).ToList();
            return View(sanp);
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _Product()
        {
            ViewBag.dsloai = db.loaisps.ToList();
            ViewBag.dssp = db.sps.ToList();
            return PartialView();
        }

    }
}