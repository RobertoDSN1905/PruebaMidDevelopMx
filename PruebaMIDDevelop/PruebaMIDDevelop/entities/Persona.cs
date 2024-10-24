using System.ComponentModel.DataAnnotations;

namespace PruebaMIDDevelop.entities
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono  { get; set; }

    }
}
