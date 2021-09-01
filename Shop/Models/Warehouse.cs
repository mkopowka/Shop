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

        [Display(Name = "City")]
        [Required(ErrorMessage = "Error! You need add City")]
        public string City { get; set; }

        [Display(Name = "Voivodeship")]
        [Required(ErrorMessage = "Error! You need select Voivodeship")]
        public Voivodeship? Voivodeship { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Error! You need add Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Error! You need add Street")]
        public string Street { get; set; }

        [Display(Name = "BuildingNumber")]
        [Required(ErrorMessage = "Error! You need add building number")]
        public int BuildingNumber { get; set; }

        public virtual ICollection<QuantityWarehouse> QuantityWarehouse { get; set; }

        public virtual ICollection<Transport> Transport { get; set; }
    }

  

}