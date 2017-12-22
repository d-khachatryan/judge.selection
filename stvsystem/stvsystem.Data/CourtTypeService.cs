using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CourtTypeService : ServiceBase
    {
        public List<SelectListItem> GetCourtTypeDropDownItems()
        {
            var list = new List<SelectListItem>();
            list = this.GetCourtTypes().Select(x => new SelectListItem { Text = x.CourtTypeName, Value = x.CourtTypeID.ToString() }).ToList();
            return list;
        }
        public IList<CourtType> GetCourtTypes()
        {
            IList<CourtType> result = new List<CourtType>();

            result = db.CourtTypes.Select(p => new CourtType
            {
                CourtTypeID = p.CourtTypeID,
                CourtTypeName = p.CourtTypeName
            }).ToList();
            return result;
        }
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
