using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EstadoCuentaWeb.Models;

public class ApiService
{
    private readonly string _apiUrl;

    public ApiService(IConfiguration configuration)
    {
        _apiUrl = configuration["ApiUrl"];
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        var client = new RestClient(new RestClientOptions(_apiUrl)
        {
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true 
        });

        var request = new RestRequest(endpoint, Method.Get);
        var response = await client.ExecuteAsync(request);

        Console.WriteLine($"API Status Code: {response.StatusCode}");
        Console.WriteLine($"API Response Content: {response.Content}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error al llamar a la API: {response.StatusCode} - {response.Content}");
        }

        return JsonConvert.DeserializeObject<T>(response.Content);
    }


    public async Task<bool> PostAsync<T>(string endpoint, T data)
    {
        var client = new RestClient(_apiUrl);
        var request = new RestRequest(endpoint, Method.Post);
        
        string jsonBody = JsonConvert.SerializeObject(data);
        request.AddStringBody(jsonBody, DataFormat.Json);

        var response = await client.ExecuteAsync(request);

        Console.WriteLine($"API Status Code: {response.StatusCode}");
        Console.WriteLine($"API Response Content: {response.Content}");

        return response.IsSuccessful;
    }

    public async Task<List<MovimientoDTO>> GetHistorial(int clienteId)
    {
        var client = new RestClient(_apiUrl);
        var request = new RestRequest($"Movimientos/Historial/{clienteId}", Method.Get);
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"Error al llamar a la API: {response.StatusCode} - {response.Content}");

        return JsonConvert.DeserializeObject<List<MovimientoDTO>>(response.Content);
    }

    public async Task<List<MovimientoDTO>> GetCompras(int clienteId)
    {
        var client = new RestClient(_apiUrl);
        var request = new RestRequest($"Movimientos/Compras/{clienteId}", Method.Get);
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"Error al llamar a la API: {response.StatusCode} - {response.Content}");

        return JsonConvert.DeserializeObject<List<MovimientoDTO>>(response.Content);
    }

    public async Task<bool> RegistrarPago(PagoDTO pago)
    {
        var client = new RestClient(_apiUrl);
        var request = new RestRequest("Movimientos/RegistrarPago", Method.Post);
        request.AddJsonBody(pago);

        var response = await client.ExecuteAsync(request);

        return response.IsSuccessful;
    }

    public async Task<bool> RegistrarCompra(CompraDTO compra)
    {
        var client = new RestClient(_apiUrl);
        var request = new RestRequest("Movimientos/RegistrarCompra", Method.Post);
        request.AddJsonBody(compra);

        var response = await client.ExecuteAsync(request);

        return response.IsSuccessful;
    }

}
