using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Transport
    {
        public int Id { get; set; }


        [Display(Name = "From")]
        [Required(ErrorMessage = "Select start warehouse")]
        public int FromId { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "Select destination warehouse")]
        public int ToId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Send Date(yyyy-MM-dd)")]
        public DateTime TransportTime { get; set; }

        [Required(ErrorMessage = "Select order!")]
        public int OrderId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Order Order { get; set; }
       
        public virtual ICollection<TransportProductQuantity> TransportProductQuantity { get; set; }
    }
}