using Microsoft.AspNetCore.Mvc;
using InmobiliariaSaucedo.Models;

namespace InmobiliariaSaucedo.Controllers;

public class InquilinosController : Controller
{
    private readonly ILogger<InquilinosController> _logger;
    private readonly IConfiguration config;

    public InquilinosController(ILogger<InquilinosController> logger, IConfiguration ic)
    {
        _logger = logger;
        config = ic;
    }

    public IActionResult Index()
    {
        RepositorioInquilino ri = new RepositorioInquilino(config);
        var lista = ri.ObtenerTodos();
        ViewData["lista"] = lista;
        return View();
    }
}