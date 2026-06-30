using PetConnect.Domain.Entities;

namespace PetConnect.Web.ViewModels;

public class SolicitudesIndexViewModel
{
    public IReadOnlyList<SolicitudAdopcion> Solicitudes { get; set; } = [];
    public IReadOnlyList<Mascota> Mascotas { get; set; } = [];
    public IReadOnlyList<Adoptante> Adoptantes { get; set; } = [];

    public Mascota? ObtenerMascota(int id)
    {
        return Mascotas.FirstOrDefault(mascota => mascota.Id == id);
    }

    public Adoptante? ObtenerAdoptante(int id)
    {
        return Adoptantes.FirstOrDefault(adoptante => adoptante.Id == id);
    }
}
