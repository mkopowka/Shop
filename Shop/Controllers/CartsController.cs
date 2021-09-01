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
    [Authorize]
    public class CartsController : Controller
    {
        private ShopContext db = new ShopContext();
        private string strBasket = "Basket";
        // GET: Baskets
        public ActionResult Index()
        {
            if (Session["Basket"] == null) Session["Basket"] = new List<Cart>();
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strBasket] == null)
            {
                List<Cart> IsCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id),1)
                };
                Session[strBasket] = IsCart;
            }
            else
            {
                List<Cart> IsCart = (List<Cart>)Session[strBasket];
                int chceck = isExistingCheck(id);
                if (chceck == -1)
                {
                    IsCart.Add(new Cart(db.Products.Find(id), 1));
                }
                else
                    IsCart[chceck].Quantity++;
                Session[strBasket] = IsCart;
            }


            return View("Index");
        }

        private int isExistingCheck(int? id)
        {
            List<Cart> IsCart = (List<Cart>)Session[strBasket];
            for (int i = 0; i < IsCart.Count; i++)
            {
                if (IsCart[i].Product.Id == id) return i;
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                int check = isExistingCheck(id);
                List<Cart> IsCart = (List<Cart>)Session[strBasket];
                IsCart.RemoveAt(check);
            }
            return View("Index");
        }

        public ActionResult UpdateBasket(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lstCart = (List<Cart>)Session[strBasket];
            for (int i = 0; i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strBasket] = lstCart;
            return View("Index");
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
