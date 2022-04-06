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
    public class chuyenmucsController : Controller
    {
        private csdlbh db = new csdlbh();

        // GET: admin/chuyenmucs

        public ActionResult Index(int? page)
        {
            {
                if (page == null)
                {
                    page = 1;
                }
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var chuyenmuc = db.chuyenmucs.Include(s => s.ma);
                return View(db.chuyenmucs.OrderBy(s => s.ma).ToPagedList(pageNumber, pageSize));

            }
        }
        public ActionResult Timkiemchuyenmuc(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = page ?? 1;
            return View(db.chuyenmucs.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Timkiemchuyenmuc(int? page, string keyword)
        {
            var dscm = db.chuyenmucs.Where(s => s.ten.Contains(keyword)).ToList();
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(dscm.OrderByDescending(s => s.ma).ToPagedList(pageNumber, pageSize));
        }
        // GET: admin/chuyenmucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuyenmuc chuyenmuc = db.chuyenmucs.Find(id);
            if (chuyenmuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenmuc);
        }

        // GET: admin/chuyenmucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/chuyenmucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma,ten,mota,mact")] chuyenmuc chuyenmuc)
        {
          //  if (ModelState.IsValid)
         //   {
                db.chuyenmucs.Add(chuyenmuc);
            db.SaveChanges();
                return RedirectToAction("Index");
         //   }

        //    return View(chuyenmuc);
        }

        // GET: admin/chuyenmucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuyenmuc chuyenmuc = db.chuyenmucs.Find(id);
            if (chuyenmuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenmuc);
        }

        // POST: admin/chuyenmucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma,ten,mota,mact")] chuyenmuc chuyenmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuyenmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuyenmuc);
        }

        // GET: admin/chuyenmucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chuyenmuc chuyenmuc = db.chuyenmucs.Find(id);
            if (chuyenmuc == null)
            {
                return HttpNotFound();
            }
            return View(chuyenmuc);
        }

        // POST: admin/chuyenmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chuyenmuc chuyenmuc = db.chuyenmucs.Find(id);
            db.chuyenmucs.Remove(chuyenmuc);
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
