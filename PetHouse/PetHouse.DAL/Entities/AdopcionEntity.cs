namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adopcion")]
    public partial class AdopcionEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdopcionEntity()
        {
            Mascotas = new HashSet<MascotaEntity>();
        }

        public int Id { get; set; }

        public int InstituionId { get; set; }

        public int AdoptanteId { get; set; }

        public DateTime Fecha_Adopcion { get; set; }

        public bool? Estado { get; set; }

        public virtual AdoptanteEntity Adoptantes { get; set; }

        public virtual InstitucionEntity Instituciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MascotaEntity> Mascotas { get; set; }
    }
}
