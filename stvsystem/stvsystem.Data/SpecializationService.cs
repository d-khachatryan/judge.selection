using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class SpecializationService : ServiceBase
    {
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
