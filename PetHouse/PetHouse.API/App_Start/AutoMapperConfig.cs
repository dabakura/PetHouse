using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using PetHouse.API.Models;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.API.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Adopcion, AdopcionModel>();
                cfg.CreateMap<Adoptante, AdoptanteModel>();
                cfg.CreateMap<AspNetRoles, AspNetRolesModel>();
                cfg.CreateMap<IdentityRole, AspNetRolesModel>();
                cfg.CreateMap<AspNetUsers, AspNetUsersModel>();
                cfg.CreateMap<Canton, CantonModel>();
                cfg.CreateMap<Carnet, CarnetModel>();
                cfg.CreateMap<Distrito, DistritoModel>();
                cfg.CreateMap<Domicilio, DomicilioModel>();
                cfg.CreateMap<Empleado, EmpleadoModel>();
                cfg.CreateMap<Expediente, ExpedienteModel>();
                cfg.CreateMap<Institucion, InstitucionModel>();
                cfg.CreateMap<Mascota, MascotaModel>();
                cfg.CreateMap<Medicamento, MedicamentoModel>();
                cfg.CreateMap<Procedimiento, ProcedimientoModel>();
                cfg.CreateMap<Provincia, ProvinciaModel>();
                cfg.CreateMap<Puesto, PuestoModel>();
                cfg.CreateMap<Tratamiento, TratamientoModel>();
                cfg.CreateMap<TratamientoMedicamento, TratamientoMedicamentoModel>();
                cfg.CreateMap<Vacuna, VacunaModel>();
                cfg.CreateMap<Persona, PersonaModel>();
            });
            return config;
        }
    }
}