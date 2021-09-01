using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Adress
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Error! You need add name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Error! You need add Last Name")]
        public string SecondName { get; set; }

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

        [Display(Name = "HouseNumber")]
        [Required(ErrorMessage = "Error! You need add House Number")]
        public string HouseNumber { get; set; }

        public virtual User User { get; set; }
    }

    public enum Voivodeship
    {
        Dolnośląskie,
        Kujawskopomorskie,
        Lubelskie,
        Lubuskie,
        Łódzkie,
        Małopolskie,
        Mazowieckie,
        Opolskie,
        Podkarpackie,
        Podlaskie,
        Pomorskie,
        Śląskie,
        Świętokrzyskie,
        Warmińskomazurskie,
        Wielkopolskie,
        Zachodniopomorskie
     }
}