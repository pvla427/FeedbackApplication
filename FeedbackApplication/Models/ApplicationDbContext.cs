using Microsoft.EntityFrameworkCore;

namespace FeedbackApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Topic>().HasData(
                new Topic { Id = 1, Name = "Техподдержка" }, 
                new Topic { Id = 2, Name = "Продажи"}, 
                new Topic { Id = 3, Name = "Другое" });
        }
    }
}
