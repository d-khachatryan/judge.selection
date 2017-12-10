using Microsoft.EntityFrameworkCore;

namespace stvsystem.Data
{
    public class StvContext : DbContext
    {
        public StvContext(DbContextOptions<StvContext> options)
            : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CandidateConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
        }
    }
}
