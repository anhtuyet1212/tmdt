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
    public class chitietdhsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/chitietdhs
        public ActionResult Index(int madh)
        {
            var chitietdhs = db.chitietdhs.Where(c => c.madh == madh).Include(c => c.donhang).Include(c => c.sp);
            return View(chitietdhs.ToList());
        }

        // GET: admin/chitietdhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdh chitietdh = db.chitietdhs.Find(id);
            if (chitietdh == null)
            {
                return HttpNotFound();
            }
            return View(chitietdh);
        }

        // GET: admin/chitietdhs/Create
        public ActionResult Create()
        {
            ViewBag.madh = new SelectList(db.donhangs, "ma", "tennguoinhan");
            ViewBag.masp = new SelectList(db.sps, "ma", "ten");
            return View();
        }

        // POST: admin/chitietdhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "madh,masp,soluong,dongia")] chitietdh chitietdh)
        {
            if (ModelState.IsValid)
            {
                db.chitietdhs.Add(chitietdh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.madh = new SelectList(db.donhangs, "ma", "tennguoinhan", chitietdh.madh);
            ViewBag.masp = new SelectList(db.sps, "ma", "ten", chitietdh.masp);
            return View(chitietdh);
        }

        // GET: admin/chitietdhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdh chitietdh = db.chitietdhs.Find(id);
            if (chitietdh == null)
            {
                return HttpNotFound();
            }
            ViewBag.madh = new SelectList(db.donhangs, "ma", "tennguoinhan", chitietdh.madh);
            ViewBag.masp = new SelectList(db.sps, "ma", "ten", chitietdh.masp);
            return View(chitietdh);
        }

        // POST: admin/chitietdhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "madh,masp,soluong,dongia")] chitietdh chitietdh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.madh = new SelectList(db.donhangs, "ma", "tennguoinhan", chitietdh.madh);
            ViewBag.masp = new SelectList(db.sps, "ma", "ten", chitietdh.masp);
            return View(chitietdh);
        }

        // GET: admin/chitietdhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdh chitietdh = db.chitietdhs.Find(id);
            if (chitietdh == null)
            {
                return HttpNotFound();
            }
            return View(chitietdh);
        }

        // POST: admin/chitietdhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietdh chitietdh = db.chitietdhs.Find(id);
            db.chitietdhs.Remove(chitietdh);
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
