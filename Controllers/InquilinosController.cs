using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InmobiliariaSaucedo.Models;

namespace InmobiliariaSaucedo.Controllers;

public class InquilinosController : Controller
{
    private readonly ILogger<InquilinosController> _logger;

    public InquilinosController(ILogger<InquilinosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}