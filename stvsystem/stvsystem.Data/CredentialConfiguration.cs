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
            builder.Property(p => p.Password).HasMaxLength(50);
        }
    }
}
