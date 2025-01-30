using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstadoCuentaAPI.Models;
using System.Threading.Tasks;
using EstadoCuentaAPI.Data;
using EstadoCuentaAPI.DTO;

[Route("api/Movimientos")]
[ApiController]
public class MovimientosController : ControllerBase
{
    private readonly EstadoCuentaDbContext _context;

    public MovimientosController(EstadoCuentaDbContext context)
    {
        _context = context;
    }

    [HttpPost("RegistrarCompra")]
    public async Task<IActionResult> RegistrarCompra([FromBody] CompraDTO compra)
    {
        if (compra == null)
            return BadRequest("Datos de compra inválidos.");

        try
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "EXEC CrearCompra @ClienteID, @Fecha, @Descripcion, @Monto";
                    command.CommandType = System.Data.CommandType.Text;

                    var paramClienteID = command.CreateParameter();
                    paramClienteID.ParameterName = "@ClienteID";
                    paramClienteID.Value = compra.ClienteID;
                    command.Parameters.Add(paramClienteID);

                    var paramFecha = command.CreateParameter();
                    paramFecha.ParameterName = "@Fecha";
                    paramFecha.Value = compra.Fecha;
                    command.Parameters.Add(paramFecha);

                    var paramDescripcion = command.CreateParameter();
                    paramDescripcion.ParameterName = "@Descripcion";
                    paramDescripcion.Value = compra.Descripcion;
                    command.Parameters.Add(paramDescripcion);

                    var paramMonto = command.CreateParameter();
                    paramMonto.ParameterName = "@Monto";
                    paramMonto.Value = compra.Monto;
                    command.Parameters.Add(paramMonto);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return Ok("Compra registrada exitosamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al registrar compra: {ex.Message}");
        }
    }



    [HttpPost("RegistrarPago")]
    public async Task<IActionResult> RegistrarPago([FromBody] PagoDTO pago)
    {
        if (pago == null)
            return BadRequest("Datos de pago inválidos.");

        try
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "EXEC AgregarPago @ClienteID, @Fecha, @Monto";
                    command.CommandType = System.Data.CommandType.Text;

                    var paramClienteID = command.CreateParameter();
                    paramClienteID.ParameterName = "@ClienteID";
                    paramClienteID.Value = pago.ClienteID;
                    command.Parameters.Add(paramClienteID);

                    var paramFecha = command.CreateParameter();
                    paramFecha.ParameterName = "@Fecha";
                    paramFecha.Value = pago.Fecha;
                    command.Parameters.Add(paramFecha);

                    var paramMonto = command.CreateParameter();
                    paramMonto.ParameterName = "@Monto";
                    paramMonto.Value = pago.Monto;
                    command.Parameters.Add(paramMonto);

                    await command.ExecuteNonQueryAsync();
                }
            }

            return Ok("Pago registrado exitosamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al registrar pago: {ex.Message}");
        }
    }

    [HttpGet("Historial/{clienteId}")]
    public async Task<IActionResult> ObtenerHistorial(int clienteId)
    {
        var movimientos = await _context.Movimientos
            .Where(m => m.ClienteID == clienteId)
            .OrderByDescending(m => m.Fecha)
            .ToListAsync();

        if (movimientos == null || movimientos.Count == 0)
            return NotFound("No hay transacciones registradas para este cliente.");

        return Ok(movimientos);
    }

    [HttpGet("Compras/{clienteId}")]
    public async Task<IActionResult> ObtenerCompras(int clienteId)
    {
        var compras = await _context.Movimientos
            .Where(m => m.ClienteID == clienteId && m.TipoMovimiento == "COMPRA")
            .OrderByDescending(m => m.Fecha)
            .ToListAsync();

        if (compras == null || compras.Count == 0)
            return NotFound("No hay compras registradas para este cliente.");

        return Ok(compras);
    }
}
