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

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Error! You need add Category Name!")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Error! You need add Category Description!")]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}