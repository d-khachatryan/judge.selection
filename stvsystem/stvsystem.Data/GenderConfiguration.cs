using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender", schema: "dbo");
            builder.HasKey(p => p.GenderID);
            builder.Property(p => p.GenderID).ValueGeneratedOnAdd();
            builder.Property(p => p.GenderName).HasMaxLength(50);
        }
    }
}

