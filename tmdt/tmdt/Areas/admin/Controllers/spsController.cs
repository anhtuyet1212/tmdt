using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;

namespace tmdt.Areas.admin.Controllers
{
    public class spsController : Controller
    {
        private QLBH123Entities db = new QLBH123Entities();

        // GET: admin/sps
        public ActionResult Index()
        {
            var sps = db.sps.Include(s => s.loaisp);
            return View(sps.ToList());
        }

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

        // GET: admin/sps/Create
        public ActionResult Create()
        {
            ViewBag.maloai = new SelectList(db.loaisps, "ma", "ten");
            return View();
        }

        // POST: admin/sps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma,ten,mota,maloai,anhnho,anh1,anh2,anh3,tskt,tieubieu,trangthai,xoa,hang,gia,khuyenmai,ngaydang,dvt")] sp sp)
        {
            if (ModelState.IsValid)
            {
                db.sps.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maloai = new SelectList(db.loaisps, "ma", "ten", sp.maloai);
            return View(sp);
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
