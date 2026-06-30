using PetConnect.Domain.Entities;

namespace PetConnect.Application.Interfaces;

public interface ISolicitudAdopcionRepository
{
    IReadOnlyList<SolicitudAdopcion> ObtenerTodas();
    SolicitudAdopcion? ObtenerPorId(int id);
    SolicitudAdopcion Agregar(SolicitudAdopcion solicitud);
    void Actualizar(SolicitudAdopcion solicitud);
}
