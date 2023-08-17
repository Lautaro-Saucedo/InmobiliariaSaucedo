using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InmobiliariaSaucedo.Models;

namespace InmobiliariaSaucedo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration config;

    public HomeController(ILogger<HomeController> logger, IConfiguration con)
    {
        _logger = logger;
        config = con;
    }

    public IActionResult Index()
    {
        RepositorioInquilino ri = new RepositorioInquilino(config);
        var lista = ri.ObtenerTodos();
        Console.WriteLine(lista.Count);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
