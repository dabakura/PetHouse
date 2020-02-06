namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adoptante")]
    public partial class AdoptanteEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdoptanteEntity()
        {
            Adopciones = new HashSet<AdopcionEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Identificacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Primer_Apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string Segundo_Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public int Telefono { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        public int DomicilioId { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdopcionEntity> Adopciones { get; set; }

        public virtual DomicilioEntity Domicilio { get; set; }
    }
}
