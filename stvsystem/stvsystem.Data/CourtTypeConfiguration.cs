using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class CourtTypeConfiguration : IEntityTypeConfiguration<CourtType>
    {
        public void Configure(EntityTypeBuilder<CourtType> builder)
        {
            builder.ToTable("CourtType", schema: "dbo");
            builder.HasKey(p => p.CourtTypeID);
            builder.Property(p => p.CourtTypeID).ValueGeneratedOnAdd();
            builder.Property(p => p.CourtTypeName).HasMaxLength(50);
        }
    }
}

