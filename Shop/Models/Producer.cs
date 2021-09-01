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

        [Display(Name = "Producer Name")]
        [Required(ErrorMessage = "Error! You need give producer name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Error! You need add description")]
        public string Description { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}