using InternetShop.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetShop.Data
{
    public class ApplicationDbContext : /*Identity*/DbContext/*<AppUser>*/
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
