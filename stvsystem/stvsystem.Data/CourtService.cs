using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
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
                CourtName = p.CourtName
            }).ToList();
            return result;
        }

        public IList<CourtItem> Search(string name, string type)
        {
            IList<CourtItem> result = (from court in db.Courts
                                       join t1 in db.CourtTypes on court.CourtTypeID equals t1.CourtTypeID into r1
                                       from courtType in r1.DefaultIfEmpty()
                                       select new
                                       {
                                           CourtTable = court,
                                           CourtTypeTable = courtType
                                       }).Select(list => new CourtItem
                                       {
                                           CourtID = list.CourtTable.CourtID,
                                           CourtName = list.CourtTable.CourtName,
                                           CourtTypeID = list.CourtTable.CourtTypeID,
                                           CourtTypeName = list.CourtTypeTable.CourtTypeName
                                       }).ToList();

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(p => p.CourtName.StartsWith(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(type))
            {
                int id = Convert.ToInt32(type);
                CourtType courtType = db.CourtTypes.Find(id);
                result = result.Where(p => p.CourtTypeName == courtType.CourtTypeName).ToList();
            }
            return result;
        }


        public CourtItem GetCourt(int? courtID = null)
        {
            if (courtID != null)
            {
                var dbItem = (from court in db.Courts
                              join t1 in db.CourtTypes on court.CourtTypeID equals t1.CourtTypeID into r1
                              from courtType in r1.DefaultIfEmpty()
                              where court.CourtID == courtID
                              select new { courtTable = court, courtTypeTable = courtType })
                             .Select(list => new CourtItem
                             {
                                 CourtID = list.courtTable.CourtID,
                                 CourtName = list.courtTable.CourtName,
                                 CourtTypeID = list.courtTable.CourtTypeID,
                                 CourtTypeName = list.courtTypeTable.CourtTypeName
                             }).First();


                CourtItem item = new CourtItem
                {
                    CourtID = dbItem.CourtID,
                    CourtName = dbItem.CourtName,
                    CourtTypeID = dbItem.CourtTypeID,
                    CourtTypeName = dbItem.CourtTypeName
                };
                return item;
            }
            else
            {
                var item = new CourtItem();
                return item;
            }
        }


        public CourtItem InsertCourt(CourtItem item)
        {
            Court dbItem = new Court
            {
                CourtName = item.CourtName,
                CourtTypeID = item.CourtTypeID
            };
            db.Courts.Add(dbItem);
            db.SaveChanges();
            item.CourtID = dbItem.CourtID;
            return item;
        }
        public CourtItem UpdateCourt(CourtItem item)
        {
            Court dbItem = db.Courts.Find(item.CourtID);
            dbItem.CourtID = (int)item.CourtID;
            dbItem.CourtName = item.CourtName;
            dbItem.CourtTypeID = item.CourtTypeID;
            db.Courts.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }


        public void DeleteCourt(int id)
        {
            Court dbItem = db.Courts.Find(id);
            db.Courts.Remove(dbItem);
            db.SaveChanges();
        }

        protected async Task<int> Count()
        {
            var count = await db.Courts.CountAsync();
            return count;
        }
    }
}
