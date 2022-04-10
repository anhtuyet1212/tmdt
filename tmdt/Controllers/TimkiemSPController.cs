using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;
using PagedList;

namespace tmdt.Controllers
{
    public class TimkiemSPController : Controller
    {
        // GET: TimkiemSP
        csdlbh db = new csdlbh();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult search(int? page)
        {
            ViewBag.dsloai = db.loaisps.ToList();
            ViewBag.dssp = db.sps.ToList();
            
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(db.sps.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]      
        public ActionResult search(int? page, string keyword)
        {
            var dssp = db.sps.Where(s => s.ten.Contains(keyword)).ToList();
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(dssp.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult _Producttk()
        {
            ViewBag.dsloai = db.loaisps.ToList();
            ViewBag.dssp = db.sps.ToList();
            return PartialView();
        }
    }
}