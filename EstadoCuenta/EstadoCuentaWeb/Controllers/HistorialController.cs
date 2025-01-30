using Microsoft.AspNetCore.Mvc;
using EstadoCuentaWeb.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

public class HistorialController : Controller
{
    private readonly ApiService _apiService;
    private readonly PdfService _pdfService;

    public HistorialController(ApiService apiService, PdfService pdfService)
    {
        _apiService = apiService;
        _pdfService = pdfService;
    }

    public async Task<IActionResult> Index(int clienteId = 1)
    {
        try
        {
            var historial = await _apiService.GetHistorial(clienteId);
            return View(historial);
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
            return View(new List<MovimientoDTO>());
        }
    }

    
    public async Task<IActionResult> ExportarPdf(int clienteId)
    {
        var historial = await _apiService.GetHistorial(clienteId);
        byte[] pdfBytes = _pdfService.GenerateHistorialPdf(historial);

        return File(pdfBytes, "application/pdf", "Historial_Transacciones.pdf");
    }
}
