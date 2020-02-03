namespace PetHouse.BLL
{
    using PetHouse.DAL;
    public partial class CantonMapper
    {
        public CantonMapper() { }
        public CantonMapper(CantonEntity canton)
        {
            Nombre = canton.Nombre;
        }
        public string Nombre { get; set; }
    }
}
