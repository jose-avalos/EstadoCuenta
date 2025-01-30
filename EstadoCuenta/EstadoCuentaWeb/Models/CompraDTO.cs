namespace EstadoCuentaWeb.Models
{
    public class CompraDTO
    {
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
