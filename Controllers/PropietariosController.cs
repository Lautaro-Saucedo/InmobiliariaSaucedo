using Microsoft.AspNetCore.Mvc;
using InmobiliariaSaucedo.Models;

namespace InmobiliariaSaucedo.Controllers;

public class PropietariosController : Controller
{
    private readonly ILogger<PropietariosController> _logger;
    private readonly IConfiguration config;

    public PropietariosController(ILogger<PropietariosController> logger, IConfiguration ic)
    {
        _logger = logger;
        config = ic;
    }

    public IActionResult Index()
    {
        RepositorioPropietario rp = new RepositorioPropietario(config);
        //var lista = ri.ObtenerTodos();
        //lista.ForEach(o => Console.WriteLine(o.Dni));
        return View();
    }
}