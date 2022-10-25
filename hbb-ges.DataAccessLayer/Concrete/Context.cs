using hbb_ges.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-H4T9ES7;Database=hbbGesDb;Integrated Security=true");
            
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MainPage> Main_Page { get; set; }
        public DbSet<Info> Info_page { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OtherCompany> OtherCompanies { get; set; }
        public DbSet<Slider> Sliders { get; set; }

    }
}
