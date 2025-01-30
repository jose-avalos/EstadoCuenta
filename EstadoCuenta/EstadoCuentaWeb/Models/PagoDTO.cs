namespace EstadoCuentaWeb.Models
{
    public class PagoDTO
    {
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
