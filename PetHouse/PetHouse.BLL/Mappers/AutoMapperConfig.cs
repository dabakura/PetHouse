using AutoMapper;
using PetHouse.BLL.Repositorios;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
                cfg.CreateMap<ConsultarAdopcionResult, Adopcion>().AfterMap((orig, dest) => {
                    dest.Institucion = new InstitucionRepositorio().Get(orig.InstitucionId.ToString());
                    dest.Adoptante = new AdoptanteRepositorio().Get(orig.AdoptanteId.ToString());
                    dest.Mascota = new MascotaRepositorio().Get(orig.MascotaId);
                });
                cfg.CreateMap<BuscarAdopcionResult, Adopcion>().AfterMap((orig, dest) => {
                    dest.Institucion = new InstitucionRepositorio().Get(orig.InstitucionId.ToString());
                    dest.Adoptante = new AdoptanteRepositorio().Get(orig.AdoptanteId.ToString());
                    dest.Mascota = new MascotaRepositorio().Get(orig.MascotaId);
                });
                cfg.CreateMap<ConsultarAdoptanteResult, Adoptante>().AfterMap((orig, dest) =>
                    dest.Domicilio = new DomicilioRepositorio().Get(orig.DomicilioId.ToString())
                );
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
                cfg.CreateMap<ConsultarCarnetResult, Carnet>().AfterMap((orig, dest) => {
                    dest.Vacuna = new VacunaRepositorio().Get(orig.VacunaId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
                cfg.CreateMap<BuscarCarnetResult, Carnet>().AfterMap((orig, dest) => {
                    dest.Vacuna = new VacunaRepositorio().Get(orig.VacunaId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
                cfg.CreateMap<Carnet, Carnet>().AfterMap((orig, dest) => {
                    dest.Vacuna = new VacunaRepositorio().Get(orig.VacunaId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
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
                cfg.CreateMap<BuscarMascotaResult, Mascota>().AfterMap((orig, dest) => 
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId)
                );
                cfg.CreateMap<ConsultarMedicamentoResult, Medicamento>();
                cfg.CreateMap<BuscarMedicamentoResult, Medicamento>();
                cfg.CreateMap<ConsultarProcedimientoResult, Procedimiento>().AfterMap((orig, dest) => {
                    dest.Empleado = new EmpleadoRepositorio().Get(orig.EmpleadoId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
                cfg.CreateMap<BuscarProcedimientoResult, Procedimiento>().AfterMap((orig, dest) => {
                    dest.Empleado = new EmpleadoRepositorio().Get(orig.EmpleadoId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
                cfg.CreateMap<ConsultarProcedimientoByIdResult, Procedimiento>().AfterMap((orig, dest) => {
                    dest.Empleado = new EmpleadoRepositorio().Get(orig.EmpleadoId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                });
                cfg.CreateMap<ConsultarProvinciaResult, Provincia>();
                cfg.CreateMap<BuscarProvinciaResult, Provincia>();
                cfg.CreateMap<ConsultarPuestoResult, Puesto>();
                cfg.CreateMap<BuscarPuestoResult, Puesto>();
                cfg.CreateMap<ConsultarTratamientoResult, Tratamiento>().AfterMap((orig, dest) => {
                    dest.Empleado = new EmpleadoRepositorio().Get(orig.EmpleadoId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                    var Tratamientosmadicamentos = new EntitySet<TratamientoMedicamento>();
                    Tratamientosmadicamentos.AddRange(new TratamientoMedicamentoRepositorio().Get(orig.Id.ToString()));
                    dest.TratamientoMedicamentos = Tratamientosmadicamentos;
                });
                cfg.CreateMap<BuscarTratamientoResult, Tratamiento>().AfterMap((orig, dest) => {
                    dest.Empleado = new EmpleadoRepositorio().Get(orig.EmpleadoId.ToString());
                    dest.Expediente = new ExpedienteRepositorio().Get(orig.ExpedienteId);
                    var Tratamientosmadicamentos = new EntitySet<TratamientoMedicamento>();
                    Tratamientosmadicamentos.AddRange(new TratamientoMedicamentoRepositorio().Get(orig.Id.ToString()));
                    dest.TratamientoMedicamentos = Tratamientosmadicamentos;
                });
                cfg.CreateMap<ConsultarTratamientoMedicamentoResult, TratamientoMedicamento>().AfterMap((orig, dest) => {
                    dest.Tratamiento = new Tratamiento { Id = orig.TratamientoId };
                    dest.Medicamento = new MedicamentoRepositorio().Get(orig.MedicamentoId);
                });
                cfg.CreateMap<BuscarTratamientoMedicamentoResult, TratamientoMedicamento>().AfterMap((orig, dest) => {
                    dest.Tratamiento = new Tratamiento { Id = orig.TratamientoId };
                    dest.Medicamento = new MedicamentoRepositorio().Get(orig.MedicamentoId);
                });
                cfg.CreateMap<ConsultarVacunaResult, Vacuna>();
                cfg.CreateMap<BuscarVacunaResult, Vacuna>();
                cfg.CreateMap<BuscarPersonaResult, Persona>();
                cfg.CreateMap<ConsultarEventoResult, Evento>();
                cfg.CreateMap<BuscarEventoResult, Evento>();
            });
            return config;
        }
    }
}
