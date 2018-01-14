using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class CredentialStatisticItem
    {
        public CredentialStatus Status { get; set; }

        public int StatusCount { get; set; }

        public string StatusName
        {
            get
            {
                if (Status == CredentialStatus.NoSelection)
                {
                    return "Չի քվեարկել";
                }
                else
                {
                    return "Արդեն քվեարկել է";
                }
            }
        }


    }
}
