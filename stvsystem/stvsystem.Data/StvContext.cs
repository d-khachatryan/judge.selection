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
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Result> Results { get; set; }


        public DbSet<Gender> Genders { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtType> CourtTypes { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CandidateConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
            builder.ApplyConfiguration(new CredentialConfiguration());
            builder.ApplyConfiguration(new JudgeConfiguration());
            builder.ApplyConfiguration(new ResultConfiguration());
            builder.ApplyConfiguration(new GenderConfiguration());
            builder.ApplyConfiguration(new CourtConfiguration());
            builder.ApplyConfiguration(new CourtTypeConfiguration());
            builder.ApplyConfiguration(new SpecializationConfiguration());
        }
    }
}
