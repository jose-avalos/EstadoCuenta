namespace EstadoCuentaAPI.Models
{
    public class Movimiento
    {
        public int MovimientoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
