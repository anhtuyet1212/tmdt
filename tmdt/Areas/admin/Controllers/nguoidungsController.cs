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
    public class nguoidungsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/nguoidungs
        public ActionResult Index()
        {
            return View(db.nguoidungs.ToList());
        }

        // GET: admin/nguoidungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoidung nguoidung = db.nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // GET: admin/nguoidungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/nguoidungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma,ten,gioitinh,diachi,dienthoai,email,tendangnhap,matkhau,anh,quyen")] nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.nguoidungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoidung);
        }

        // GET: admin/nguoidungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoidung nguoidung = db.nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: admin/nguoidungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma,ten,gioitinh,diachi,dienthoai,email,tendangnhap,matkhau,anh,quyen")] nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoidung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoidung);
        }

        // GET: admin/nguoidungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nguoidung nguoidung = db.nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: admin/nguoidungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nguoidung nguoidung = db.nguoidungs.Find(id);
            db.nguoidungs.Remove(nguoidung);
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
