namespace PetHouse.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class EmpleadoEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmpleadoEntity()
        {
            Procedimientos = new HashSet<ProcedimientoEntity>();
            Tratamientos = new HashSet<TratamientoEntity>();
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

        public int PuestoID { get; set; }

        public int InstitucionId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public bool? Estado { get; set; }

        public virtual AspNetUsersEntity AspNetUsers { get; set; }

        public virtual DomicilioEntity Domicilio { get; set; }

        public virtual InstitucionEntity Institucion { get; set; }

        public virtual PuestoEntity Puesto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcedimientoEntity> Procedimientos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TratamientoEntity> Tratamientos { get; set; }
    }
}
