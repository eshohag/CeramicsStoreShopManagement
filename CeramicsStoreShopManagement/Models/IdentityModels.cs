using CeramicsStoreShopManagement.Models.CoreModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CeramicsStoreShopManagement.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("CeramicsStoreDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //Customize Table Name Sections
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Role").Property(a => a.Id).HasColumnName("RoleId");
        }
        //Your Custome Model
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Store> Stores { get; set; }

        public System.Data.Entity.DbSet<CeramicsStoreShopManagement.Models.ViewModel.ProductViewModel> ProductViewModels { get; set; }
    }
}