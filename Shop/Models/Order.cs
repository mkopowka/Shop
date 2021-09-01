using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
       
        public int UserID { get; set; }

        public int AdresId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Zamówienia")]
        [Required(ErrorMessage = "Musisz podać datę zamówienia!")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Status Zamówienia")]
        [Required(ErrorMessage = "Musisz wybrać status zamówienia!")]
        public OrderStatus? OrderStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Przewidywana Data Wysłania")]
        [Required(ErrorMessage = "Musisz podać datę wysyłki!")]
        public DateTime SendOrder { get; set; }

        public virtual User User { get; set; }
        public virtual List<Cart> Koszyk { get; set; }
        public virtual Adress Address { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }

    public enum OrderStatus
    {
        Przyjęto,
        Realizacja,
        Wysłano,
        Anulowano
    }
}