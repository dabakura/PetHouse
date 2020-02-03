namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mascota")]
    public partial class MascotaEntity
    {
        [Key]
        [StringLength(100)]
        public string Identificacion { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(50)]
        public string Genero { get; set; }

        [StringLength(50)]
        public string Raza { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        public int Edad_Registrada { get; set; }

        public int? AdopcionId { get; set; }

        public DateTime? Fecha_Fallecimiento { get; set; }

        [Required]
        [StringLength(100)]
        public string ExpedienteId { get; set; }

        public bool? Estado { get; set; }

        public virtual AdopcionEntity Adopcion { get; set; }

        public virtual ExpedienteEntity Expediente { get; set; }
    }
}
