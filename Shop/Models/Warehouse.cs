using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Shop.Models
{
    public class Warehouse
    {
       
        public int Id { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Musisz podać miasto!")]
        public string City { get; set; }

        [Display(Name = "Województwo")]
        [Required(ErrorMessage = "Musisz wybrać województwo!")]
        public Voivodeship? Voivodeship { get; set; }

        [Display(Name = "Kod Pocztowy")]
        [Required(ErrorMessage = "Musisz podać kod pocztowy!")]
        public string PostalCode { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Musisz podać ulicę!")]
        public string Street { get; set; }

        [Display(Name = "Numer Budynku")]
        [Required(ErrorMessage = "Musisz podać numer budynku!")]
        public int BuildingNumber { get; set; }

        public virtual ICollection<QuantityWarehouse> QuantityWarehouse { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }

  

}