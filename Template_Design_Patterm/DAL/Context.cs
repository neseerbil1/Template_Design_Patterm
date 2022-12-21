using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Template_Design_Patterm.DAL.Entities;

namespace Template_Design_Patterm.DAL
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //veritabanına erişim için güvenlik bilgilerinin kullanılıp kullanılmayacağını ("integrated security=true") 
            optionsBuilder.UseSqlServer("server=DESKTOP-T0I7RRL;initial catalog=TemplateDesignDb;integrated security=true");
        }
    }
}
