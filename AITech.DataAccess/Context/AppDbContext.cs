using AITech.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace AITech.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<About> Abouts { get; set; }
        DbSet<AboutItem> AboutItems { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Choose> Chooses { get; set; }
        DbSet<FAQ> FAQs { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Social> Socials { get; set; }
        DbSet<Testimonial> Testimonials { get; set; }
    }
}
