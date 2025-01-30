using Microsoft.AspNetCore.Mvc;
using EstadoCuentaWeb.Models;
using System.Threading.Tasks;


    public class ComprasController : Controller
    {
        private readonly ApiService _apiService;

        public ComprasController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View(new CompraDTO());
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCompra(CompraDTO compra)
        {
            compra.Fecha = DateTime.Now; // Asignar fecha actual

            bool resultado = await _apiService.RegistrarCompra(compra);

            if (resultado)
                return RedirectToAction("Index", "EstadoCuenta");

            ViewBag.Error = "No se pudo realizar la compra.";
            return View("Index", compra);
        }
    }


