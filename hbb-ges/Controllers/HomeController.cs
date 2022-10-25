using FluentValidation.Results;
using hbb_ges.BusinessLayer.Concrete;
using hbb_ges.BusinessLayer.ValidationRules;
using hbb_ges.DataAccessLayer.Repositories;
using hbb_ges.EntityLayer.Concrete;
using hbb_ges.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hbb_ges.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        AboutManager aboutM = new AboutManager(new GenericRepository<About>());
        BlogManager bl=new BlogManager(new GenericRepository<Blog>());
        ContactManager contactM = new ContactManager(new GenericRepository<Contact>());
        MainManager mainM = new MainManager(new GenericRepository<MainPage>());
        GalleryManager galleryM = new GalleryManager(new GenericRepository<Gallery>());
        InfoManager infoM = new InfoManager(new GenericRepository<Info>());
        MessageManager messageM = new MessageManager(new GenericRepository<Message>());
        SliderManager sliderM = new SliderManager(new GenericRepository<Slider>());
        OtherCompanyManager othercompM = new OtherCompanyManager(new GenericRepository<OtherCompany>());
        public IActionResult Index()
        {
            var value = mainM.GetList().First();
            ViewBag.slider = sliderM.GetList();
            ViewBag.portfolio=bl.GetList();
            ViewBag.gallery=galleryM.GetList();
            return View(value);
        }
        public static List<Category> myCat()
        {
            return new CategoryManager(new GenericRepository<Category>()).GetList().Where(x=>x.CategoryStatus==true).ToList();
        }
        public IActionResult About()
        {
            var values = aboutM.GetList();
            ViewBag.blog=bl.GetList();
            return View(values);
        }
        public IActionResult Gallery()
        {
            var values = galleryM.GetList();
            return View(values);
        }
        public IActionResult GES()
        {
            var values = infoM.GetList();
            ViewBag.otherCompany = othercompM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.contacts = contactM.GetList();
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message c)
        {

            MessageValidator cv = new MessageValidator();
            ValidationResult result = cv.Validate(c);
            if (result.IsValid)
            {
                c.status = false;
                c.sendDate=DateTime.Now;
                messageM.TAdd(c);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.contacts = contactM.GetList();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}