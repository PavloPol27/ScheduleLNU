using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Log.Information("Index is open {0}", GetType().Name);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
