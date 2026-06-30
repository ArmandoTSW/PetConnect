using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure.Repositories;

public class InMemoryDataStore
{
    public List<Mascota> Mascotas { get; } =
    [
        new Mascota
        {
            Id = 1,
            Nombre = "Luna",
            Especie = "Perro",
            Raza = "Mestiza",
            Edad = 2,
            Descripcion = "Juguetona, tranquila y lista para una familia activa.",
            Disponible = true
        },
        new Mascota
        {
            Id = 2,
            Nombre = "Milo",
            Especie = "Gato",
            Raza = "Domestico",
            Edad = 1,
            Descripcion = "Curioso, carinoso y acostumbrado a interiores.",
            Disponible = true
        },
        new Mascota
        {
            Id = 3,
            Nombre = "Canela",
            Especie = "Perro",
            Raza = "Labrador",
            Edad = 4,
            Descripcion = "Obediente, sociable y buena con ninos.",
            Disponible = true
        }
    ];

    public List<Adoptante> Adoptantes { get; } = [];
    public List<SolicitudAdopcion> Solicitudes { get; } = [];
}
