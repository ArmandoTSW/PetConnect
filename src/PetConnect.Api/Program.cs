using PetConnect.Application.Services;
using PetConnect.Domain.Entities;
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

app.Run();
