using Microsoft.AspNetCore.Http.Timeouts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMIDDevelop.entities
{
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public float SaldoDisponible { get; set; }
        [ForeignKey("Cuenta")]
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }

    }
}
