using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMIDDevelop.entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        [ForeignKey("Persona")]
        public int PersonaID { get; set; }
        public Persona Persona { get; set; }

    }
}
