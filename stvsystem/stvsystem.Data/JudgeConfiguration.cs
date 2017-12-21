using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class JudgeConfiguration : IEntityTypeConfiguration<Judge>
    {
        public void Configure(EntityTypeBuilder<Judge> builder)
        {
            builder.ToTable("Judge", schema: "dbo");
            builder.HasKey(p => p.JudgeID);
            builder.Property(p => p.JudgeID).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.MiddleName).HasMaxLength(50);
        }
    }
}
