using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class CustomerCallController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
