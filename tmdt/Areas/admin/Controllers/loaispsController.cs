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

namespace tmdt.Areas.admin.Controllers
{
    public class loaispsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/loaisps
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var sps = db.loaisps.Include(s => s.ten);
            return View(db.loaisps.OrderByDescending(s => s.ten).ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    return View(db.loaisps.ToList());
        //}

        // GET: admin/loaisps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaisp loaisp = db.loaisps.Find(id);
            if (loaisp == null)
            {
                return HttpNotFound();
            }
            return View(loaisp);
        }

        // GET: admin/loaisps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/loaisps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma,ten,mota")] loaisp loaisp)
        {
            if (ModelState.IsValid)
            {
                db.loaisps.Add(loaisp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisp);
        }

        // GET: admin/loaisps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaisp loaisp = db.loaisps.Find(id);
            if (loaisp == null)
            {
                return HttpNotFound();
            }
            return View(loaisp);
        }

        // POST: admin/loaisps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma,ten,mota")] loaisp loaisp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisp);
        }

        // GET: admin/loaisps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaisp loaisp = db.loaisps.Find(id);
            if (loaisp == null)
            {
                return HttpNotFound();
            }
            return View(loaisp);
        }

        // POST: admin/loaisps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loaisp loaisp = db.loaisps.Find(id);
            db.loaisps.Remove(loaisp);
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
