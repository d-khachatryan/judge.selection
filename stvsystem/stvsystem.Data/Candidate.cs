using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;

namespace stvsystem.Data
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? GenderID { get; set; }
        public int? CourtID { get; set; }
        public int? SpecializationID { get; set; }
    }

    public class CandidateItem
    {
        public int CandidateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? GenderID { get; set; }
        public int? CourtID { get; set; }
        public int? SpecializationID { get; set; }
        public string CourtName { get; set; }
        public string SpecializationName { get; set; }
        public string GenderName { get; set; }

        public string CandidateName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }

    

    
}
