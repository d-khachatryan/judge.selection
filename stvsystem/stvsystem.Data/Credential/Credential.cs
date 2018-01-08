using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class Credential
    {
        public int CredentialID { get; set; }

        public string Password { get; set; }

        public int? SettingID { get; set; }

        public CredentialStatus  Status { get; set; }

        public DateTime? UsageDateTime { get; set; }
    }

    public class CredentialItem
    {
        public int CredentialID { get; set; }

        public string Password { get; set; }

        public int? SettingID { get; set; }

        public CredentialStatus CredentialStatus { get; set; }

        public DateTime? UsageDateTime { get; set; }
    }
}
