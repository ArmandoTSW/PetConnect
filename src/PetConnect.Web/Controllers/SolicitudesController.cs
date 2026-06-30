using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetConnect.Application.Services;
using PetConnect.Domain.Entities;
using PetConnect.Domain.Exceptions;
using PetConnect.Web.ViewModels;

namespace PetConnect.Web.Controllers;

public class SolicitudesController : Controller
{
    private readonly SolicitudAdopcionService _solicitudService;
    private readonly MascotaService _mascotaService;
    private readonly AdoptanteService _adoptanteService;

    public SolicitudesController(
        SolicitudAdopcionService solicitudService,
        MascotaService mascotaService,
        AdoptanteService adoptanteService)
    {
        _solicitudService = solicitudService;
        _mascotaService = mascotaService;
        _adoptanteService = adoptanteService;
    }

    public IActionResult Index()
    {
        var viewModel = new SolicitudesIndexViewModel
        {
            Solicitudes = _solicitudService.Listar(),
            Mascotas = _mascotaService.ListarTodas(),
            Adoptantes = _adoptanteService.Listar()
        };

        return View(viewModel);
    }

    public IActionResult Create(int? mascotaId)
    {
        var viewModel = CrearFormulario();
        if (mascotaId.HasValue)
        {
            viewModel.Solicitud.MascotaId = mascotaId.Value;
        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(SolicitudFormViewModel viewModel)
    {
        try
        {
            _solicitudService.Crear(viewModel.Solicitud);
            TempData["Mensaje"] = "Solicitud creada correctamente.";
            return RedirectToAction(nameof(Index));
        }
        catch (ReglaNegocioException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            var formulario = CrearFormulario();
            formulario.Solicitud = viewModel.Solicitud;
            return View(formulario);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CambiarEstado(int id, EstadoSolicitud estado)
    {
        try
        {
            _solicitudService.CambiarEstado(id, estado);
            TempData["Mensaje"] = "Estado actualizado correctamente.";
        }
        catch (ReglaNegocioException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    private SolicitudFormViewModel CrearFormulario()
    {
        return new SolicitudFormViewModel
        {
            Mascotas = _mascotaService.ListarDisponibles()
                .Select(mascota => new SelectListItem($"{mascota.Nombre} - {mascota.Especie}", mascota.Id.ToString()))
                .ToList(),
            Adoptantes = _adoptanteService.Listar()
                .Select(adoptante => new SelectListItem(adoptante.Nombre, adoptante.Id.ToString()))
                .ToList()
        };
    }
}
