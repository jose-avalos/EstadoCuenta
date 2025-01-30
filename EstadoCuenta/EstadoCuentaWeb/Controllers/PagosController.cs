using Microsoft.AspNetCore.Mvc;
using EstadoCuentaWeb.Models;
using System.Threading.Tasks;

public class PagosController : Controller
{
    private readonly ApiService _apiService;

    public PagosController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        return View(new PagoDTO());
    }

    [HttpPost]
    public async Task<IActionResult> RealizarPago(PagoDTO pago)
    {
        pago.Fecha = DateTime.Now; 

        bool resultado = await _apiService.RegistrarPago(pago);

        if (resultado)
            return RedirectToAction("Index", "EstadoCuenta");

        ViewBag.Error = "No se pudo realizar el pago.";
        return View("Index", pago);
    }
}
