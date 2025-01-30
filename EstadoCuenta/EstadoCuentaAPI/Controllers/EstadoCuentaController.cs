using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EstadoCuentaAPI.Models;
using EstadoCuentaAPI.Data;
using EstadoCuentaAPI.DTO;

[Route("api/[controller]")]
[ApiController]
public class EstadoCuentaController : ControllerBase
{
    private readonly EstadoCuentaDbContext _context;
    private readonly IMapper _mapper;

    public EstadoCuentaController(EstadoCuentaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{clienteId}")]
    public async Task<IActionResult> ObtenerEstadoCuenta(int clienteId)
    {
        var estadoCuenta = await _context.EstadosCuenta
            .Include(e => e.Cliente) 
            .FirstOrDefaultAsync(e => e.ClienteID == clienteId);

        if (estadoCuenta == null)
            return NotFound("Estado de cuenta no encontrado."); 

        var estadoCuentaDTO = _mapper.Map<EstadoCuentaDTO>(estadoCuenta);
        return Ok(estadoCuentaDTO);
    }
}
