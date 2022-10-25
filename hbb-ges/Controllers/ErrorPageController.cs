using Microsoft.AspNetCore.Mvc;

namespace hbb_ges.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
