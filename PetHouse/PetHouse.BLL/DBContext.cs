using PetHouse.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHouse.BLL
{
    public class DBContext
    {
        public PetHouseModel DB => new PetHouseModel();
    }
}
