using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Result", schema: "dbo");
            builder.HasKey(p => p.ResultID);
            builder.Property(p => p.ResultID).ValueGeneratedOnAdd();
        }
    }
}
