using PetHouse.DAL;

namespace PetHouse.BLL
{
    public class DomicilioMapper
    {
        public DomicilioMapper() { }
        public DomicilioMapper(DomicilioEntity domicilio)
        {
            Direccion = domicilio.Direccion;
            Canton = new CantonMapper(domicilio.Canton);
            Distrito = new DistritoMapper(domicilio.Distrito);
            Provincia = new ProvinciaMapper(domicilio.Provincia);
        }

        public string Direccion { get; set; }

        public virtual CantonMapper Canton { get; set; }

        public virtual DistritoMapper Distrito { get; set; }

        public virtual ProvinciaMapper Provincia { get; set; }
    }
}