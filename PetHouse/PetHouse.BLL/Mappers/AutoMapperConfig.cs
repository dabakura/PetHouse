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
                cfg.CreateMap<ConsultarAdopcionResult, Adopcion>();
                cfg.CreateMap<BuscarAdopcionResult, Adopcion>();
                cfg.CreateMap<ConsultarAdoptanteResult, Adoptante>();
                cfg.CreateMap<BuscarAdoptanteResult, Adoptante>();
                cfg.CreateMap<ConsultarRolResult, AspNetRoles>();
                cfg.CreateMap<BuscarRolResult, AspNetRoles>();
                cfg.CreateMap<ConsultarUserResult, AspNetUsers>();
                cfg.CreateMap<ConsultarCantonResult, Canton>();
                cfg.CreateMap<BuscarCantonResult, Canton>();
                cfg.CreateMap<ConsultarCarnetResult, Carnet>();
                cfg.CreateMap<BuscarCarnetResult, Carnet>();
                cfg.CreateMap<ConsultarDistritoResult, Distrito>();
                cfg.CreateMap<BuscarDistritoResult, Distrito>();
                cfg.CreateMap<ConsultarDomicilioResult, Domicilio>();
                cfg.CreateMap<BuscarDomicilioResult, Domicilio>();
                cfg.CreateMap<ConsultarEmpleadoResult, Empleado>();
                cfg.CreateMap<BuscarEmpleadoResult, Empleado>();
                cfg.CreateMap<ConsultarExpedienteResult, Expediente>();
                cfg.CreateMap<BuscarExpedienteResult, Expediente>();
                cfg.CreateMap<ConsultarInstitucionResult, Institucion>();
                cfg.CreateMap<BuscarInstitucionResult, Institucion>();
                cfg.CreateMap<ConsultarMascotaResult, Mascota>();
                cfg.CreateMap<BuscarMascotaResult, Mascota>();
                cfg.CreateMap<ConsultarMedicamentoResult, Medicamento>();
                cfg.CreateMap<BuscarMedicamentoResult, Medicamento>();
                cfg.CreateMap<ConsultarProcedimientoResult, Procedimiento>();
                cfg.CreateMap<BuscarProcedimientoResult, Procedimiento>();
                cfg.CreateMap<ConsultarProvinciaResult, Provincia>();
                cfg.CreateMap<BuscarProvinciaResult, Provincia>();
                cfg.CreateMap<ConsultarPuestoResult, Puesto>();
                cfg.CreateMap<BuscarPuestoResult, Puesto>();
                cfg.CreateMap<ConsultarTratamientoResult, Tratamiento>();
                cfg.CreateMap<BuscarTratamientoResult, Tratamiento>();
                cfg.CreateMap<ConsultarTratamientoMedicamentoResult, TratamientoMedicamento>();
                cfg.CreateMap<BuscarTratamientoMedicamentoResult, TratamientoMedicamento>();
                cfg.CreateMap<ConsultarVacunaResult, Vacuna>();
                cfg.CreateMap<BuscarVacunaResult, Vacuna>();
            });
            return config;
        }
    }
}
