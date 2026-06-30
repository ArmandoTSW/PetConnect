using PetConnect.Domain.Entities;

namespace PetConnect.Application.Interfaces;

public interface IMascotaRepository
{
    IReadOnlyList<Mascota> ObtenerTodas();
    Mascota? ObtenerPorId(int id);
    Mascota Agregar(Mascota mascota);
    void Actualizar(Mascota mascota);
}
