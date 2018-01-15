using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stvsystem.Data
{
    public class Judge
    {
        [Display(Name = "Դատավոր")]
        public int JudgeID { get; set; }

        [Display(Name = "Դատարան")]
        public int? CourtID { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public int? SpecializationID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Սեռ")]
        public int? GenderID { get; set; }
    }

    public class JudgeItem
    {
        [Display(Name = "Դատավոր")]
        public int? JudgeID { get; set; }

        [Display(Name = "Դատարան")]
        public int? CourtID { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public int? SpecializationID { get; set; }

        [Display(Name = "Անուն")]
        [Required(ErrorMessage = "Անունը պարտադիր է")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        [Required(ErrorMessage = "Ազգանունը պարտադիր է")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Սեռ")]
        public int? GenderID { get; set; }

        [Display(Name = "Դատարան")]
        public string CourtName { get; set; }

        [Display(Name = "Մասնագիտություն")]
        public string SpecializationName { get; set; }

        [Display(Name = "Սեռ")]
        public string GenderName { get; set; }

        [Display(Name = "Դատավոր")]
        public string JudgeName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
