using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Services;

public class MascotaService
{
    private readonly IMascotaRepository _mascotaRepository;

    public MascotaService(IMascotaRepository mascotaRepository)
    {
        _mascotaRepository = mascotaRepository;
    }

    public IReadOnlyList<Mascota> ListarDisponibles()
    {
        return _mascotaRepository.ObtenerTodas()
            .Where(mascota => mascota.Disponible)
            .ToList();
    }

    public IReadOnlyList<Mascota> ListarTodas()
    {
        return _mascotaRepository.ObtenerTodas();
    }

    public Mascota? ObtenerPorId(int id)
    {
        return _mascotaRepository.ObtenerPorId(id);
    }

    public Mascota Agregar(Mascota mascota)
    {
        if (string.IsNullOrWhiteSpace(mascota.Nombre))
        {
            throw new ArgumentException("La mascota debe tener nombre.");
        }

        if (string.IsNullOrWhiteSpace(mascota.Especie))
        {
            throw new ArgumentException("La mascota debe tener especie.");
        }

        return _mascotaRepository.Agregar(mascota);
    }
}
