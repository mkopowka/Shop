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
    public class QuantityWarehousesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: QuantityWarehouses
        public ActionResult Index()
        {
            return View(db.QuantityWarehouses.ToList());
        }

        // GET: QuantityWarehouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityWarehouse quantityWarehouse = db.QuantityWarehouses.Find(id);
            if (quantityWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(quantityWarehouse);
        }

        // GET: QuantityWarehouses/Create
        public ActionResult Create()
        {
            List<Product> pro = db.Products.ToList();
            List<Warehouse> war = db.Warehouses.ToList();
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            SelectList selectwar = new SelectList(war.AsReadOnly(), "id", "City");
            ViewBag.ProdList = selectpro;
            ViewBag.WarList = selectwar;
            return View();
        }

        // POST: QuantityWarehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,ProductId,WarehouseId")] QuantityWarehouse quantityWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.QuantityWarehouses.Add(quantityWarehouse);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            List<Product> pro = db.Products.ToList();
            List<Warehouse> war = db.Warehouses.ToList();
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            SelectList selectwar = new SelectList(war.AsReadOnly(), "id", "City");
            ViewBag.ProdList = selectpro;
            ViewBag.WarList = selectwar;
            return View(quantityWarehouse);
        }

        // GET: QuantityWarehouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityWarehouse quantityWarehouse = db.QuantityWarehouses.Find(id);
            if (quantityWarehouse == null)
            {
                return HttpNotFound();
            }
            List<Product> pro = db.Products.ToList();
            List<Warehouse> war = db.Warehouses.ToList();
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            SelectList selectwar = new SelectList(war.AsReadOnly(), "id", "City");
            ViewBag.ProdList = selectpro;
            ViewBag.WarList = selectwar;
            return View(quantityWarehouse);
        }

        // POST: QuantityWarehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,ProductId,WarehouseId")] QuantityWarehouse quantityWarehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quantityWarehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Product> pro = db.Products.ToList();
            List<Warehouse> war = db.Warehouses.ToList();
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            SelectList selectwar = new SelectList(war.AsReadOnly(), "id", "City");
            ViewBag.ProdList = selectpro;
            ViewBag.WarList = selectwar;
            return View(quantityWarehouse);
        }

        // GET: QuantityWarehouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityWarehouse quantityWarehouse = db.QuantityWarehouses.Find(id);
            if (quantityWarehouse == null)
            {
                return HttpNotFound();
            }
            return View(quantityWarehouse);
        }

        // POST: QuantityWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuantityWarehouse quantityWarehouse = db.QuantityWarehouses.Find(id);
            db.QuantityWarehouses.Remove(quantityWarehouse);
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
