using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CourtService : ServiceBase
    {
        public Court GetCourt(int CourtID)
        {
            Court dbItem = db.Courts.Find(CourtID);
            Court item = new Court
            {
                CourtID = dbItem.CourtID,
                CourtTypeID = dbItem.CourtTypeID,
                CourtName = dbItem.CourtName
            };
            return item;
        }
        protected async Task<int> Count()
        {
            var count = await db.Courts.CountAsync();
            return count;
        }
    }
}
