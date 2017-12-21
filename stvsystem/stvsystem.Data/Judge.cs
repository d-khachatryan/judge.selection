using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class Judge
    {
        public int JudgeID { get; set; }
        public int? CourtID { get; set; }
        public int? SpecializationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? GenderID { get; set; }
    }

    public class JudgeItem
    {
        public int JudgeID { get; set; }
        public int? CourtID { get; set; }
        public int? SpecializationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? GenderID { get; set; }
        public string CourtName { get; set; }
        public string SpecializationName { get; set; }
        public string GenderName { get; set; }
    }
}
