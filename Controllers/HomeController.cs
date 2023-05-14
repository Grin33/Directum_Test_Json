using Directum_Test_Json.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Directum_Test_Json.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Download([Bind("LastName,FirstName,MiddleName,BirthDate")] Person _person)
        {
            if (ModelState.IsValid)
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var content = JsonSerializer.Serialize(_person, options);
                string mime = "application/json";
                return File(System.Text.Encoding.UTF8.GetBytes(content), mime, "Person_Info.json");
            }
            else return View("Index");
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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