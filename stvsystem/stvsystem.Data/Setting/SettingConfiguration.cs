using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace stvsystem.Data
{
    class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting", schema: "dbo");
            builder.HasKey(p => p.SettingID);
            builder.Property(p => p.SettingID).ValueGeneratedOnAdd();
            builder.Property(p => p.SelectionName).HasMaxLength(50);
        }
    }
}
