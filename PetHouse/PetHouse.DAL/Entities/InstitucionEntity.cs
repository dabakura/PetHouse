namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Institucion")]
    public partial class InstitucionEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InstitucionEntity()
        {
            Adopciones = new HashSet<AdopcionEntity>();
            Empleados = new HashSet<EmpleadoEntity>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Ced_Juridica { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public int Telefono { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Pag_Web { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        public int DireccionId { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdopcionEntity> Adopciones { get; set; }

        public virtual DomicilioEntity Domicilio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoEntity> Empleados { get; set; }
    }
}
