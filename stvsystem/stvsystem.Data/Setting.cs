using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class Setting
    {
        public int SettingID { get; set; }

        public string SelectionName { get; set; }

        public DateTime? SelectionDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }

        public int? SelectionCount { get; set; }

        public int? ParticipantCount { get; set; }

        public SettingStatus SelectionStatus { get; set; }
    }

    public class SettingItem
    {
        public int SettingID { get; set; }

        public string SelectionName { get; set; }

        public DateTime? SelectionDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }

        public int? SelectionCount { get; set; }

        public int? ParticipantCount { get; set; }

        public SettingStatus SelectionStatus { get; set; }
    }
}
