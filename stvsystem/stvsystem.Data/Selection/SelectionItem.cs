using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stvsystem.Data
{
    public class SelectionItem
    {
        public int? CredentialID { get; set; }

        [Display(Name = "Դատարան")]
        [Required(ErrorMessage = "Դատարանը պարտադիր է")]
        public int? CourtID { get; set; }

        [Display(Name = "Թեկնածու")]
        [Required(ErrorMessage = "Թեկնածուն պարտադիր է")]
        public int? CandidateID { get; set; }

        [Display(Name = "Առաջնահերթություն")]
        public int? CandidateIndex { get; set; }

        public int? SelectionCount { get; set; }

        public int? MaxSelectionCount { get;}

        public SelectionItem()
        {
            MaxSelectionCount = 15;
        }
    }
}
