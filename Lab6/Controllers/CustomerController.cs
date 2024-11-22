using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
