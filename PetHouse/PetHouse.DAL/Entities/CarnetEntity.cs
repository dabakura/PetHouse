namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Carnet")]
    public partial class CarnetEntity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string ExpedienteId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VacunaId { get; set; }

        public DateTime Fecha_Vacunacion { get; set; }

        public bool? Estado { get; set; }

        public virtual ExpedienteEntity Expediente { get; set; }

        public virtual VacunaEntity Vacuna { get; set; }
    }
}
