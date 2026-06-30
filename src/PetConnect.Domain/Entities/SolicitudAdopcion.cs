namespace PetConnect.Domain.Entities;

public class SolicitudAdopcion
{
    public int Id { get; set; }
    public int MascotaId { get; set; }
    public int AdoptanteId { get; set; }
    public DateTime FechaSolicitud { get; set; } = DateTime.Today;
    public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
    public string Comentarios { get; set; } = string.Empty;
}
