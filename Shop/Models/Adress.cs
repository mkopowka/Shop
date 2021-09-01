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

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz podać imię!")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Musisz podać nazwisko!")]
        public string SecondName { get; set; }

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

        [Display(Name = "Numer Domu")]
        [Required(ErrorMessage = "Musisz podać numer domu!")]
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