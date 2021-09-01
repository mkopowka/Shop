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

namespace Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransportsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Transports
        public ActionResult Index()
        {
            return View(db.Transports.ToList());
        }

        // GET: Transports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create()
        {
            List<Order> ore = db.Orders.ToList();
            List<Warehouse> ware = db.Warehouses.ToList();
            SelectList selectware = new SelectList(ware.AsReadOnly(), "id", "City");
            SelectList selectore = new SelectList(ore.AsReadOnly(), "Id", "Id");
            ViewBag.wareList = selectware;
            ViewBag.oreList = selectore;
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromId,ToId,TransportTime,OrderId")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Transports.Add(transport);
                db.SaveChanges();
                return RedirectToAction("Edit", new { Id = transport.Id });
            }
            List<Order> ore = db.Orders.ToList();
            List<Warehouse> ware = db.Warehouses.ToList();
            SelectList selectware = new SelectList(ware.AsReadOnly(), "id", "City");
            SelectList selectore = new SelectList(ore.AsReadOnly(), "Id", "Id");
            ViewBag.wareList = selectware;
            ViewBag.oreList = selectore;
            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Include(p => p.TransportProductQuantity).Where(p => p.Id == id).Single();
            var prod = (from p in db.Products
                        join q in db.QuantityWarehouses on p.Id equals q.ProductId
                        join t in db.Transports on q.WarehouseId equals t.FromId
                        select p).ToList();


            ViewBag.ProductId = new SelectList(prod, "Id", "Name");

            if (transport == null)
            {
                return HttpNotFound();
            }


            List<Order> ore = db.Orders.ToList();
            List<Warehouse> ware = db.Warehouses.ToList();
            SelectList selectware = new SelectList(ware.AsReadOnly(), "id", "City");
            SelectList selectore = new SelectList(ore.AsReadOnly(), "Id", "Id");
            ViewBag.wareList = selectware;
            ViewBag.oreList = selectore;
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromId,ToId,TransportTime,OrderId")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Order> ore = db.Orders.ToList();
            List<Warehouse> ware = db.Warehouses.ToList();
            SelectList selectware = new SelectList(ware.AsReadOnly(), "id", "City");
            SelectList selectore = new SelectList(ore.AsReadOnly(), "Id", "Id");
            ViewBag.wareList = selectware;
            ViewBag.oreList = selectore;
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DodajProdukt(TransportProductQuantity quantit) //, int id_skladnika, string ilosc, Jednostka jednostka
        {

            db.TransportProductQuantities.Add(quantit);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = quantit.TransportID });
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
