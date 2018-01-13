using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace stvsystem.Data
{
    public class Setting
    {
        public int SettingID { get; set; }

        [Display(Name = "Ընտրության անվանում")]
        public string SelectionName { get; set; }

        [Display(Name = "Ընտրության ա/թ")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SelectionDate { get; set; }

        [Display(Name = "Մեկնարկի ժամը")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Ավարտի ժամը")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FinishTime { get; set; }

        [Display(Name = "Թեկնածուների թիվը")]
        public int? SelectionCount { get; set; }

        [Display(Name = "Մասնակիցների թիվը")]
        public int? ParticipantCount { get; set; }

        public SettingStatus SelectionStatus { get; set; }

        public virtual ICollection<Credential> Credentials { get; private set; }
    }

    public class SettingItem
    {
        public int SettingID { get; set; }

        [Display(Name = "Ընտրության անվանում")]
        [Required(ErrorMessage = "Ընտրության անվանումը պարտադիր է")]
        public string SelectionName { get; set; }

        [Display(Name = "Ընտրության ա/թ")]
        [Required(ErrorMessage = "Ընտրության ամսաթիվը պարտադիր է")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SelectionDate { get; set; }

        [Display(Name = "Մեկնարկի ժամը")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Մեկնարկի ժամը պարտադիր է")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Ավարտի ժամը")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ավարտի ժամը պարտադիր է")]
        public DateTime? FinishTime { get; set; }

        [Display(Name = "Թեկնածուների թիվը")]
        [Required(ErrorMessage = "Թեկնածուների թիվը պարտադիր է")]
        public int? SelectionCount { get; set; }

        [Display(Name = "Մասնակիցների թիվը")]
        [Required(ErrorMessage = "Մասնակիցների թիվը պարտադիր է")]
        public int? ParticipantCount { get; set; }

        public SettingStatus SelectionStatus { get; set; }
    }
}
