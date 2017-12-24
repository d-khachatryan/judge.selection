using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stvsystem.Data
{
    public class SelectionService : ServiceBase
    {
        public PasswordStatus ValidatePassword(PasswordItem item)
        {
            // test
            //return PasswordStatus.Success;


            var result = db.Credentials.Where(p => p.Password == item.Password);
            if (result.Count() > 0)
            {
                if (result.First().CredentialStatus == SelectionStatus.NoSelection)
                {
                    return PasswordStatus.Success;
                }
                else
                {
                    return PasswordStatus.DoubleLogin;
                }
            }
            else
            {
                return PasswordStatus.Fail;
            }
        }

        public SelectionItem SaveSelection(SelectionItem item)
        {
            // implement the save operation
            return item;
        }
    }
}
