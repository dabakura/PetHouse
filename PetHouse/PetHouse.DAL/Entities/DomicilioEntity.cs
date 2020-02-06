namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Domicilio")]
    public partial class DomicilioEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DomicilioEntity()
        {
            Adoptantes = new HashSet<AdoptanteEntity>();
            Empleados = new HashSet<EmpleadoEntity>();
            Instituciones = new HashSet<InstitucionEntity>();
        }

        public int Id { get; set; }

        public int ProvinciaId { get; set; }

        public int CantonId { get; set; }

        public int DistritoId { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdoptanteEntity> Adoptantes { get; set; }

        public virtual CantonEntity Canton { get; set; }

        public virtual DistritoEntity Distrito { get; set; }

        public virtual ProvinciaEntity Provincia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoEntity> Empleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstitucionEntity> Instituciones { get; set; }
    }
}
