using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class SpecializationService : ServiceBase
    {
        public SpecializationService(StvContext db)
            : base(db)
        {

        }

        public List<SelectListItem> GetSpecializationDropDownItems()
        {
            var list = new List<SelectListItem>();
            list = this.GetSpecializations().Select(x => new SelectListItem { Text = x.SpecializationName, Value = x.SpecializationID.ToString() }).ToList();
            return list;
        }
        public IList<Specialization> GetSpecializations()
        {
            IList<Specialization> result = new List<Specialization>();

            result = db.Specializations.Select(p => new Specialization
            {
                SpecializationID = p.SpecializationID,
                SpecializationName = p.SpecializationName
            }).ToList();
            return result;
        }
        public Specialization GetSpecialization(int SpecializationID)
        {
            Specialization dbItem = db.Specializations.Find(SpecializationID);
            Specialization item = new Specialization
            {
                SpecializationID = dbItem.SpecializationID,
                SpecializationName = dbItem.SpecializationName
            };
            return item;
        }        
        protected async Task<int> Count()
        {
            var count = await db.Specializations.CountAsync();
            return count;
        }
    }
}
