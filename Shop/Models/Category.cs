using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Musisz podać nazwę kategorii!")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Musisz podać opis kategorii!")]
        public string Description { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Photo { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}