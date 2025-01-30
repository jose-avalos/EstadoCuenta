using AutoMapper;
using EstadoCuentaAPI.DTO;
using EstadoCuentaAPI.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EstadoCuenta, EstadoCuentaDTO>()
            .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.Cliente.Nombre)) 
            .ForMember(dest => dest.NoTarjetaCredito, opt => opt.MapFrom(src => src.Cliente.NoTarjetaCredito));
    }
}