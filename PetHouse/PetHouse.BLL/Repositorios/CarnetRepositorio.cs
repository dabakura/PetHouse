﻿using PetHouse.BLL.Services;
using PetHouse.BLL.Mappers;
using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Repositorios
{
    public class CarnetRepositorio : DBContext, ICarnetService
    {
        public bool Delete(string idExpediente, int idVacuna)
        {
            try
            {
                DB.EliminarCarnet(idExpediente);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Carnet> Get(string id)
        {
            try
            {
                var CarnetsResult = DB.BuscarCarnet(id).ToList();
                var Carnets = mapper.Map<IEnumerable<BuscarCarnetResult>, IEnumerable<Carnet>>(CarnetsResult);
                return Carnets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Carnet> GetAll()
        {
            try
            {
                var CarnetsResult = DB.ConsultarCarnet().ToList();
                var Carnets = mapper.Map<IEnumerable<ConsultarCarnetResult>, IEnumerable<Carnet>>(CarnetsResult);
                return Carnets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Carnet entity)
        {
            try
            {
                DB.InsertarCarnet(entity.ExpedienteId, entity.VacunaId, entity.Fecha_Vacunacion);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}