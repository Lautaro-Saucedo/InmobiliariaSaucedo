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
    
    public IActionResult Create(){
        return View();
    }
    public IActionResult CreatePost(){
        RepositorioInquilino ri = new RepositorioInquilino(config);
        
        var i = new Inquilino{
            Nombre=Request.Form["Nombre"],
            Apellido=Request.Form["Apellido"],
            Dni=Request.Form["Dni"],
            Telefono=Request.Form["Telefono"],
            Email=Request.Form["Email"],
        };
        
        var nuevoid = ri.Crear(i);
        Console.WriteLine( nuevoid);
        return RedirectToAction("Index");
    }

    public IActionResult Borrar(int id){
        RepositorioInquilino ri = new RepositorioInquilino(config);
        ri.Borrar(id);
        return RedirectToAction("Index");
    }

    public IActionResult Ver(int id){
        RepositorioInquilino ri = new RepositorioInquilino(config);
        return View(ri.Buscar(id));
    }

    public IActionResult Editar(int id){
        RepositorioInquilino ri = new RepositorioInquilino(config);
        return View(ri.Buscar(id));
    }

    public IActionResult EditarPost(){
        //revisar envio de id
        var i = new Inquilino{
            Id= Convert.ToInt32(Request.Form["Id"]),
            Nombre=Request.Form["Nombre"],
            Apellido=Request.Form["Apellido"],
            Dni=Request.Form["Dni"],
            Telefono=Request.Form["Telefono"],
            Email=Request.Form["Email"],
        };

        RepositorioInquilino ri = new RepositorioInquilino(config);
        ri.Actualizar(i);
        return RedirectToAction("Index");
    }

}