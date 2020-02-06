using AutoMapper;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ConsultarInstitucionResult, Institucion>();
                cfg.CreateMap<ConsultarRolResult, AspNetRoles>();
                cfg.CreateMap<ConsultarEmpleadoResult, Empleado>();
                cfg.CreateMap<ConsultarCantonResult, Canton>();
                cfg.CreateMap<ConsultarProvinciaResult, Provincia>();
                cfg.CreateMap<ConsultarDistritoResult, Distrito>();
                cfg.CreateMap<ConsultarDomicilioResult, Domicilio>();
                cfg.CreateMap<ConsultarAdopcionResult, Adopcion>();
                cfg.CreateMap<ConsultarAdoptanteResult, Adoptante>();
                cfg.CreateMap<ConsultarVacunaResult, Vacuna>();
                cfg.CreateMap<ConsultarExpedienteResult, Expediente>();
            });
            return config;
        }
    }
}
