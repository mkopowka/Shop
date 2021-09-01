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
using System.IO;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Products
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? idc, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazwaSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CenaSortParm = sortOrder == "Price" ? "date_desc" : "Price";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from s in db.Products
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            if (idc != null)
            {
                products = products.Where(x => x.CategoryId == idc);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            List<Producer> pro = db.Producers.ToList();
            List<Category> cat = db.Categories.ToList();
            SelectList selectcat = new SelectList(cat.AsReadOnly(), "id", "Name");
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            ViewBag.CatList = selectcat;
            ViewBag.ProdList = selectpro;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,CategoryId,ProducerId")] Product product)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
                if (file != null && file.ContentLength > 0)
                {
                    product.Photo = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/") + product.Photo);
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Producer> pro = db.Producers.ToList();
            List<Category> cat = db.Categories.ToList();
            SelectList selectcat = new SelectList(cat.AsReadOnly(), "id", "Name");
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            ViewBag.CatList = selectcat;
            ViewBag.ProdList = selectpro;
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }


            List<Producer> pro = db.Producers.ToList();
            List<Category> cat = db.Categories.ToList();
            SelectList selectcat = new SelectList(cat.AsReadOnly(), "id", "Name");
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            ViewBag.CatList = selectcat;
            ViewBag.ProdList = selectpro;
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,CategoryId,ProducerId,Photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["plikZObrazkiem"];
                if (file != null && file.ContentLength > 0)
                {
                    product.Photo = System.Guid.NewGuid().ToString() + ".jpg";
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/") + product.Photo);
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Producer> pro = db.Producers.ToList();
            List<Category> cat = db.Categories.ToList();
            SelectList selectcat = new SelectList(cat.AsReadOnly(), "id", "Name");
            SelectList selectpro = new SelectList(pro.AsReadOnly(), "id", "Name");
            ViewBag.CatList = selectcat;
            ViewBag.ProdList = selectpro;
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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