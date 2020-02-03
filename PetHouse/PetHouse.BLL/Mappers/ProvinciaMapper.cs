namespace PetHouse.BLL
{
    using PetHouse.DAL;
    public partial class ProvinciaMapper
    {
        public ProvinciaMapper() { }
        public ProvinciaMapper(ProvinciaEntity provincia)
        {
            Nombre = provincia.Nombre;
        }
        public string Nombre { get; set; }
    }
}
