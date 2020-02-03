namespace PetHouse.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetHouseModel : DbContext
    {
        public PetHouseModel()
            : base("name=PetHouseConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AdopcionEntity> Adopciones { get; set; }
        public virtual DbSet<AdoptanteEntity> Adoptantes { get; set; }
        public virtual DbSet<AspNetRolesEntity> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaimsEntity> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLoginsEntity> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsersEntity> AspNetUsers { get; set; }
        public virtual DbSet<CantonEntity> Cantones { get; set; }
        public virtual DbSet<CarnetEntity> Carnets { get; set; }
        public virtual DbSet<DistritoEntity> Distritos { get; set; }
        public virtual DbSet<DomicilioEntity> Domicilios { get; set; }
        public virtual DbSet<EmpleadoEntity> Empleados { get; set; }
        public virtual DbSet<ExpedienteEntity> Expedientes { get; set; }
        public virtual DbSet<InstitucionEntity> Instituciones { get; set; }
        public virtual DbSet<MascotaEntity> Mascotas { get; set; }
        public virtual DbSet<MedicamentoEntity> Medicamentos { get; set; }
        public virtual DbSet<ProcedimientoEntity> Procedimientos { get; set; }
        public virtual DbSet<ProvinciaEntity> Provincias { get; set; }
        public virtual DbSet<PuestoEntity> Puestos { get; set; }
        public virtual DbSet<TratamientoEntity> Tratamientos { get; set; }
        public virtual DbSet<VacunaEntity> Vacunas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdoptanteEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<AdoptanteEntity>()
                .Property(e => e.Primer_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<AdoptanteEntity>()
                .Property(e => e.Segundo_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<AdoptanteEntity>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<AdoptanteEntity>()
                .HasMany(e => e.Adopciones)
                .WithRequired(e => e.Adoptantes)
                .HasForeignKey(e => e.AdoptanteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRolesEntity>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsersEntity>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsersEntity>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsersEntity>()
                .HasMany(e => e.Empleados)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CantonEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CantonEntity>()
                .HasMany(e => e.Domicilios)
                .WithRequired(e => e.Canton)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarnetEntity>()
                .Property(e => e.ExpedienteId)
                .IsUnicode(false);

            modelBuilder.Entity<DistritoEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DistritoEntity>()
                .HasMany(e => e.Domicilios)
                .WithRequired(e => e.Distrito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomicilioEntity>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<DomicilioEntity>()
                .HasMany(e => e.Adoptantes)
                .WithRequired(e => e.Domicilio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomicilioEntity>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Domicilio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DomicilioEntity>()
                .HasMany(e => e.Instituciones)
                .WithRequired(e => e.Domicilio)
                .HasForeignKey(e => e.DireccionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .Property(e => e.Primer_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .Property(e => e.Segundo_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .HasMany(e => e.Procedimientos)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.EmpleadoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmpleadoEntity>()
                .HasMany(e => e.Tratamientos)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.EmpleadoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .HasMany(e => e.Carnets)
                .WithRequired(e => e.Expediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .HasMany(e => e.Mascotas)
                .WithRequired(e => e.Expediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .HasMany(e => e.Procedimientos)
                .WithRequired(e => e.Expediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExpedienteEntity>()
                .HasMany(e => e.Tratamientos)
                .WithRequired(e => e.Expediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InstitucionEntity>()
                .Property(e => e.Ced_Juridica)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEntity>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEntity>()
                .Property(e => e.Pag_Web)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEntity>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEntity>()
                .HasMany(e => e.Adopciones)
                .WithRequired(e => e.Instituciones)
                .HasForeignKey(e => e.InstituionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InstitucionEntity>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Institucion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.Identificacion)
                .IsUnicode(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.Genero)
                .IsUnicode(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.Raza)
                .IsUnicode(false);

            modelBuilder.Entity<MascotaEntity>()
                .Property(e => e.ExpedienteId)
                .IsUnicode(false);

            modelBuilder.Entity<MedicamentoEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MedicamentoEntity>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<MedicamentoEntity>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<MedicamentoEntity>()
                .HasMany(e => e.Tratamientos)
                .WithMany(e => e.Medicamentos)
                .Map(m => m.ToTable("TratamientoMedicamento").MapLeftKey("MedicamentoId").MapRightKey("TratamientoId"));

            modelBuilder.Entity<ProcedimientoEntity>()
                .Property(e => e.ExpedienteId)
                .IsUnicode(false);

            modelBuilder.Entity<ProcedimientoEntity>()
                .Property(e => e.Nombre_Procedimiento)
                .IsUnicode(false);

            modelBuilder.Entity<ProcedimientoEntity>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ProvinciaEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProvinciaEntity>()
                .HasMany(e => e.Domicilios)
                .WithRequired(e => e.Provincia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PuestoEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PuestoEntity>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PuestoEntity>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Puesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TratamientoEntity>()
                .Property(e => e.ExpedienteId)
                .IsUnicode(false);

            modelBuilder.Entity<TratamientoEntity>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<VacunaEntity>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<VacunaEntity>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<VacunaEntity>()
                .HasMany(e => e.Carnets)
                .WithRequired(e => e.Vacuna)
                .WillCascadeOnDelete(false);
        }
    }
}
