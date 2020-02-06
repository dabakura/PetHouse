using AutoMapper;
using PetHouse.BLL.Mappers;
using PetHouse.DAL.Entities;

namespace PetHouse.BLL
{
    public class DBContext
    {
        public PetHouseDataContext DB => new PetHouseDataContext();
        public static IMapper mapper = AutoMapperConfig.Initialize().CreateMapper();
    }
}
