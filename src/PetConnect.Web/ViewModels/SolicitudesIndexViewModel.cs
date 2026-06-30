using PetConnect.Application.DTOs;
using PetConnect.Domain.Entities;

namespace PetConnect.Web.ViewModels;

public class SolicitudesIndexViewModel
{
    public IReadOnlyList<SolicitudDetalleDto> Solicitudes { get; set; } = [];
}
