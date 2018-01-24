using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace stvsystem.Data
{
    public class Summary
    {
        [Display(Name = "Թեկնածու")]
        public int CandidateID { get; set; }

        [Display(Name = "N1")]
        public int N1 { get; set; }

        [Display(Name = "N2")]
        public int N2 { get; set; }

        [Display(Name = "N3")]
        public int N3 { get; set; }

        [Display(Name = "N4")]
        public int N4 { get; set; }

        [Display(Name = "N5")]
        public int N5 { get; set; }

        [Display(Name = "N6")]
        public int N6 { get; set; }

        [Display(Name = "N7")]
        public int N7 { get; set; }

        [Display(Name = "N8")]
        public int N8 { get; set; }

        [Display(Name = "N9")]
        public int N9 { get; set; }

        [Display(Name = "N10")]
        public int N10 { get; set; }

        [Display(Name = "N11")]
        public int N11 { get; set; }

        [Display(Name = "N12")]
        public int N12 { get; set; }

        [Display(Name = "N13")]
        public int N13 { get; set; }

        [Display(Name = "N14")]
        public int N14 { get; set; }

        [Display(Name = "N15")]
        public int N15 { get; set; }
    }

    public class SummaryItem
    {
        [Display(Name = "Թեկնածու")]
        public int? CandidateID { get; set; }

        [Display(Name = "Անուն")]
        public string FirstName { get; set; }

        [Display(Name = "Ազգանուն")]
        public string LastName { get; set; }

        [Display(Name = "Հայրանուն")]
        public string MiddleName { get; set; }

        [Display(Name = "Թեկնածու")]
        public string CandidateName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        [Display(Name = "1")]
        public int N1 { get; set; }

        [Display(Name = "2")]
        public int N2 { get; set; }

        [Display(Name = "3")]
        public int N3 { get; set; }

        [Display(Name = "4")]
        public int N4 { get; set; }

        [Display(Name = "5")]
        public int N5 { get; set; }

        [Display(Name = "6")]
        public int N6 { get; set; }

        [Display(Name = "7")]
        public int N7 { get; set; }

        [Display(Name = "8")]
        public int N8 { get; set; }

        [Display(Name = "9")]
        public int N9 { get; set; }

        [Display(Name = "10")]
        public int N10 { get; set; }

        [Display(Name = "11")]
        public int N11 { get; set; }

        [Display(Name = "12")]
        public int N12 { get; set; }

        [Display(Name = "13")]
        public int N13 { get; set; }

        [Display(Name = "14")]
        public int N14 { get; set; }

        [Display(Name = "15")]
        public int N15 { get; set; }

    }
}
