namespace EstadoCuentaAPI.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string NoTarjetaCredito { get; set; }
        public EstadoCuenta EstadoCuenta { get; set; }
    }
}
