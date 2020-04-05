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
        public string Direccion { get; set; }
        public Distrito Distrito { get; set; }
    }
}
