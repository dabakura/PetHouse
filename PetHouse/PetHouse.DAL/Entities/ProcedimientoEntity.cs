namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Procedimiento")]
    public partial class ProcedimientoEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ExpedienteId { get; set; }

        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_Procedimiento { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public virtual EmpleadoEntity Empleado { get; set; }

        public virtual ExpedienteEntity Expediente { get; set; }
    }
}
