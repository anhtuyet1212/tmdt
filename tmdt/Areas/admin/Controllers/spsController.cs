using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;
using PagedList;//khai báo sử dụng page list

namespace tmdt.Areas.admin.Views
{
    public class spsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/sps
        
        public ActionResult Timkiem(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = page ?? 1;
            return View(db.sps.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Timkiem(int? page, string keyword)
        {
            var dssp=db.sps.Where(s=>s.ten.Contains(keyword)).ToList();
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);           
            return View(dssp.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var sps = db.sps.Include(s => s.loaisp);
            return View(db.sps.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult GetPaging(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(db.sps.OrderBy(s => s.ma).ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult Index()
        //{
        //    var sps = db.sps.Include(s => s.loaisp);
        //    return View(sps.ToList());
        //}

        // GET: admin/sps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sp sp = db.sps.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        //public List<sp> SearchByKey(string key)
        //{
        //    return db.sps.SqlQuery("Select * from sp where like ma '%"+key+"%'").ToList();
        //}
        // GET: admin/sps/Create
        public ActionResult Create()
        {
            //  ViewBag.maloai = new SelectList(db.loaisps, "ma", "ten");
            ViewBag.ml = null;
            ViewBag.maloai = db.loaisps.ToList();
            return View();
        }

        // POST: admin/sps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ma,ten,mota,maloai,anhnho,anh1,anh2,anh3,tskt,tieubieu,trangthai,xoa,hang,gia,khuyenmai,ngaydang,dvt")] sp sp)
        {
           /// if (ModelState.IsValid)
           // {
                db.sps.Add(sp);
                ViewBag.ml = sp.maloai;
            ViewBag.maloai = db.loaisps.ToList();
            db.SaveChanges();
            return RedirectToAction("Index");
           // }

            
          //  return View(sp);
        }

        // GET: admin/sps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sp sp = db.sps.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.maloai = new SelectList(db.loaisps, "ma", "ten", sp.maloai);
            return View(sp);
        }

        // POST: admin/sps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ma,ten,mota,maloai,anhnho,anh1,anh2,anh3,tskt,tieubieu,trangthai,xoa,hang,gia,khuyenmai,ngaydang,dvt")] sp sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maloai = new SelectList(db.loaisps, "ma", "ten", sp.maloai);
            return View(sp);
        }

        // GET: admin/sps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sp sp = db.sps.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        // POST: admin/sps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sp sp = db.sps.Find(id);
            db.sps.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
