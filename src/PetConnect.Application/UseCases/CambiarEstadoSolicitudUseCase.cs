using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;
using PetConnect.Domain.Exceptions;

namespace PetConnect.Application.UseCases;

public class CambiarEstadoSolicitudUseCase
{
    private readonly ISolicitudAdopcionRepository _solicitudRepository;
    private readonly IMascotaRepository _mascotaRepository;

    public CambiarEstadoSolicitudUseCase(
        ISolicitudAdopcionRepository solicitudRepository,
        IMascotaRepository mascotaRepository)
    {
        _solicitudRepository = solicitudRepository;
        _mascotaRepository = mascotaRepository;
    }

    public void Ejecutar(int id, EstadoSolicitud estado)
    {
        var solicitud = _solicitudRepository.ObtenerPorId(id);
        if (solicitud is null)
        {
            throw new ReglaNegocioException("La solicitud no existe.");
        }

        solicitud.Estado = estado;
        _solicitudRepository.Actualizar(solicitud);

        if (estado == EstadoSolicitud.Aprobada)
        {
            var mascota = _mascotaRepository.ObtenerPorId(solicitud.MascotaId);
            if (mascota is not null)
            {
                mascota.Disponible = false;
                _mascotaRepository.Actualizar(mascota);
            }
        }
    }
}
