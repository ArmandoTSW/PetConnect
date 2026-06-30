using PetConnect.Application.Interfaces;
using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure.Repositories;

public class MascotaRepository : IMascotaRepository
{
    private readonly InMemoryDataStore _dataStore;

    public MascotaRepository(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public IReadOnlyList<Mascota> ObtenerTodas()
    {
        return _dataStore.Mascotas;
    }

    public Mascota? ObtenerPorId(int id)
    {
        return _dataStore.Mascotas.FirstOrDefault(mascota => mascota.Id == id);
    }

    public Mascota Agregar(Mascota mascota)
    {
        mascota.Id = _dataStore.Mascotas.Count == 0 ? 1 : _dataStore.Mascotas.Max(item => item.Id) + 1;
        _dataStore.Mascotas.Add(mascota);
        return mascota;
    }

    public void Actualizar(Mascota mascota)
    {
        var existente = ObtenerPorId(mascota.Id);
        if (existente is null)
        {
            return;
        }

        existente.Nombre = mascota.Nombre;
        existente.Especie = mascota.Especie;
        existente.Raza = mascota.Raza;
        existente.Edad = mascota.Edad;
        existente.Descripcion = mascota.Descripcion;
        existente.Disponible = mascota.Disponible;
    }
}
