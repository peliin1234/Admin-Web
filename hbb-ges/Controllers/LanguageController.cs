using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace hbb_ges.Controllers
{
    [Route("languages")]
    public class LanguageController : Controller
    {
        [Route("change")]
        public IActionResult Change(string language)
        {
         
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) });
            return RedirectToAction("Index", "Home");
        }
    }
}
