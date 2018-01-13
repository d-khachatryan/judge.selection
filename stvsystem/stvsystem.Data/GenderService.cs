using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class GenderService : ServiceBase
    {
        public GenderService(StvContext db)
            : base(db)
        {

        }
        public List<SelectListItem> GetGenderDropDownItems()
        {
            var list = new List<SelectListItem>();
            list = this.GetGenders().Select(x => new SelectListItem { Text = x.GenderName, Value = x.GenderID.ToString() }).ToList();
            return list;
        }
        public IList<Gender> GetGenders()
        {
            IList<Gender> result = new List<Gender>();

            result = db.Genders.Select(p => new Gender
            {
                GenderID = p.GenderID,
                GenderName = p.GenderName
            }).ToList();
            return result;
        }
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
