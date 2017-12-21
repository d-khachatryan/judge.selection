using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CourtTypeService : ServiceBase
    {
        public CourtType GetCourtType(int CourtTypeID)
        {
            CourtType dbItem = db.CourtTypes.Find(CourtTypeID);
            CourtType item = new CourtType
            {
                CourtTypeID = dbItem.CourtTypeID,
                CourtTypeName = dbItem.CourtTypeName
            };
            return item;
        }        
        protected async Task<int> Count()
        {
            var count = await db.CourtTypes.CountAsync();
            return count;
        }
    }
}
