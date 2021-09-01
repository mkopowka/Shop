using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class TransportProductQuantity
    {
        public int ID { get; set; }

        public int TransportID { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Transport Transport { get; set; }

        public virtual Product Product { get; set; }

    }
}