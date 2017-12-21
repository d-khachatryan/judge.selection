using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.ToTable("Court", schema: "dbo");
            builder.HasKey(p => p.CourtID);
            builder.Property(p => p.CourtID).ValueGeneratedOnAdd();
            builder.Property(p => p.CourtName).HasMaxLength(150);
        }
    }
}

