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
    public class donhangsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/donhangs
        public ActionResult Index()
        {
            var donhangs = db.donhangs.Include(d => d.khachhang);
            return View(donhangs.ToList());
        }

        // GET: admin/donhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: admin/donhangs/Create
        public ActionResult Create()
        {
            ViewBag.makh = new SelectList(db.khachhangs, "ma", "ten");
            return View();
        }

        // POST: admin/donhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma,makh,ngaydat,ngaygiao,phigiao,tennguoinhan,diachi,dienthoai,email,trangthai")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.donhangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makh = new SelectList(db.khachhangs, "ma", "ten", donhang.makh);
            return View(donhang);
        }

        // GET: admin/donhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.makh = new SelectList(db.khachhangs, "ma", "ten", donhang.makh);
            return View(donhang);
        }

        // POST: admin/donhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma,makh,ngaydat,ngaygiao,phigiao,tennguoinhan,diachi,dienthoai,email,trangthai")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makh = new SelectList(db.khachhangs, "ma", "ten", donhang.makh);
            return View(donhang);
        }

        // GET: admin/donhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: admin/donhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donhang donhang = db.donhangs.Find(id);
            db.donhangs.Remove(donhang);
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
