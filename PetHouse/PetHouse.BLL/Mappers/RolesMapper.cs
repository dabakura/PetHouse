namespace PetHouse.BLL
{
    using PetHouse.DAL;

    public class RolesMapper
    {
        public RolesMapper()
        {
            
        }

        public RolesMapper(AspNetRolesEntity rol)
        {
            Id = rol.Id;
            Name = rol.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
