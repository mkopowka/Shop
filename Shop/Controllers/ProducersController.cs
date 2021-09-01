using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.DAL;
using Shop.Models;
using PagedList;

namespace Shop.Controllers
{
    public class ProducersController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Producers
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazwaSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var producers = from s in db.Producers
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {

                producers = producers.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    producers = producers.OrderByDescending(s => s.Name);
                    break;
                default:
                    producers = producers.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(producers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Producers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // GET: Producers/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
                if (file != null && file.ContentLength > 0)
                {
                    producer.Photo = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/") + producer.Photo);
                }
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        // GET: Producers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Photo")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
                if (file != null && file.ContentLength > 0)
                {
                    producer.Photo = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/") + producer.Photo);
                }
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: Producers/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null)
            {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Producers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
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
