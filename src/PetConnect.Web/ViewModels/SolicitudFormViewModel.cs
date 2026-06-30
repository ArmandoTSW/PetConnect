using Microsoft.AspNetCore.Mvc.Rendering;
using PetConnect.Domain.Entities;

namespace PetConnect.Web.ViewModels;

public class SolicitudFormViewModel
{
    public SolicitudAdopcion Solicitud { get; set; } = new();
    public IReadOnlyList<SelectListItem> Mascotas { get; set; } = [];
    public IReadOnlyList<SelectListItem> Adoptantes { get; set; } = [];
}
