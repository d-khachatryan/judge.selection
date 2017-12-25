using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public enum PasswordStatus { Initialization = 0, Success = 1, Fail = 2, DoubleLogin = 3 }
    public enum CredentialStatus { NoSelection = 1, Done = 2 }
    public enum SettingStatus : int { InPreparation = 1, InProcess = 2, Finished = 3 }
}
