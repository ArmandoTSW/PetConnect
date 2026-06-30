using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure.Repositories;

public class AdoptanteRepository : IAdoptanteRepository
{
    private readonly InMemoryDataStore _dataStore;

    public AdoptanteRepository(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public IReadOnlyList<Adoptante> ObtenerTodos()
    {
        return _dataStore.Adoptantes;
    }

    public Adoptante? ObtenerPorId(int id)
    {
        return _dataStore.Adoptantes.FirstOrDefault(adoptante => adoptante.Id == id);
    }

    public Adoptante Agregar(Adoptante adoptante)
    {
        adoptante.Id = _dataStore.Adoptantes.Count == 0 ? 1 : _dataStore.Adoptantes.Max(item => item.Id) + 1;
        _dataStore.Adoptantes.Add(adoptante);
        return adoptante;
    }
}
