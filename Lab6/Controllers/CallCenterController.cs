using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class CallCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
