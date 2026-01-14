using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assogw.Models;
using assogw.Controllers; // To access NewsController static method
using System.Linq; // For .Take()

namespace assogw.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var latestNews = NewsController.GetDummyNews().OrderByDescending(n => n.PublishDate).Take(3).ToList();
        var viewModel = new HomeViewModel
        {
            LatestNews = latestNews
        };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult QuemSomos()
    {
        ViewData["Title"] = "Quem Somos";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contato";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
