using Microsoft.AspNetCore.Mvc;

namespace HireNova.Controllers
{
    public class RecruiterController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
