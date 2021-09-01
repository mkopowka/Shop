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
    public class OrdersController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.User);
            return View(orders.ToList());
        }
        public ActionResult ShowMyOrders()
        {
            var orders = db.Orders.Include(o => o.User);
            int id = db.getUser().Id;
            return View(orders.ToList().Where(s=>s.UserID==id));
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);
            
            List<Cart> basket = db.Carts.Include(o => o.Product).ToList();
            basket = basket.Where(s => s.OrderId.Equals(id)).ToList();
            ViewBag.Basket = basket;
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            User activeUser = db.getUser();
            ViewBag.User = activeUser.Id;
            ViewBag.FirstName = activeUser.FirstName;
            ViewBag.LastName = activeUser.LastName;
            Order order = new Order { UserID = activeUser.Id, Address = new Adress() };
            order.OrderStatus = OrderStatus.Przyjęto;
            order.OrderDate = DateTime.Now;
            order.SendOrder = DateTime.Now;
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {

                order.Address.UserId = order.UserID;
                db.Adresses.Add(order.Address);
                db.SaveChanges();

                order.AdresId = db.Adresses.Max(item => item.Id);
                db.Orders.Add(order);
                List<Cart> IsCart = (List<Cart>)Session["Basket"];
                Session["Basket"] = null;
                foreach (Cart b in IsCart)
                {
                    b.OrderId = order.Id;
                    b.ProductId = b.Product.Id;
                    b.Product = null;
                    db.Carts.Add(b);
                }
                db.SaveChanges();
                return RedirectToAction("ShowMyOrders");
            }
            else
            {
                ViewBag.Error = "Model is invalid";
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", order.UserID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,UserID,AdresId,OrderDate,OrderStatus,SendOrder")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", order.UserID);
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
