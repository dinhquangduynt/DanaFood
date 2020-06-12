using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ThucPham.Model.Models;

namespace ThucPham.Data
{
    public class WebApiDbContext : IdentityDbContext<User>
    {
        public WebApiDbContext() : base("WebAPIConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
      
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //them cac bang sau

        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Role> appRoles { get; set; }


        public static WebApiDbContext Create()
        {
            return new WebApiDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("Roles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("UserLogins");
            builder.Entity<IdentityRole>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.Id).ToTable("UserClaims");
        }
    }
}