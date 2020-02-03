namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expediente")]
    public partial class ExpedienteEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpedienteEntity()
        {
            Carnets = new HashSet<CarnetEntity>();
            Mascotas = new HashSet<MascotaEntity>();
            Procedimientos = new HashSet<ProcedimientoEntity>();
            Tratamientos = new HashSet<TratamientoEntity>();
        }

        [StringLength(100)]
        public string Id { get; set; }

        [Column(TypeName = "text")]
        public string Observaciones { get; set; }

        public bool Castracion { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarnetEntity> Carnets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MascotaEntity> Mascotas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcedimientoEntity> Procedimientos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TratamientoEntity> Tratamientos { get; set; }
    }
}
