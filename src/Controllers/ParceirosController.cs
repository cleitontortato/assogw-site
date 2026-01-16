using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace assogw.Controllers
{
    public class PartnerViewModel
    {
        public required string Name { get; set; }
        public required string LogoUrl { get; set; }
        public required string Url { get; set; }
        public required string Category { get; set; } // Gold, Silver, Bronze
    }

    public class ParceirosController : Controller
    {
        public IActionResult Index()
        {
            var partners = new List<PartnerViewModel>();

            // Gold Partners (3 items)
            for (int i = 1; i <= 3; i++)
            {
                partners.Add(new PartnerViewModel
                {
                    Name = $"Parceiro Gold {i}",
                    LogoUrl = $"https://placehold.co/400x200/C6B18A/white?text=Gold+{i}",
                    Url = "#",
                    Category = "Gold"
                });
            }

            // Silver Partners (6 items)
            for (int i = 1; i <= 6; i++)
            {
                partners.Add(new PartnerViewModel
                {
                    Name = $"Parceiro Silver {i}",
                    LogoUrl = $"https://placehold.co/300x150/9CA3AF/white?text=Silver+{i}",
                    Url = "#",
                    Category = "Silver"
                });
            }

            // Bronze Partners (9 items)
            for (int i = 1; i <= 9; i++)
            {
                partners.Add(new PartnerViewModel
                {
                    Name = $"Parceiro Bronze {i}",
                    LogoUrl = $"https://placehold.co/200x100/9E8A64/white?text=Bronze+{i}",
                    Url = "#",
                    Category = "Bronze"
                });
            }

            return View(partners);
        }
    }
}
