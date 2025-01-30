namespace EstadoCuentaAPI.DTO
{
    public class MovimientoDTO
    {
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string TipoMovimiento { get; set; }
    }

}
