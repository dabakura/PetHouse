﻿using PetHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL.Services
{
    public interface ITratamientoMedicamentoService
    {
        IEnumerable<TratamientoMedicamento> GetAll();
        IEnumerable<TratamientoMedicamento> Get(string id);
        bool Insert(TratamientoMedicamento entity);

        bool Delete(int idTratamiento, string idMedicamento);

    }
}
