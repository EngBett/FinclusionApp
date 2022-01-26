using Microsoft.AspNetCore.Mvc;

namespace AccManagement.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult E404()
        {
            return View();
        }
        public IActionResult E403()
        {
            return View();
        }
        public IActionResult E500()
        {
            return View();
        }
    }
}