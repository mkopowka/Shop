using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Display(Name = "Producent")]
        [Required(ErrorMessage = "Musisz podać nazwę producenta!")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Musisz podać opis producenta!")]
        public string Description { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Photo { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}