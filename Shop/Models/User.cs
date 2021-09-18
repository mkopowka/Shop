using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(20,MinimumLength = 3)]
        [Required(ErrorMessage = "Add Email")]
        public string Email { get; set; }
        
        [Display(Name = "First Name")]
        [StringLength(32, MinimumLength = 3)]
        [Required(ErrorMessage = "Error! You need add First Name!")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(32, MinimumLength = 3)]
        [Required(ErrorMessage = "Error! You need add Last Name!")]
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Adress> Adress { get; set; }
    }
}