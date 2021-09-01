using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Musisz podać nazwę produktu!")]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Musisz podać cenę!")]
        public double Price { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Musisz podać opis produktu!")]
        public string Description { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Photo { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Musisz wybrać kategorię!")]
        public int CategoryId { get; set; }

        [Display(Name = "Producent")]
        [Required(ErrorMessage = "Musisz wybrać producenta!")]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<QuantityWarehouse> QuantityWarehouse { get; set; }
    }
}