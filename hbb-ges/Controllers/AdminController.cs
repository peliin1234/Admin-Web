using FluentValidation.Results;
using hbb_ges.BusinessLayer.Concrete;
using hbb_ges.BusinessLayer.ValidationRules;
using hbb_ges.DataAccessLayer.Repositories;
using hbb_ges.EntityLayer.Concrete;
using hbb_ges.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hbb_ges.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        CategoryManager categoryM = new CategoryManager(new GenericRepository<Category>());
        BlogManager blogM = new BlogManager(new GenericRepository<Blog>());
        AboutManager aboutM = new AboutManager(new GenericRepository<About>());
        MainManager mainM = new MainManager(new GenericRepository<MainPage>());
        InfoManager infoM = new InfoManager(new GenericRepository<Info>());
        GalleryManager galleryM = new GalleryManager(new GenericRepository<Gallery>());
        ContactManager contactM = new ContactManager(new GenericRepository<Contact>());
        MessageManager messageM = new MessageManager(new GenericRepository<Message>());
        SliderManager sliderM = new SliderManager(new GenericRepository<Slider>());
        OtherCompanyManager othercompM = new OtherCompanyManager(new GenericRepository<OtherCompany>());

        public IActionResult Index()
        {
            ViewBag.msgCount = messageM.GetList().Count;
            ViewBag.answered = messageM.GetList().Where(x=>x.status==true).Count();
            return View();
        }
        public static List<Message> messages()
        {

            var values =new MessageManager(new GenericRepository<Message>()).GetList();
            return values;
        }
        public static int msgCount()
        {
            return new MessageManager(new GenericRepository<Message>()).GetList().Where(x => x.status == false).Count();
        }
        /*ansayfa*/

        public IActionResult Main()
        {
            ViewBag.slider = sliderM.GetList();
            var values = mainM.GetList().First();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditMain(int Id)
        {
             
            MainPage ent = mainM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditMain(MainPage ent,IFormFile img ,int id)
        {
            MainPage kayit = mainM.GetById(id);
             
            kayit.title = ent.title;
            kayit.content = ent.content;
            kayit.image ="deneme"; //validator'a takılmasın diye gecici deger atandı
            MainValidator mv = new MainValidator();
            ValidationResult validationResult = mv.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (img != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)img;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.image = newimagename;
                }
                mainM.TUpdate(kayit);
                return RedirectToAction("Main");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }

        /*hakkimizda*/

        public IActionResult About()
        {
             
            var values = aboutM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditAbout(int Id)
        {
             
            About ent = aboutM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditAbout(About ent, IFormFile video, int id)
        {
            About kayit = aboutM.GetById(id);
             
            //kayit.AboutDetails1 = ent.AboutDetails1;
            kayit.AboutDetails = ent.AboutDetails;
            kayit.AboutImage = "test"; // escape validate
            kayit.AboutStatus = ent.AboutStatus;
            AboutValidator av = new AboutValidator();
            ValidationResult validationResult = av.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (video != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)video;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.AboutImage = newimagename;
                }
                aboutM.TUpdate(kayit);
                return RedirectToAction("About");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }

        /* Ges tanıtım*/

        public IActionResult Info()
        {

            var values = infoM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditInfo(int Id)
        {
             
            Info ent = infoM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditInfo(Info ent, IFormFile img, int id)
        {
            Info kayit = infoM.GetById(id);
            
            kayit.title= ent.title; 
            kayit.description = ent.description;
            kayit.image = "test";
            InfoValidator v = new InfoValidator();
            ValidationResult validationResult = v.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (img != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)img;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.image = newimagename;
                }
                infoM.TUpdate(kayit);
                return RedirectToAction("Info");
                
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }

        /* galeri */

        public IActionResult Gallery()
        {
             
            var values = galleryM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGallery(int Id)
        {
             
            if (Id != 0)
            {
                Gallery ent = galleryM.GetById(Id);
                AddImage addImage = new AddImage();
                addImage.Name = ent.Name;
                addImage.Id = Id;
                return View(addImage);
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddGallery(AddImage ent, int id)
        {
            Gallery g = new Gallery();
             

            if (ent.Image != null)
            {
                var extension = Path.GetExtension(ent.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                ent.Image.CopyTo(stream);
                g.Image = newimagename;
            }
            g.Name = ent.Name;


            GalleryValidator gv = new GalleryValidator();
            ValidationResult result = gv.Validate(g);
            if (result.IsValid)
            {
                if (id != null)
                {
                    g.Id = id;
                    galleryM.TUpdate(g);
                }

                else
                    galleryM.TAdd(g);
                return RedirectToAction("Gallery", "Admin");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteGallery(int Id)
        {
             
            Gallery ent = galleryM.GetById(Id);
            galleryM.TDelete(ent);
            return RedirectToAction("Gallery");
        }

        /* iletisim*/
        public IActionResult Message() // display user messages
        {
             
            var values=messageM.GetList();
            return View(values);
        }
        public IActionResult DeleteMsg(int Id)
        {
            Message ent = messageM.GetById(Id);
            messageM.TDelete(ent);
            return RedirectToAction("Message");
        }
        public IActionResult MsgState(int Id)
        {
            Message ent = messageM.GetById(Id);
            ent.status = !ent.status;
            messageM.TUpdate(ent);
            return RedirectToAction("Message");
        }
        
        public IActionResult Contact() // company contacts :phone,mail,map
        {
             
            var values = contactM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditContact(int Id)
        {

            Contact ent = contactM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditContact(Contact ent, int id)
        {
            Contact kayit = contactM.GetById(id);
      
            kayit.ContactDescription = ent.ContactDescription;
            kayit.Map = ent.Map;
            
            ContactValidator v = new ContactValidator();
            ValidationResult validationResult = v.Validate(kayit);
            if (validationResult.IsValid)
            {
               
                contactM.TUpdate(kayit);
                return RedirectToAction("Contact");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }
        /*Slider*/
        
        [HttpGet]
        public IActionResult EditSlider(int Id)
        {

            Slider ent = sliderM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditSlider(Slider ent, IFormFile img, int id)
        {
            Slider kayit = sliderM.GetById(id);

            kayit.Title = ent.Title;
            kayit.SubTitle = ent.SubTitle;
            kayit.Image = "deneme"; //validator'a takılmasın diye gecici deger atandı
            SliderValidator mv = new SliderValidator();
            ValidationResult validationResult = mv.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (img != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)img;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.Image = newimagename;
                }
                sliderM.TUpdate(kayit);
                return RedirectToAction("Main");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }

        /*Kategori list*/
        public IActionResult Categories()
        {
             
            var values = categoryM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory() {   return View(); }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
             
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;
                categoryM.TAdd(p);
                return RedirectToAction("Categories", "Admin");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult Edit(Category ent, int id)
        {
            Category kayit = categoryM.GetById(id);
             
            kayit.CategoryName = ent.CategoryName;
            kayit.CategoryDescription = ent.CategoryDescription;
            kayit.CategoryStatus = ent.CategoryStatus;
            categoryM.TUpdate(kayit);

            return RedirectToAction("Categories");
        }
        public IActionResult EditCategory(int Id)
        {
             
            Category ent = categoryM.GetById(Id);
            return View(ent);
        }
        public IActionResult DeleteCategory(int Id)
        {
             
            Category ent = categoryM.GetById(Id);
            categoryM.TDelete(ent);
            return RedirectToAction("Categories");
        }
        public IActionResult changeStatus(int Id)
        {

            Category ent = categoryM.GetById(Id);
            ent.CategoryStatus = !ent.CategoryStatus;
            categoryM.TUpdate(ent);
            return RedirectToAction("Categories");
        }

        /*OtherCompany*/


        public IActionResult Other()
        {

            var values = othercompM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditOther(int Id)
        {
            OtherCompany ent=new OtherCompany();
            if (Id != 0)
            {
                ent = othercompM.GetById(Id);
                
                return View(ent);
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditOther(OtherCompany ent, IFormFile img, int id)
        {
            OtherCompany kayit =new OtherCompany();

            kayit.Name = ent.Name;
            kayit.Link= ent.Link;
            kayit.Image = " ";
            OtherCompanyValidator v = new OtherCompanyValidator();
            ValidationResult validationResult = v.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (img != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)img;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.Image = newimagename;
                }
                if (id != null)
                {
                    kayit.Id = id;
                    othercompM.TUpdate(kayit);
                }

                else
                    othercompM.TAdd(kayit);
                return RedirectToAction("Other");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }

        /* proje bilgileri */

        public IActionResult Blog()
        {

            var values = blogM.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditBlog(int Id)
        {

            Blog ent = blogM.GetById(Id);
            return View(ent);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog ent, IFormFile img, int id)
        {
            Blog kayit = blogM.GetById(id);

            kayit.BlogTitle = ent.BlogTitle;
            kayit.BlogContent = ent.BlogContent;
            kayit.BlogImage = "test";
            
            BlogValidator v = new BlogValidator();
            ValidationResult validationResult = v.Validate(kayit);
            if (validationResult.IsValid)
            {
                if (img != null)
                {
                    AddImage temp = new AddImage();
                    temp.Image = (IFormFile)img;
                    var extension = Path.GetExtension(temp.Image.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    temp.Image.CopyTo(stream);
                    kayit.BlogImage = newimagename;
                }
                blogM.TUpdate(kayit);
                return RedirectToAction("Blog");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(kayit);
        }
    }
}
