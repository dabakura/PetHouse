namespace PetHouse.BLL
{
    using PetHouse.DAL;
    public partial class DistritoMapper
    {
        public DistritoMapper() { }
        public DistritoMapper(DistritoEntity distrito)
        {
            Nombre = distrito.Nombre;
        }
        public string Nombre { get; set; }
    }
}
