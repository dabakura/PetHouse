using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetHouse.MVC.Models
{
    public class Domicilio
    {
        public Domicilio()
        {
            Distrito = new Distrito();
        }
        private int _DistritoId;
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get => _DistritoId; set => Distrito.Id = _DistritoId = value; }
        [DisplayName("Dirección")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "No debe estar entre {2} a {1} caracteres")]
        public string Direccion { get; set; }
        public Distrito Distrito { get; set; }
    }
}
