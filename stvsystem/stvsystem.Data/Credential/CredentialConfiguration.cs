using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class CredentialConfiguration : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.ToTable("Credential", schema: "dbo");
            builder.HasKey(p => p.CredentialID);
            builder.Property(p => p.CredentialID).ValueGeneratedOnAdd();
            builder.Property(p => p.Password).HasMaxLength(6);

            builder.HasOne(c => c.Setting)
            .WithMany(o => o.Credentials)
            .HasForeignKey(o => o.SettingID)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
