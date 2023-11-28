using Microsoft.EntityFrameworkCore;
using PersonalSite.Models;

namespace PersonalSite.Data {
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<SkillItem> SkillItem { get; set; } = default!;

        public DbSet<BlogItem> BlogItems { get; set; } = default!;

        public DbSet<MailItem> MailItems { get; set; } = default!;
    }
}
