namespace EstadoCuentaWeb.Models
{
    public class EstadoCuentaDTO
    {
        public string NombreCliente { get; set; }
        public string NoTarjetaCredito { get; set; }
        public decimal Saldo { get; set; }
        public decimal LimiteCredito { get; set; }
        //public decimal SaldoDisponible { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoTotalPagar { get; set; }

        public decimal SaldoDisponible => LimiteCredito - Saldo;
    }
}
