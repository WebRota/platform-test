using Microsoft.AspNetCore.Mvc;

namespace WebRota.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
