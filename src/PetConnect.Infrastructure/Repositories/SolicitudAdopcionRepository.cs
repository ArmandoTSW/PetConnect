using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure.Repositories;

public class SolicitudAdopcionRepository : ISolicitudAdopcionRepository
{
    private readonly InMemoryDataStore _dataStore;

    public SolicitudAdopcionRepository(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public IReadOnlyList<SolicitudAdopcion> ObtenerTodas()
    {
        return _dataStore.Solicitudes;
    }

    public SolicitudAdopcion? ObtenerPorId(int id)
    {
        return _dataStore.Solicitudes.FirstOrDefault(solicitud => solicitud.Id == id);
    }

    public SolicitudAdopcion Agregar(SolicitudAdopcion solicitud)
    {
        solicitud.Id = _dataStore.Solicitudes.Count == 0 ? 1 : _dataStore.Solicitudes.Max(item => item.Id) + 1;
        _dataStore.Solicitudes.Add(solicitud);
        return solicitud;
    }

    public void Actualizar(SolicitudAdopcion solicitud)
    {
        var existente = ObtenerPorId(solicitud.Id);
        if (existente is null)
        {
            return;
        }

        existente.Estado = solicitud.Estado;
        existente.Comentarios = solicitud.Comentarios;
    }
}
