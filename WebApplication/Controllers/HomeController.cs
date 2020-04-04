using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
         AddressContext db;
       // private readonly ILogger<HomeController> _logger;

        public HomeController(AddressContext db)
        {
            this.db = db;
        }
       
    /*    public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }*/

    [Authorize]
    public IActionResult Index()
    {
        return Content(User.Identity.Name);
    }

        public IActionResult Privacy()
        {
            return View();
        }

      /*  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }*/
      }
}