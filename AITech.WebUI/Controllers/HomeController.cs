using AITech.WebUI.Models;
using AITech.WebUI.Services.GeminiServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AITech.WebUI.Controllers
{
    public class HomeController(IGeminiService geminiService) : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string prompt)
        {
            var response = await geminiService.GetGeminiResponseAsync(prompt);
            if (response != null)
            {
                ViewBag.GeminiResponse = response;
            }
            else
            {
                ViewBag.GeminiResponse = "No response from Gemini API.";
            }
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
}
