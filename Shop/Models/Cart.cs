using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Cart
    {
         
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Ilosc")]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public Cart() { }
        public Cart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
}
}