using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace stvsystem.Data
{
    public class JudgeService : ServiceBase
    {
        //public JudgeService()
        //    :base()
        //{

        //}
        public IList<JudgeItem> SearchJudgeSetItems()
        {
            IList<JudgeItem> result = new List<JudgeItem>();
            result = db.Judges.Select(j => new JudgeItem
            {
                JudgeID = j.JudgeID,
                FirstName = j.FirstName,
                LastName = j.LastName,
                MiddleName = j.MiddleName,
                CourtID = j.CourtID,
                GenderID = j.GenderID,
                SpecializationID = j.SpecializationID
            }).ToList();

            return result;
            //try
            //{
                //var judgeQuery =  in db.Judges select judge;
                                 //    join t1 in db.Genders on judge.GenderID equals t1.GenderID into r1
                                 //    from gender in r1.DefaultIfEmpty()
                                 //    //join t2 in db.Regions on resident.RegionID equals t2.RegionID into r2
                                 //    //from region in r2.DefaultIfEmpty()
                                 //    //join t3 in db.Communities on resident.CommunityID equals t3.CommunityID into r3
                                 //    //from community in r3.DefaultIfEmpty()
                                 //select new
                                 //{
                                 //    JudgeTable = judge
                                 //    //GenderTable = gender
                                 //    //RegionTable = region,
                                 //    //CommunityTable = community
                                 //};


                //if (judgeItem.FirstName != "")
                //{
                //    judgeQuery = from p in judgeQuery where p.FirstName.StartsWith(residentSearch.FirstName) select p;
                //}
                //if (judgeItem.LastName != "")
                //{
                //    judgeQuery = from p in judgeQuery where p.ResidentTable.LastName.StartsWith(residentSearch.LastName) select p;
                //}

                //IList<JudgeItem> result = judgeQuery.Select
                //    (item => new ResidentSetItem
                //    {
                //        ResidentID = item.ResidentTable.ResidentID,
                //        FirstName = item.ResidentTable.FirstName,
                //        LastName = item.ResidentTable.LastName,
                //        MiddleName = item.ResidentTable.MiddleName,
                //        BirthDate = item.ResidentTable.BirthDate,
                //        IdentificatorNumber = item.ResidentTable.IdentificatorNumber,
                //        GenderID = item.ResidentTable.GenderID,
                //        RegionID = item.ResidentTable.RegionID,
                //        CommunityID = item.ResidentTable.CommunityID,
                //        Street = item.ResidentTable.Street,
                //        Building = item.ResidentTable.Building,
                //        Home = item.ResidentTable.Home,
                //        GenderName = item.GenderTable.GenderName,
                //        RegionName = item.RegionTable.RegionName,
                //        CommunityName = item.CommunityTable.CommunityName
                //    }).ToList();

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    exception = ex;
            //    return null;
            //}
        }

        public JudgeItem GetJudge(int? judgeID = null)
        {
            if(judgeID != null) {
                Judge dbItem = db.Judges.Find(judgeID);
                JudgeItem item = new JudgeItem
                {
                    JudgeID = dbItem.JudgeID,
                    CourtID = dbItem.CourtID,
                    SpecializationID = dbItem.SpecializationID,
                    FirstName = dbItem.FirstName,
                    LastName = dbItem.LastName,
                    MiddleName = dbItem.MiddleName,
                    GenderID= dbItem.GenderID
                };
                return item;
            }
            else
            {
                var item = new JudgeItem();
                return item;
            }
        }

        public JudgeItem InsertJudge(JudgeItem item)
        {
            Judge dbItem = new Judge
            {
                //JudgeID = (int)item.JudgeID,
                CourtID = item.CourtID,
                SpecializationID = item.SpecializationID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                GenderID = item.GenderID
            };
            db.Judges.Add(dbItem);
            db.SaveChanges();
            item.JudgeID = dbItem.JudgeID;
            return item;
        }
        public JudgeItem UpdateJudge(JudgeItem item)
        {
            Judge dbItem = db.Judges.Find(item.JudgeID);
            dbItem.JudgeID = (int)item.JudgeID;
            dbItem.CourtID = item.CourtID;
            dbItem.SpecializationID = item.SpecializationID;
            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;
            dbItem.MiddleName = item.MiddleName;
            dbItem.GenderID = item.GenderID;
            db.Judges.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }


        public void DeleteJudge(int id)
        {
            Judge dbItem = db.Judges.Find(id);
            db.Judges.Remove(dbItem);
            db.SaveChanges();
            //return item;
        }
        protected async Task<int> Count()
        {
            var count = await db.Judges.CountAsync();
            return count;
        }
    }
}
