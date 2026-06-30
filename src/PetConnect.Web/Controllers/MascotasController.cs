using Microsoft.AspNetCore.Mvc;
using PetConnect.Application.Services;

namespace PetConnect.Web.Controllers;

public class MascotasController : Controller
{
    private readonly MascotaService _mascotaService;

    public MascotasController(MascotaService mascotaService)
    {
        _mascotaService = mascotaService;
    }

    public IActionResult Index()
    {
        var mascotas = _mascotaService.ListarDisponibles();
        return View(mascotas);
    }

    public IActionResult Details(int id)
    {
        var mascota = _mascotaService.ObtenerPorId(id);
        if (mascota is null)
        {
            return NotFound();
        }

        return View(mascota);
    }
}
