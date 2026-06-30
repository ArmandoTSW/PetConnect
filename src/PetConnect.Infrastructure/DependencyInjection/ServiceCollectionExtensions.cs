using Microsoft.Extensions.DependencyInjection;
using PetConnect.Application.Interfaces;
using PetConnect.Application.Services;
using PetConnect.Application.UseCases;
using PetConnect.Infrastructure.Repositories;

namespace PetConnect.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPetConnectServices(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryDataStore>();
        services.AddScoped<IMascotaRepository, MascotaRepository>();
        services.AddScoped<IAdoptanteRepository, AdoptanteRepository>();
        services.AddScoped<ISolicitudAdopcionRepository, SolicitudAdopcionRepository>();
        services.AddScoped<MascotaService>();
        services.AddScoped<AdoptanteService>();
        services.AddScoped<SolicitudAdopcionService>();
        services.AddScoped<CrearSolicitudAdopcionUseCase>();
        services.AddScoped<CambiarEstadoSolicitudUseCase>();

        return services;
    }
}
