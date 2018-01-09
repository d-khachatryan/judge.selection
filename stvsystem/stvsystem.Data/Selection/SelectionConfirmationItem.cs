using System.ComponentModel.DataAnnotations;

namespace stvsystem.Data
{
    public class SelectionConfirmationItem
    {
        public int? CredentialID { get; set; }

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

        public int? CandidateIndex { get; set; }
    }
}
