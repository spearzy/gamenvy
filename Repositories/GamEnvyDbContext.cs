using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class GamEnvyDbContext : IdentityDbContext<AppUser>
    {
        public GamEnvyDbContext(DbContextOptions<GamEnvyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}
