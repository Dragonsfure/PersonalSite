using Microsoft.EntityFrameworkCore;
using PersonalSite.Models;

namespace PersonalSite.Data {
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public DbSet<SkillItem> SkillItem { get; set; } = default!;

        public DbSet<BlogItem> BlogItems { get; set; } = default!;

        public DbSet<MailItem> MailItems { get; set; } = default!;
    }
}
