using PetConnect.Application.Services;
using PetConnect.Domain.Entities;
using PetConnect.Domain.Exceptions;
using PetConnect.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPetConnectServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mascotas = app.MapGroup("/api/mascotas").WithTags("Mascotas");

mascotas.MapGet("/", (MascotaService mascotaService) =>
{
    return Results.Ok(mascotaService.ListarDisponibles());
});

mascotas.MapGet("/{id:int}", (int id, MascotaService mascotaService) =>
{
    var mascota = mascotaService.ObtenerPorId(id);
    return mascota is null ? Results.NotFound() : Results.Ok(mascota);
});

mascotas.MapPost("/", (Mascota mascota, MascotaService mascotaService) =>
{
    try
    {
        var creada = mascotaService.Agregar(mascota);
        return Results.Created($"/api/mascotas/{creada.Id}", creada);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { mensaje = ex.Message });
    }
});

var adoptantes = app.MapGroup("/api/adoptantes").WithTags("Adoptantes");

adoptantes.MapGet("/", (AdoptanteService adoptanteService) =>
{
    return Results.Ok(adoptanteService.Listar());
});

adoptantes.MapPost("/", (Adoptante adoptante, AdoptanteService adoptanteService) =>
{
    try
    {
        var creado = adoptanteService.Registrar(adoptante);
        return Results.Created($"/api/adoptantes/{creado.Id}", creado);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { mensaje = ex.Message });
    }
});

var solicitudes = app.MapGroup("/api/solicitudes").WithTags("Solicitudes");

solicitudes.MapGet("/", (SolicitudAdopcionService solicitudService) =>
{
    return Results.Ok(solicitudService.ListarDetalle());
});

solicitudes.MapPost("/", (SolicitudAdopcion solicitud, SolicitudAdopcionService solicitudService) =>
{
    if (solicitud.MascotaId <= 0 || solicitud.AdoptanteId <= 0)
    {
        return Results.BadRequest(new { mensaje = "La solicitud debe relacionar una mascota y un adoptante." });
    }

    try
    {
        var creada = solicitudService.Crear(solicitud);
        return Results.Created($"/api/solicitudes/{creada.Id}", creada);
    }
    catch (ReglaNegocioException ex) when (ex.Message.Contains("no existe", StringComparison.OrdinalIgnoreCase))
    {
        return Results.NotFound(new { mensaje = ex.Message });
    }
    catch (ReglaNegocioException ex) when (ex.Message.Contains("Ya existe", StringComparison.OrdinalIgnoreCase))
    {
        return Results.Conflict(new { mensaje = ex.Message });
    }
    catch (ReglaNegocioException ex)
    {
        return Results.BadRequest(new { mensaje = ex.Message });
    }
});

solicitudes.MapPut("/{id:int}/estado", (int id, CambiarEstadoRequest request, SolicitudAdopcionService solicitudService) =>
{
    if (!Enum.IsDefined(request.Estado))
    {
        return Results.BadRequest(new { mensaje = "El estado indicado no es valido." });
    }

    try
    {
        solicitudService.CambiarEstado(id, request.Estado);
        return Results.Ok(new { mensaje = "Estado actualizado correctamente." });
    }
    catch (ReglaNegocioException ex) when (ex.Message.Contains("no existe", StringComparison.OrdinalIgnoreCase))
    {
        return Results.NotFound(new { mensaje = ex.Message });
    }
    catch (ReglaNegocioException ex)
    {
        return Results.BadRequest(new { mensaje = ex.Message });
    }
});

app.Run();

public record CambiarEstadoRequest(EstadoSolicitud Estado);
