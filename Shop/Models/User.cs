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
        [Required(ErrorMessage = "Add email")]
        public string Email { get; set; }
        
        [Display(Name = "First Name")]
        [StringLength(32, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(32, MinimumLength = 3)]
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Adress> Adress { get; set; }
    }
}