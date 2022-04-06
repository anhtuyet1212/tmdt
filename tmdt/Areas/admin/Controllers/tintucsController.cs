using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tmdt.Models;
using PagedList;

namespace tmdt.Areas.admin
{
    public class tintucsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/tintucs
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var sps = db.tintucs.Include(s => s.tieude);
            return View(db.tintucs.OrderByDescending(s => s.tieude).ToPagedList(pageNumber, pageSize));
        }

        // GET: admin/tintucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }
        public ActionResult Timkiemtt(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = page ?? 1;
            return View(db.tintucs.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Timkiemtt(int? page, string keyword)
        {
            var dstt = db.tintucs.Where(s => s.tieude.Contains(keyword)).ToList();
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(dstt.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        // GET: admin/tintucs/Create
        public ActionResult Create()
        {
            ViewBag.macm = new SelectList(db.chuyenmucs, "ma", "ten");
            return View();
        }

        // POST: admin/tintucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ma,tieude,macm,matangan,mota,ngaydang,anh,nguoidang,tieubieu,loaitin")] tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.tintucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.macm = new SelectList(db.chuyenmucs, "ma", "ten", tintuc.macm);
            return View(tintuc);
        }

        // GET: admin/tintucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.macm = new SelectList(db.chuyenmucs, "ma", "ten", tintuc.macm);
            return View(tintuc);
        }

        // POST: admin/tintucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ma,tieude,macm,matangan,mota,ngaydang,anh,nguoidang,tieubieu,loaitin")] tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.macm = new SelectList(db.chuyenmucs, "ma", "ten", tintuc.macm);
            return View(tintuc);
        }

        // GET: admin/tintucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: admin/tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tintuc tintuc = db.tintucs.Find(id);
            db.tintucs.Remove(tintuc);
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
