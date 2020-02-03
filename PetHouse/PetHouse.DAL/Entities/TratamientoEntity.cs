namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tratamiento")]
    public partial class TratamientoEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TratamientoEntity()
        {
            Medicamentos = new HashSet<MedicamentoEntity>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ExpedienteId { get; set; }

        public int EmpleadoId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public bool? Estado { get; set; }

        public virtual EmpleadoEntity Empleado { get; set; }

        public virtual ExpedienteEntity Expediente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicamentoEntity> Medicamentos { get; set; }
    }
}
