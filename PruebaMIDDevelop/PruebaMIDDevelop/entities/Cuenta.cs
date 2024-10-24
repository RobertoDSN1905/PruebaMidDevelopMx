using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMIDDevelop.entities
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public float SaldoInicial { get; set; }
        public bool Estado {  get; set; }
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }


    }
}
