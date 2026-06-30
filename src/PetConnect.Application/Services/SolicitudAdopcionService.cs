using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Services;

public class SolicitudAdopcionService
{
    private readonly ISolicitudAdopcionRepository _solicitudRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IAdoptanteRepository _adoptanteRepository;

    public SolicitudAdopcionService(
        ISolicitudAdopcionRepository solicitudRepository,
        IMascotaRepository mascotaRepository,
        IAdoptanteRepository adoptanteRepository)
    {
        _solicitudRepository = solicitudRepository;
        _mascotaRepository = mascotaRepository;
        _adoptanteRepository = adoptanteRepository;
    }

    public IReadOnlyList<SolicitudAdopcion> Listar()
    {
        return _solicitudRepository.ObtenerTodas();
    }

    public SolicitudAdopcion Crear(SolicitudAdopcion solicitud)
    {
        var mascota = _mascotaRepository.ObtenerPorId(solicitud.MascotaId);
        if (mascota is null)
        {
            throw new ArgumentException("La mascota seleccionada no existe.");
        }

        if (!mascota.Disponible)
        {
            throw new InvalidOperationException("La mascota ya no esta disponible.");
        }

        if (_adoptanteRepository.ObtenerPorId(solicitud.AdoptanteId) is null)
        {
            throw new ArgumentException("El adoptante seleccionado no existe.");
        }

        var duplicada = _solicitudRepository.ObtenerTodas()
            .Any(item => item.MascotaId == solicitud.MascotaId
                && item.AdoptanteId == solicitud.AdoptanteId
                && item.Estado == EstadoSolicitud.Pendiente);

        if (duplicada)
        {
            throw new InvalidOperationException("Ya existe una solicitud pendiente para esta mascota y adoptante.");
        }

        solicitud.FechaSolicitud = DateTime.Today;
        solicitud.Estado = EstadoSolicitud.Pendiente;

        return _solicitudRepository.Agregar(solicitud);
    }

    public void CambiarEstado(int id, EstadoSolicitud estado)
    {
        var solicitud = _solicitudRepository.ObtenerPorId(id);
        if (solicitud is null)
        {
            throw new ArgumentException("La solicitud no existe.");
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
