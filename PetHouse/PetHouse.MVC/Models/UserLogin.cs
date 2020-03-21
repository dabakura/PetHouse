using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHouse.MVC.Models
{
    public class UserLogin
    {
        [HiddenInput(DisplayValue = false)]
        [DefaultValue("password")]
        public String grant_type  => "password"; 

        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Debe ser una dirección Email valida")]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}