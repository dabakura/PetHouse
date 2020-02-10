using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PetHouse.API.App_Start;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace PetHouse.API.Models
{
    public class ModelFactory
    {
        private readonly static IMapper mapper = AutoMapperConfig.Initialize().CreateMapper();

        public AspNetRolesModel Create(IdentityRole appRole, Uri uri)
        {
            return new AspNetRolesModel
            {
                Href = uri.AbsoluteUri,
                Id = appRole.Id,
                Name = appRole.Name
            };
        }

        public static VacunaModel Create(Vacuna vacuna, Uri uri)
        {
            VacunaModel vacunaModel = mapper.Map<VacunaModel>(vacuna);
            vacunaModel.Href = uri.AbsoluteUri;
            return vacunaModel;
        }

        public static IEnumerable<VacunaModel> Create(IEnumerable<Vacuna> vacunas)
        {
            IEnumerable<VacunaModel> vacunaModels = mapper.Map<IEnumerable<Vacuna>, IEnumerable<VacunaModel>>(vacunas);
            return vacunaModels;
        }

        public static TratamientoMedicamentoModel Create(TratamientoMedicamento tratamientoMedicamento, Uri uri)
        {
            TratamientoMedicamentoModel tratamientoMedicamentoModel = mapper.Map<TratamientoMedicamentoModel>(tratamientoMedicamento);
            tratamientoMedicamentoModel.Href = uri.AbsoluteUri;
            return tratamientoMedicamentoModel;
        }

        public static IEnumerable<TratamientoMedicamentoModel> Create(IEnumerable<TratamientoMedicamento> tratamientoMedicamentos)
        {
            IEnumerable<TratamientoMedicamentoModel> tratamientoMedicamentoModels = mapper.Map<IEnumerable<TratamientoMedicamento>, IEnumerable<TratamientoMedicamentoModel>>(tratamientoMedicamentos);
            return tratamientoMedicamentoModels;
        }

        public static TratamientoModel Create(Tratamiento tratamiento, Uri uri)
        {
            TratamientoModel tratamientoModel = mapper.Map<TratamientoModel>(tratamiento);
            tratamientoModel.Href = uri.AbsoluteUri;
            return tratamientoModel;
        }

        public static IEnumerable<TratamientoModel> Create(IEnumerable<Tratamiento> tratamientos)
        {
            IEnumerable<TratamientoModel> tratamientoModels = mapper.Map<IEnumerable<Tratamiento>, IEnumerable<TratamientoModel>>(tratamientos);
            return tratamientoModels;
        }

        public static PuestoModel Create(Puesto puesto, Uri uri)
        {
            PuestoModel puestoModel = mapper.Map<PuestoModel>(puesto);
            puestoModel.Href = uri.AbsoluteUri;
            return puestoModel;
        }

        public static IEnumerable<PuestoModel> Create(IEnumerable<Puesto> puestos)
        {
            IEnumerable<PuestoModel> puestoModels = mapper.Map<IEnumerable<Puesto>, IEnumerable<PuestoModel>>(puestos);
            return puestoModels;
        }

        public static ProvinciaModel Create(Provincia provincia, Uri uri)
        {
            ProvinciaModel provinciaModel = mapper.Map<ProvinciaModel>(provincia);
            provinciaModel.Href = uri.AbsoluteUri;
            return provinciaModel;
        }

        public static IEnumerable<ProvinciaModel> Create(IEnumerable<Provincia> provincias)
        {
            IEnumerable<ProvinciaModel> provinciaModels = mapper.Map<IEnumerable<Provincia>, IEnumerable<ProvinciaModel>>(provincias);
            return provinciaModels;
        }

        public static ProcedimientoModel Create(Procedimiento procedimiento, Uri uri)
        {
            ProcedimientoModel procedimientoModel = mapper.Map<ProcedimientoModel>(procedimiento);
            procedimientoModel.Href = uri.AbsoluteUri;
            return procedimientoModel;
        }

        public static IEnumerable<ProcedimientoModel> Create(IEnumerable<Procedimiento> procedimientos)
        {
            IEnumerable<ProcedimientoModel> procedimientoModels = mapper.Map<IEnumerable<Procedimiento>, IEnumerable<ProcedimientoModel>>(procedimientos);
            return procedimientoModels;
        }

        public static MedicamentoModel Create(Medicamento medicamento, Uri uri)
        {
            MedicamentoModel medicamentoModel = mapper.Map<MedicamentoModel>(medicamento);
            medicamentoModel.Href = uri.AbsoluteUri;
            return medicamentoModel;
        }

        public static IEnumerable<MedicamentoModel> Create(IEnumerable<Medicamento> medicamentos)
        {
            IEnumerable<MedicamentoModel> medicamentoModels = mapper.Map<IEnumerable<Medicamento>, IEnumerable<MedicamentoModel>>(medicamentos);
            return medicamentoModels;
        }

        public static MascotaModel Create(Mascota mascota, Uri uri)
        {
            MascotaModel mascotaModel = mapper.Map<MascotaModel>(mascota);
            mascotaModel.Href = uri.AbsoluteUri;
            return mascotaModel;
        }

        public static IEnumerable<MascotaModel> Create(IEnumerable<Mascota> mascotas)
        {
            IEnumerable<MascotaModel> mascotaModels = mapper.Map<IEnumerable<Mascota>, IEnumerable<MascotaModel>>(mascotas);
            return mascotaModels;
        }

        public static InstitucionModel Create(Institucion institucion, Uri uri)
        {
            InstitucionModel institucionModel = mapper.Map<InstitucionModel>(institucion);
            institucionModel.Href = uri.AbsoluteUri;
            return institucionModel;
        }

        public static IEnumerable<InstitucionModel> Create(IEnumerable<Institucion> instituciones)
        {
            IEnumerable<InstitucionModel> institucionModels = mapper.Map<IEnumerable<Institucion>, IEnumerable<InstitucionModel>>(instituciones);
            return institucionModels;
        }

        public static ExpedienteModel Create(Expediente expediente, Uri uri)
        {
            ExpedienteModel expedienteModel = mapper.Map<ExpedienteModel>(expediente);
            expedienteModel.Href = uri.AbsoluteUri;
            return expedienteModel;
        }

        public static IEnumerable<ExpedienteModel> Create(IEnumerable<Expediente> expedientes)
        {
            IEnumerable<ExpedienteModel> expedienteModels = mapper.Map<IEnumerable<Expediente>, IEnumerable<ExpedienteModel>>(expedientes);
            return expedienteModels;
        }

        public static EmpleadoModel Create(Empleado empleado, Uri uri)
        {
            EmpleadoModel empleadoModel = mapper.Map<EmpleadoModel>(empleado);
            empleadoModel.Href = uri.AbsoluteUri;
            return empleadoModel;
        }

        public static IEnumerable<EmpleadoModel> Create(IEnumerable<Empleado> empleados)
        {
            IEnumerable<EmpleadoModel> empleadoModels = mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoModel>>(empleados);
            return empleadoModels;
        }

        public static DomicilioModel Create(Domicilio domicilio, Uri uri)
        {
            DomicilioModel domicilioModel = mapper.Map<DomicilioModel>(domicilio);
            domicilioModel.Href = uri.AbsoluteUri;
            return domicilioModel;
        }

        public static IEnumerable<DomicilioModel> Create(IEnumerable<Domicilio> domicilios)
        {
            IEnumerable<DomicilioModel> domicilioModels = mapper.Map<IEnumerable<Domicilio>, IEnumerable<DomicilioModel>>(domicilios);
            return domicilioModels;
        }

        public static DistritoModel Create(Distrito distrito, Uri uri)
        {
            DistritoModel distritoModel = mapper.Map<DistritoModel>(distrito);
            distritoModel.Href = uri.AbsoluteUri;
            return distritoModel;
        }

        public static IEnumerable<DistritoModel> Create(IEnumerable<Distrito> distritos)
        {
            IEnumerable<DistritoModel> distritoModels = mapper.Map<IEnumerable<Distrito>, IEnumerable<DistritoModel>>(distritos);
            return distritoModels;
        }

        public static CarnetModel Create(Carnet carnet, Uri uri)
        {
            CarnetModel carnetModel = mapper.Map<CarnetModel>(carnet);
            carnetModel.Href = uri.AbsoluteUri;
            return carnetModel;
        }

        public static IEnumerable<CarnetModel> Create(IEnumerable<Carnet> carnets)
        {
            IEnumerable<CarnetModel> carnetModels = mapper.Map<IEnumerable<Carnet>, IEnumerable<CarnetModel>>(carnets);
            return carnetModels;
        }

        public static CantonModel Create(Canton canton, Uri uri)
        {
            CantonModel cantonModel = mapper.Map<CantonModel>(canton);
            cantonModel.Href = uri.AbsoluteUri;
            return cantonModel;
        }

        public static IEnumerable<CantonModel> Create(IEnumerable<Canton> cantons)
        {
            IEnumerable<CantonModel> cantonModels = mapper.Map<IEnumerable<Canton>, IEnumerable<CantonModel>>(cantons);
            return cantonModels;
        }

        public static AspNetUsersModel Create(AspNetUsers user, Uri uri)
        {
            AspNetUsersModel userModel = mapper.Map<AspNetUsersModel>(user);
            userModel.Href = uri.AbsoluteUri;
            return userModel;
        }

        public static IEnumerable<AspNetUsersModel> Create(IEnumerable<AspNetUsers> users)
        {
            IEnumerable<AspNetUsersModel> userModels = mapper.Map<IEnumerable<AspNetUsers>, IEnumerable<AspNetUsersModel>>(users);
            return userModels;
        }

        public static AspNetRolesModel Create(AspNetRoles rol, Uri uri)
        {
            AspNetRolesModel rolModel = mapper.Map<AspNetRolesModel>(rol);
            rolModel.Href = uri.AbsoluteUri;
            return rolModel;
        }

        public static IEnumerable<AspNetRolesModel> Create(IEnumerable<AspNetRoles> rols)
        {
            IEnumerable<AspNetRolesModel> rolModels = mapper.Map<IEnumerable<AspNetRoles>, IEnumerable<AspNetRolesModel>>(rols);
            return rolModels;
        }

        public static AdopcionModel Create(Adopcion adopcion, Uri uri)
        {
            AdopcionModel adopcionModel = mapper.Map<AdopcionModel>(adopcion);
            adopcionModel.Href = uri.AbsoluteUri;
            return adopcionModel;
        }

        public static IEnumerable<AdopcionModel> Create(IEnumerable<Adopcion> adopciones)
        {
            IEnumerable<AdopcionModel> adopcionModels = mapper.Map<IEnumerable<Adopcion>, IEnumerable<AdopcionModel>>(adopciones);
            return adopcionModels;
        }

        public static AdoptanteModel Create(Adoptante adoptante, Uri uri)
        {
            AdoptanteModel adoptanteModel = mapper.Map<AdoptanteModel>(adoptante);
            adoptanteModel.Href = uri.AbsoluteUri;
            return adoptanteModel;
        }

        public static IEnumerable<AdoptanteModel> Create(IEnumerable<Adoptante> adoptantes)
        {
            IEnumerable<AdoptanteModel> adoptanteModels = mapper.Map<IEnumerable<Adoptante>, IEnumerable<AdoptanteModel>>(adoptantes);
            return adoptanteModels;
        }
    }

    public class VacunaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Href { get; set; }
    }
    public class TratamientoMedicamentoModel
    {
        public int TratamientoId { get; set; }
        public string MedicamentoId { get; set; }
        public string Href { get; set; }
    }
    public class TratamientoModel
    {
        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Href { get; set; }
    }
    public class PuestoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Href { get; set; }
    }
    public class ProvinciaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Href { get; set; }
    }
    public class ProcedimientoModel
    {
        public int Id { get; set; }
        public string ExpedienteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Nombre_Procedimiento { get; set; }
        public string Descripcion { get; set; }
        public string Href { get; set; }
    }
    public class MedicamentoModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Href { get; set; }
    }
    public class MascotaModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public string Raza { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public int Edad_Registrada { get; set; }
        public int? AdopcionId { get; set; }
        public DateTime? Fecha_Fallecimiento { get; set; }
        public string ExpedienteId { get; set; }
        public string Href { get; set; }
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
        public string Href { get; set; }
    }
    public class ExpedienteModel
    {
        public string Id { get; set; }
        public string Observaciones { get; set; }
        public bool Castracion { get; set; }
        public string Href { get; set; }
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
        public DomicilioModel Domicilio { get; set; }
        public PuestoModel Puesto { get; set; }
        public string Href { get; set; }
    }
    public class DomicilioModel
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public int CantonId { get; set; }
        public int DistritoId { get; set; }
        public string Direccion { get; set; }
        public DistritoModel Distrito { get; set; }
        public string Href { get; set; }
    }
    public class DistritoModel
    {
        public int Id { get; set; }
        public int CantonId { get; set; }
        public string Nombre { get; set; }
        public CantonModel Canton { get; set; }
        public string Href { get; set; }
    }
    public class CarnetModel
    {
        public string ExpedienteId { get; set; }
        public int VacunaId { get; set; }
        public DateTime Fecha_Vacunacion { get; set; }
        public string Href { get; set; }
    }
    public class CantonModel
    {
        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public ProvinciaModel Provincia { get; set; }
        public string Href { get; set; }
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
        public string Href { get; set; }
    }

    public class AspNetRolesModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
    }
    public class RoleReturnModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
    }

    public class AdopcionModel
    {
        public int Id { get; set; }
        public int InstituionId { get; set; }
        public int AdoptanteId { get; set; }
        public DateTime Fecha_Adopcion { get; set; }
        public string Href { get; set; }
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
        public string Href { get; set; }
    }
}