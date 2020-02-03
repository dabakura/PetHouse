using PetHouse.DAL;

namespace PetHouse.BLL
{
    public class InstitucionMapper
    {
        public InstitucionMapper(InstitucionEntity institucion)
        {
            Id = institucion.Id;
            Ced_Juridica = institucion.Ced_Juridica;
            Nombre = institucion.Nombre;
            Telefono = institucion.Telefono;
            Fax = institucion.Fax;
            Pag_Web = institucion.Pag_Web;
            Correo = institucion.Correo;
            Domicilio = new DomicilioMapper(institucion.Domicilio);
        }

        public int Id { get; set; }
        public string Ced_Juridica { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Fax { get; set; }
        public string Pag_Web { get; set; }
        public string Correo { get; set; }
        public  DomicilioMapper Domicilio { get; set; }
    }
}
