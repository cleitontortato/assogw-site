using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting; // To get the wwwroot path
using System.Collections.Generic;
using System.IO; // For file operations
using System.Text.Json; // For JSON serialization
using System.Threading.Tasks;
using System.Linq;
using assogw.Models;

namespace assogw.Controllers
{
    public class ConcessionariasController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ConcessionariasController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var jsonFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "concessionarias.json");
            
            if (!System.IO.File.Exists(jsonFilePath))
            {
                // Handle file not found gracefully, maybe return an empty list or an error view
                ViewData["Error"] = "O arquivo de dados das concessionárias não foi encontrado.";
                return View(new List<DealershipModel>());
            }

            var jsonText = await System.IO.File.ReadAllTextAsync(jsonFilePath);
            var dealerships = JsonSerializer.Deserialize<List<DealershipModel>>(jsonText) ?? new List<DealershipModel>();

            ViewData["Title"] = "Rede de Concessionárias";
            return View(dealerships.OrderBy(x => x.Name).ToList());
        }
    }
}
