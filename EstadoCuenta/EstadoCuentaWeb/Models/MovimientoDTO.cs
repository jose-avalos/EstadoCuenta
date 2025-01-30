namespace EstadoCuentaWeb.Models
{
    public class MovimientoDTO
    {

        public int MovimientoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
