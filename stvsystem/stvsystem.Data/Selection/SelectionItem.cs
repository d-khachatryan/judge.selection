using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class SelectionItem
    {
        public int? CredentialID { get; set; }

        public int? CourtID { get; set; }

        public int? CandidateID { get; set; }

        public int? CandidateIndex { get; set; }

        public int? SelectionCount { get; set; }

        public int? MaxSelectionCount { get;}

        public SelectionItem()
        {
            MaxSelectionCount = 15;
        }
    }
}
