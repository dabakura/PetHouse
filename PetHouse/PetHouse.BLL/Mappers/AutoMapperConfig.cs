using AutoMapper;
using PetHouse.BLL.Repositorios;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ConsultarAdopcionResult, Adopcion>();
                cfg.CreateMap<BuscarAdopcionResult, Adopcion>();
                cfg.CreateMap<ConsultarAdoptanteResult, Adoptante>();
                cfg.CreateMap<BuscarAdoptanteResult, Adoptante>().AfterMap((orig, dest) =>
                    dest.Domicilio = new Domicilio
                    {
                        Id = orig.DomicilioId,
                        CantonId = orig.CantonId,
                        DistritoId = orig.DistritoId,
                        ProvinciaId = orig.ProvinciaId,
                        Direccion = orig.Direccion,
                        Distrito = new Distrito
                        {
                            Id = orig.DistritoId,
                            CantonId = orig.CantonId,
                            Nombre = orig.DistritoName,
                            Canton = new Canton
                            {
                                Id = orig.CantonId,
                                ProvinciaId = orig.ProvinciaId,
                                Nombre = orig.CantonName,
                                Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                            }
                        }
                    }
                );
                cfg.CreateMap<ConsultarRolResult, AspNetRoles>();
                cfg.CreateMap<BuscarRolResult, AspNetRoles>();
                cfg.CreateMap<ConsultarUserResult, AspNetUsers>();
                cfg.CreateMap<ConsultarCantonResult, Canton>().AfterMap((orig, dest) =>
                    dest.Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                );
                cfg.CreateMap<BuscarCantonResult, Canton>().AfterMap((orig, dest) =>
                    dest.Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                );
                cfg.CreateMap<ConsultarCarnetResult, Carnet>();
                cfg.CreateMap<BuscarCarnetResult, Carnet>();
                cfg.CreateMap<ConsultarDistritoResult, Distrito>().AfterMap((orig, dest) =>
                    dest.Canton = new Canton
                    {
                        Id = orig.CantonId,
                        ProvinciaId = orig.CantonProvinciaId,
                        Nombre = orig.CantonName,
                        Provincia = new Provincia { Id = orig.CantonProvinciaId, Nombre = orig.ProvinciaName }
                    }
                );
                cfg.CreateMap<BuscarDistritoResult, Distrito>().AfterMap((orig, dest) =>
                    dest.Canton = new Canton
                    {
                        Id = orig.CantonId,
                        ProvinciaId = orig.CantonProvinciaId,
                        Nombre = orig.CantonName,
                        Provincia = new Provincia { Id = orig.CantonProvinciaId, Nombre = orig.ProvinciaName }
                    }
                );
                cfg.CreateMap<ConsultarDomicilioResult, Domicilio>().AfterMap((orig, dest) =>
                    dest.Distrito = new Distrito
                    {
                        Id = orig.DistritoId,
                        CantonId = orig.CantonId,
                        Nombre = orig.DistritoName,
                        Canton = new Canton
                        {
                            Id = orig.CantonId,
                            ProvinciaId = orig.ProvinciaId,
                            Nombre = orig.CantonName,
                            Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                        }
                    }
                );
                cfg.CreateMap<BuscarDomicilioResult, Domicilio>().AfterMap((orig, dest) =>
                    dest.Distrito = new Distrito
                    {
                        Id = orig.DistritoId,
                        CantonId = orig.CantonId,
                        Nombre = orig.DistritoName,
                        Canton = new Canton
                        {
                            Id = orig.CantonId,
                            ProvinciaId = orig.ProvinciaId,
                            Nombre = orig.CantonName,
                            Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                        }
                    }
                );
                cfg.CreateMap<ConsultarEmpleadoResult, Empleado>();
                cfg.CreateMap<BuscarEmpleadoResult, Empleado>().AfterMap((orig, dest) => {
                    dest.Puesto = new Puesto { Id = orig.PuestoID, Nombre = orig.PuestoName, Descripcion = orig.PuestoDescripcion };
                    dest.Domicilio = new Domicilio
                    {
                        Id = orig.DomicilioId,
                        CantonId = orig.CantonId,
                        DistritoId = orig.DistritoId,
                        ProvinciaId = orig.ProvinciaId,
                        Direccion = orig.Direccion,
                        Distrito = new Distrito
                        {
                            Id = orig.DistritoId,
                            CantonId = orig.CantonId,
                            Nombre = orig.DistritoName,
                            Canton = new Canton
                            {
                                Id = orig.CantonId,
                                ProvinciaId = orig.ProvinciaId,
                                Nombre = orig.CantonName,
                                Provincia = new Provincia { Id = orig.ProvinciaId, Nombre = orig.ProvinciaName }
                            }
                        }
                    };
                    dest.Institucion = new Institucion
                    {
                        Id = orig.InstitucionId,
                        Ced_Juridica = orig.Ced_Juridica,
                        Correo = orig.InstitucionCorreo,
                        Fax = orig.Fax,
                        Nombre = orig.InstitucionName,
                        Pag_Web = orig.Pag_Web,
                        Telefono = orig.Telefono
                    };
                });
                cfg.CreateMap<ConsultarExpedienteResult, Expediente>();
                cfg.CreateMap<BuscarExpedienteResult, Expediente>();
                cfg.CreateMap<ConsultarInstitucionResult, Institucion>().AfterMap((orig, dest) =>
                    dest.Domicilio = new DomicilioRepositorio().Get(orig.DireccionId.ToString())
                );
                cfg.CreateMap<BuscarInstitucionResult, Institucion>().AfterMap((orig, dest) =>
                    dest.Domicilio = new DomicilioRepositorio().Get(orig.DireccionId.ToString())
                );
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
                cfg.CreateMap<BuscarPersonaResult, Persona>();
            });
            return config;
        }
    }
}
