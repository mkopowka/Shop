using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class QuantityWarehouse
    {
        public int Id { get; set; }

        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Product Product { get; set; }
    }
}