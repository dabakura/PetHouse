using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PetHouse.API.App_Start;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Routing;

namespace PetHouse.API.Models
{
    public class ModelFactory
    {
        private readonly static IMapper mapper = AutoMapperConfig.Initialize().CreateMapper();
        public static Uri Uri { get; set; }

        public static S Create<S, O>(O model, Uri uri)
        {
            Uri = uri;
            return mapper.Map<S>(model);
        }

        public static S Create<S, O>(O model)
        {
            return mapper.Map<S>(model);
        }

        public static IEnumerable<S> Create<S, O>(IEnumerable<O> models, Uri uri)
        {
            Uri = uri;
            return mapper.Map<IEnumerable<O>, IEnumerable<S>>(models);
        }
    }

    public class VacunaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Vacuna/" + Id;
    }
    public class TratamientoMedicamentoModel
    {
        private TratamientoModel tratamiento;

        public int TratamientoId { get; set; }
        public string MedicamentoId { get; set; }
        public TratamientoModel Tratamiento { get => tratamiento; set => tratamiento = new TratamientoModel { Id = value.Id }; }
        public MedicamentoModel Medicamento { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/TratamientoMedicamento/" + TratamientoId;
    }
    public class TratamientoModel
    {
        private List<TratamientoMedicamentoModel> tratamientoMedicamentos;

        public TratamientoModel()
        {
            tratamientoMedicamentos = new List<TratamientoMedicamentoModel>();
            Medicamentos = new List<MedicamentoModel>();
        }

        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public ExpedienteModel Expediente { get; set; }
        public EmpleadoModel Empleado { get; set; }
        public List<TratamientoMedicamentoModel> TratamientoMedicamentos { 
            get => tratamientoMedicamentos; 
            set { 
                tratamientoMedicamentos = value; 
                Medicamentos = value.Select(TraMedicamento => TraMedicamento.Medicamento).ToList(); 
            } 
        }
        public List<MedicamentoModel> Medicamentos { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Tratamiento/" + Id;
    }
    public class PuestoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Puesto/" + Id;
    }
    public class ProvinciaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Provincia/" + Id;
    }
    public class ProcedimientoModel
    {
        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Nombre_Procedimiento { get; set; }
        public string Descripcion { get; set; }

        public ExpedienteModel Expediente { get; set; }
        public EmpleadoModel Empleado { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Procedimiento/" + Id;
    }
    public class MedicamentoModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Medicamento/" + Id;
    }
    public class MascotaModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string ExpedienteId { get; set; }
        public ExpedienteModel Expediente { get; set; }
        public AdopcionModel Adopcion { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Mascota/" + Identificacion;
    }
    public class InstitucionModel
    {
        public int Id { get; set; }
        public string Ced_Juridica { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Fax { get; set; }
        public string Pag_Web { get; set; }
        public string Correo { get; set; }
        public int DireccionId { get; set; }
        public DomicilioModel Domicilio { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Institucion/" + Id;
    }
    public class ExpedienteModel
    {
        public string Id { get; set; }
        public string Observaciones { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Edad { get; set; }
        public bool Castracion { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime? Fecha_Fallecimiento { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Expediente/" + Id;
    }
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int DomicilioId { get; set; }
        public int PuestoID { get; set; }
        public int InstitucionId { get; set; }
        public string UserId { get; set; }
        public InstitucionModel Institucion { get; set; }
        public DomicilioModel Domicilio { get; set; }
        public PuestoModel Puesto { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Empleado/" + Identificacion;
    }
    public class DomicilioModel
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        public DistritoModel Distrito { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Domicilio/" + Id;
    }
    public class DistritoModel
    {
        public int Id { get; set; }
        public int CantonId { get; set; }
        public string Nombre { get; set; }
        public CantonModel Canton { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Distrito/" + Id;
    }
    public class CarnetModel
    {
        public string ExpedienteId { get; set; }
        public int VacunaId { get; set; }
        public DateTime Fecha_Vacunacion { get; set; }
        public VacunaModel Vacuna { get; set; }
        public ExpedienteModel Expediente { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Carnet/" + ExpedienteId;
    }
    public class CantonModel
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public ProvinciaModel Provincia { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Canton/" + Id;
    }
    public class AspNetUsersModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/AspNetUsers/" + Id;
    }

    public class AspNetRolesModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/rol/GetRoleById/" + Id;
    }

    public class AdopcionModel
    {
        public int Id { get; set; }
        public int InstitucionId { get; set; }
        public int AdoptanteId { get; set; }
        public string MascotaId { get; set; }
        public DateTime Fecha_Adopcion { get; set; }
        public InstitucionModel Institucion { get; set; }
        public AdoptanteModel Adoptante { get; set; }
        public MascotaModel Mascota { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Adopcion/" + Id;
    }

    public class AdoptanteModel
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int DomicilioId { get; set; }
        public DomicilioModel Domicilio { get; set; }
        public IEnumerable<Mascota> Mascotas { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Adoptante/" + Id;
    }

    public class PersonaModel
    {
        public int Cedula { get; set; }

        public string Nombre { get; set; }

        public string Primer_Apellido { get; set; }

        public string Segundo_Apellido { get; set; }

        public int Sexo { get; set; }

        public int ProvinciaId { get; set; }

        public int CantonId { get; set; }

        public int DistritoId { get; set; }

        public string Provincia_Nombre { get; set; }

        public string Canton_Nombre { get; set; }

        public string Distrito_Nombre { get; set; }
        public string Href => ModelFactory.Uri.Authority + "/api/Persona/" + Cedula;
    }
}