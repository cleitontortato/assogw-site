using Microsoft.AspNetCore.Mvc;
using assogw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assogw.Controllers
{
    public class NewsController : Controller
    {
        private static readonly Random _random = new Random();

        private static string _getRandomHexColor()
        {
            // Generate a random color, avoiding very dark or very light colors to ensure good contrast
            int r = _random.Next(50, 200);
            int g = _random.Next(50, 200);
            int b = _random.Next(50, 200);
            return $"#{r:X2}{g:X2}{b:X2}";
        }

        // TODO: Refactor dummy news generation into a service for better architecture and testability.
        public static List<NewsItem> GetDummyNews()
        {
            var newsItems = new List<NewsItem>();
            for (int i = 1; i <= 6; i++)
            {
                string bgColor = _getRandomHexColor();
                string textColor = _getRandomHexColor(); 
                // Ensure sufficient contrast, if colors are too similar regenerate one
                // For simplicity, we'll just pick two random colors here.
                
                newsItems.Add(new NewsItem { 
                    Id = i, 
                    Title = $"GWM Notícia {i}: Novo Evento Automotivo", 
                    Excerpt = $"Detalhes exclusivos sobre o evento de lançamento da GWM no país. Fique por dentro de todas as novidades que estão chegando ao mercado.", 
                    ImageUrl = $"https://placehold.co/500x300/{bgColor.Substring(1)}/{textColor.Substring(1)}/png?text=Noticia+{i}", 
                    PublishDate = DateTime.Now.AddDays(-(i * 2)),
                    Author = "ASSOGW Press"
                });
            }
            return newsItems;
        }

        public IActionResult Index()
        {
            var news = GetDummyNews();
            ViewData["Title"] = "Notícias";
            return View(news);
        }

        public IActionResult Details(int id)
        {
            var allNews = GetDummyNews();
            var article = allNews.FirstOrDefault(n => n.Id == id);
            
            if (article == null)
            {
                // If article not found, perhaps redirect to a 404 or News Index
                return RedirectToAction(nameof(Index));
            }

            // Add rich content to the body for the details page
            article.Excerpt = @"<p>Este é o corpo do artigo, com conteúdo rico e detalhado sobre o lançamento. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                <p>Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Maecenas sed diam eget risus varius blandit sit amet non magna. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.</p>
                                <p>Donec id elit non mi porta gravida at eget metus. Vestibulum id ligula porta felis euismod semper. Praesent commodo cursus magna, vel scelerisque nisl consectetur et.</p>";
            
            // To ensure the ImageUrl for the detailed article is also dynamic and matches the overall theme
            string bgColor = _getRandomHexColor();
            string textColor = _getRandomHexColor();
            article.ImageUrl = $"https://placehold.co/800x450/{bgColor.Substring(1)}/{textColor.Substring(1)}/png?text={Uri.EscapeDataString(article.Title)}";


            var recentNews = allNews.Where(n => n.Id != article.Id).OrderByDescending(n => n.PublishDate).Take(3).ToList();

            var viewModel = new NewsDetailsViewModel
            {
                Article = article,
                RecentNews = recentNews
            };

            ViewData["Title"] = article.Title;
            return View(viewModel);
        } // Closing brace for Details method
    } // Closing brace for NewsController class
} // Closing brace for namespace assogw.Controllers
