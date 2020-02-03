namespace PetHouse.BLL.Models
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Direccion { get; set; }

        public Canton Canton { get; set; }

        public Distrito Distrito { get; set; }

        public Provincia Provincia { get; set; }
    }
}