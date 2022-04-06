using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;
namespace tmdt.Controllers
{
    public class TintucController : Controller
    {
        csdlbh db = new csdlbh();
        // GET: Tintuc
        public ActionResult _Chitiettintuc(int ma)
        {
            //lấy sản phẩm theo mã
            var tin = db.tintucs.Find(ma);
            ViewBag.tin = db.tintucs.Where(s => s.loaitin == tin.loaitin).Take(4).ToList();
            return View(tin);
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _Blog()
        {
            ViewBag.dstin = db.tintucs.ToList();
            return PartialView();
        }
        public PartialViewResult _dstintuc()
        {
            ViewBag.dstin = db.tintucs.ToList();
            return PartialView();
        }
    }
}