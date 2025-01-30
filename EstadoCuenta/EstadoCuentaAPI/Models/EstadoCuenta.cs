using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstadoCuentaAPI.Models
{
    public class EstadoCuenta
    {
        [Key]
        public int EstadoCuentaID { get; set; }

        [Required]
        public int ClienteID { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal Saldo { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal PorcentajeInteresBonificable { get; set; }
        public decimal PorcentajeConfigurableSaldoMin { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoTotalPagar { get; set; }

        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente { get; set; }
    }

        
}
