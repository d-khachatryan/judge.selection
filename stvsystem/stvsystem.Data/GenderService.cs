using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class GenderService : ServiceBase
    {
        public Gender GetGender(int GenderID)
        {
            Gender dbItem = db.Genders.Find(GenderID);
            Gender item = new Gender
            {
                GenderID = dbItem.GenderID,
                GenderName = dbItem.GenderName
            };
            return item;
        }        
        protected async Task<int> Count()
        {
            var count = await db.Genders.CountAsync();
            return count;
        }
    }
}
