using System.ComponentModel.DataAnnotations;

namespace stvsystem.Data
{
    public class Court
    {
        [Display(Name = "Դատարան")]
        public int CourtID { get; set; }

        [Display(Name = "Տեսակը")]
        public int? CourtTypeID { get; set; }

        [Display(Name = "Անվանումը")]
        public string CourtName { get; set; }
    }

    public class CourtItem
    {
        [Display(Name = "Դատարան")]
        public int? CourtID { get; set; }

        [Display(Name = "Տեսակը")]
        [Required(ErrorMessage ="Տեսակը պարտադիր է")]
        public int? CourtTypeID { get; set; }

        [Display(Name = "Տեսակը")]
        public string CourtTypeName { get; set; }

        [Display(Name = "Անվանումը")]
        [Required(ErrorMessage = "Անվանումը պարտադիր է")]
        public string CourtName { get; set; }
    }
}
