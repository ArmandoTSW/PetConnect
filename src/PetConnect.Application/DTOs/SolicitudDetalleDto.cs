using PetConnect.Domain.Entities;

namespace PetConnect.Application.DTOs;

public class SolicitudDetalleDto
{
    public int Id { get; set; }
    public string Mascota { get; set; } = string.Empty;
    public string Adoptante { get; set; } = string.Empty;
    public DateTime FechaSolicitud { get; set; }
    public EstadoSolicitud Estado { get; set; }
    public string Comentarios { get; set; } = string.Empty;
}
