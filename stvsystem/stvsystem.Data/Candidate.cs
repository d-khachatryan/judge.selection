using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;

namespace stvsystem.Data
{
    public class Candidate
    {
        [Display(Name = "Թեկնածու")]
        public int CandidateID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Ծննդյան ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սեռ")]
        public int? GenderID { get; set; }

        [Display(Name = "Դատարան")]
        public int? CourtID { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public int? SpecializationID { get; set; }
    }

    public class CandidateItem
    {
        [Display(Name = "Թեկնածու")]
        public int? CandidateID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Ծննդյան ա/թ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Սեռ")]
        public int? GenderID { get; set; }

        [Display(Name = "Դատարան")]
        public int? CourtID { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public int? SpecializationID { get; set; }

        [Display(Name = "Դատարան")]
        public string CourtName { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public string SpecializationName { get; set; }

        [Display(Name = "Սեռ")]
        public string GenderName { get; set; }

        [Display(Name = "Թեկնածու")]
        public string CandidateName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }

    

    
}
