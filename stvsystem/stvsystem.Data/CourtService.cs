using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CourtService : ServiceBase
    {
        public List<SelectListItem> GetCourtDropDownItems()
        {
            var list = new List<SelectListItem>();
            list = this.GetCourts().Select(x => new SelectListItem { Text = x.CourtName, Value = x.CourtID.ToString() }).ToList();
            return list;
        }
        public IList<Court> GetCourts()
        {
            IList<Court> result = new List<Court>();

            result = db.Courts.Select(p => new Court
            {
                CourtID = p.CourtID,
                CourtTypeID = p.CourtTypeID,
                CourtName = p.CourtName
            }).ToList();
            return result;
        }
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
