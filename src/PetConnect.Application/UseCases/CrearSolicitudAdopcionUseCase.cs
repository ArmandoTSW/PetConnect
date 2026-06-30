using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;
using PetConnect.Domain.Exceptions;

namespace PetConnect.Application.UseCases;

public class CrearSolicitudAdopcionUseCase
{
    private readonly ISolicitudAdopcionRepository _solicitudRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IAdoptanteRepository _adoptanteRepository;

    public CrearSolicitudAdopcionUseCase(
        ISolicitudAdopcionRepository solicitudRepository,
        IMascotaRepository mascotaRepository,
        IAdoptanteRepository adoptanteRepository)
    {
        _solicitudRepository = solicitudRepository;
        _mascotaRepository = mascotaRepository;
        _adoptanteRepository = adoptanteRepository;
    }

    public SolicitudAdopcion Ejecutar(SolicitudAdopcion solicitud)
    {
        var mascota = _mascotaRepository.ObtenerPorId(solicitud.MascotaId);
        if (mascota is null)
        {
            throw new ReglaNegocioException("La mascota seleccionada no existe.");
        }

        if (!mascota.Disponible)
        {
            throw new ReglaNegocioException("La mascota ya no esta disponible.");
        }

        if (_adoptanteRepository.ObtenerPorId(solicitud.AdoptanteId) is null)
        {
            throw new ReglaNegocioException("El adoptante seleccionado no existe.");
        }

        var duplicada = _solicitudRepository.ObtenerTodas()
            .Any(item => item.MascotaId == solicitud.MascotaId
                && item.AdoptanteId == solicitud.AdoptanteId
                && item.Estado == EstadoSolicitud.Pendiente);

        if (duplicada)
        {
            throw new ReglaNegocioException("Ya existe una solicitud pendiente para esta mascota y adoptante.");
        }

        solicitud.FechaSolicitud = DateTime.Today;
        solicitud.Estado = EstadoSolicitud.Pendiente;

        return _solicitudRepository.Agregar(solicitud);
    }
}
