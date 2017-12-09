﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace stvsystem.Data
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }

    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate", schema: "dbo");
            builder.HasKey(p => p.CandidateID);
            builder.Property(p => p.CandidateID).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
            builder.Property(p => p.MiddleName).HasMaxLength(50);
        }
    }

    public class CandidateService : ServiceBase
    {
        public CandidateService()
            : base() { }
        public CandidateService(StvContext context)
            : base(context) { }
        public Candidate InsertCandidate(Candidate item)
        {
            db.Candidates.Add(item);
            db.SaveChanges();
            return item;
        }
    }
}
