using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EstadoCuentaWeb.Models;

public class EstadoCuentaController : Controller
{
    private readonly ApiService _apiService;

    public EstadoCuentaController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index(int clienteId = 1) 
    {
        try
        {
            var estadoCuenta = await _apiService.GetAsync<EstadoCuentaDTO>($"EstadoCuenta/{clienteId}");
            var compras = await _apiService.GetCompras(clienteId) ?? new List<MovimientoDTO>();

            ViewBag.Compras = compras;

            return View(estadoCuenta ?? new EstadoCuentaDTO());
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            ViewBag.Compras = new List<MovimientoDTO>();
            return View(new EstadoCuentaDTO());
        }
    }
}