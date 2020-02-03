﻿using PetHouse.BLL.Interfaces;
using PetHouse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PetHouse.BLL.Models;
using PetHouse.BLL.Mappers;

namespace PetHouse.BLL
{
    public class ClsInstitucion : DBContext, IIntitucion
    {
        private static ClsInstitucion _instance;

        public static ClsInstitucion Instance => _instance ?? (_instance = new ClsInstitucion());

        public async Task<IEnumerable<Institucion>> GetAllAsync()
        {
            var instituciones = await DB.Instituciones
                .Include(i => i.Domicilio)
                .Include(i => i.Domicilio.Canton)
                .Include(i => i.Domicilio.Provincia)
                .Include(i => i.Domicilio.Distrito)
                .Where(institucion => institucion.Estado.Value)
                .ToListAsync();
            var ListInstituciones = from insti in instituciones
                                    select InstitucionMapper.Map(insti);
            return ListInstituciones;
        }
    }
}