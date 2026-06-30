using PetConnect.Application.Interfaces;
using PetConnect.Application.UseCases;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Services;

public class SolicitudAdopcionService
{
    private readonly ISolicitudAdopcionRepository _solicitudRepository;
    private readonly CrearSolicitudAdopcionUseCase _crearSolicitudUseCase;
    private readonly CambiarEstadoSolicitudUseCase _cambiarEstadoUseCase;

    public SolicitudAdopcionService(
        ISolicitudAdopcionRepository solicitudRepository,
        CrearSolicitudAdopcionUseCase crearSolicitudUseCase,
        CambiarEstadoSolicitudUseCase cambiarEstadoUseCase)
    {
        _solicitudRepository = solicitudRepository;
        _crearSolicitudUseCase = crearSolicitudUseCase;
        _cambiarEstadoUseCase = cambiarEstadoUseCase;
    }

    public IReadOnlyList<SolicitudAdopcion> Listar()
    {
        return _solicitudRepository.ObtenerTodas();
    }

    public SolicitudAdopcion Crear(SolicitudAdopcion solicitud)
    {
        return _crearSolicitudUseCase.Ejecutar(solicitud);
    }

    public void CambiarEstado(int id, EstadoSolicitud estado)
    {
        _cambiarEstadoUseCase.Ejecutar(id, estado);
    }
}
