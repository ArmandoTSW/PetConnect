using PetConnect.Application.DTOs;
using PetConnect.Application.Interfaces;
using PetConnect.Application.UseCases;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Services;

public class SolicitudAdopcionService
{
    private readonly ISolicitudAdopcionRepository _solicitudRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IAdoptanteRepository _adoptanteRepository;
    private readonly CrearSolicitudAdopcionUseCase _crearSolicitudUseCase;
    private readonly CambiarEstadoSolicitudUseCase _cambiarEstadoUseCase;

    public SolicitudAdopcionService(
        ISolicitudAdopcionRepository solicitudRepository,
        IMascotaRepository mascotaRepository,
        IAdoptanteRepository adoptanteRepository,
        CrearSolicitudAdopcionUseCase crearSolicitudUseCase,
        CambiarEstadoSolicitudUseCase cambiarEstadoUseCase)
    {
        _solicitudRepository = solicitudRepository;
        _mascotaRepository = mascotaRepository;
        _adoptanteRepository = adoptanteRepository;
        _crearSolicitudUseCase = crearSolicitudUseCase;
        _cambiarEstadoUseCase = cambiarEstadoUseCase;
    }

    public IReadOnlyList<SolicitudAdopcion> Listar()
    {
        return _solicitudRepository.ObtenerTodas();
    }

    public IReadOnlyList<SolicitudDetalleDto> ListarDetalle()
    {
        return _solicitudRepository.ObtenerTodas()
            .Select(solicitud =>
            {
                var mascota = _mascotaRepository.ObtenerPorId(solicitud.MascotaId);
                var adoptante = _adoptanteRepository.ObtenerPorId(solicitud.AdoptanteId);

                return new SolicitudDetalleDto
                {
                    Id = solicitud.Id,
                    Mascota = mascota?.Nombre ?? "Mascota no encontrada",
                    Adoptante = adoptante?.Nombre ?? "Adoptante no encontrado",
                    FechaSolicitud = solicitud.FechaSolicitud,
                    Estado = solicitud.Estado,
                    Comentarios = solicitud.Comentarios
                };
            })
            .ToList();
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
