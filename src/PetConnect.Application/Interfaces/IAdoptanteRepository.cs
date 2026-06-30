using PetConnect.Domain.Entities;

namespace PetConnect.Application.Interfaces;

public interface IAdoptanteRepository
{
    IReadOnlyList<Adoptante> ObtenerTodos();
    Adoptante? ObtenerPorId(int id);
    Adoptante Agregar(Adoptante adoptante);
}
