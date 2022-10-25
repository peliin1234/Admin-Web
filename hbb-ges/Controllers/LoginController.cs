using hbb_ges.DataAccessLayer.Concrete;
using hbb_ges.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace hbb_ges.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(Admin p)
        {
            Context c = new Context();
            var adminusernameinfo = c.Admin.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminusernameinfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name,p.AdminUserName)
                };
                var useridenty = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridenty);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre";
              
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
