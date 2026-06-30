using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Services;

public class AdoptanteService
{
    private readonly IAdoptanteRepository _adoptanteRepository;

    public AdoptanteService(IAdoptanteRepository adoptanteRepository)
    {
        _adoptanteRepository = adoptanteRepository;
    }

    public IReadOnlyList<Adoptante> Listar()
    {
        return _adoptanteRepository.ObtenerTodos();
    }

    public Adoptante? ObtenerPorId(int id)
    {
        return _adoptanteRepository.ObtenerPorId(id);
    }

    public Adoptante Registrar(Adoptante adoptante)
    {
        if (string.IsNullOrWhiteSpace(adoptante.Nombre))
        {
            throw new ArgumentException("El adoptante debe tener nombre.");
        }

        return _adoptanteRepository.Agregar(adoptante);
    }
}
