using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("Specialization", schema: "dbo");
            builder.HasKey(p => p.SpecializationID);
            builder.Property(p => p.SpecializationID).ValueGeneratedOnAdd();
            builder.Property(p => p.SpecializationName).HasMaxLength(50);
        }
    }
}

