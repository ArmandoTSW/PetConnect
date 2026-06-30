using Microsoft.AspNetCore.Mvc;
using PetConnect.Application.Services;
using PetConnect.Domain.Entities;

namespace PetConnect.Web.Controllers;

public class AdoptantesController : Controller
{
    private readonly AdoptanteService _adoptanteService;

    public AdoptantesController(AdoptanteService adoptanteService)
    {
        _adoptanteService = adoptanteService;
    }

    public IActionResult Create()
    {
        return View(new Adoptante());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Adoptante adoptante)
    {
        try
        {
            _adoptanteService.Registrar(adoptante);
            TempData["Mensaje"] = "Adoptante registrado correctamente.";
            return RedirectToAction("Create", "Solicitudes");
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(adoptante);
        }
    }
}
