using Microsoft.AspNetCore.Mvc;

namespace PoolTrackerBackEnd.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
