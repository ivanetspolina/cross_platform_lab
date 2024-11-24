using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Lab5.lab6_part;

namespace Lab5.Controllers
{
    public class Lab6CallCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
