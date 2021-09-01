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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Error! You need give name to your product")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Error! You need give price to your product")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Error! You need give description to your product")]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Error! You need select category to your product")]
        public int CategoryId { get; set; }

        [Display(Name = "Producer")]
        [Required(ErrorMessage = "Error! You need select producer to your product")]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<QuantityWarehouse> QuantityWarehouse { get; set; }
    }
}