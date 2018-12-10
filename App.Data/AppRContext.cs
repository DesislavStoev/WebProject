using App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Areas.Identity.Data
{
    public class AppRContext : IdentityDbContext<AppUser>
    {
        public AppRContext(DbContextOptions<AppRContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Directions> Directions { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Nutrition> Nutritions { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
