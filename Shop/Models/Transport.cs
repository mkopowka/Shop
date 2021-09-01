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


        [Display(Name = "Skąd")]
        [Required(ErrorMessage = "Musisz wybrać skąd ma wyjechać transport!")]
        public int FromId { get; set; }

        [Display(Name = "Do")]
        [Required(ErrorMessage = "Musisz wybrać dokąd ma jechać transport!")]
        public int ToId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Wysłania(yyyy-MM-dd)")]
        public DateTime TransportTime { get; set; }

        [Required(ErrorMessage = "Musisz wybrać numer zamówienia!")]
        public int OrderId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Order Order { get; set; }
       
        public virtual ICollection<TransportProductQuantity> TransportProductQuantity { get; set; }
    }
}