using CloudGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CloudGame.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        public const string Home = "Home";

        public HomeController() 
        {  
        
        }

        [HttpGet, Route("")]
        public ActionResult Index() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet(nameof(Error), Name = nameof(Error))]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
