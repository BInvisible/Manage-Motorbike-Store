using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class InsuranceDAL
    {
        public static List<INSURANCE>LoadBaoHiem(int maNV)
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstBaoHiem = db.INSURANCEs.Where(n => n.EID == maNV);
            if(lstBaoHiem.Count()!=0)
            {
                return lstBaoHiem.ToList();
            }
            return null;
        }
        public static List<INSURANCE>ThemBaoHiem(List<INSURANCE>lstBH)
        {
            MotoDB1 db =DataProvider.dbContext;
            try
            {
                MotoDB1 dbo = new MotoDB1();
                List<INSURANCE>lstBHInsert= db.INSURANCEs.AddRange(lstBH).ToList();
                db.SaveChanges();
                //dbo.Dispose();
            }
            catch(Exception ex)
            {
                return null;
            }   
            return lstBH;

        }
        public static List<INSURANCE> UpdateBaoHiem(int EID,List<INSURANCE> lstBH)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                bool kq = XoaBaoHiem(EID,lstBH);
                if(kq==true)
                {
                    lstBH = ThemBaoHiem(lstBH);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return lstBH;
        }
        public static bool XoaBaoHiem(int EID,List<INSURANCE> lstBH)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                MotoDB1 dbo = new MotoDB1();
                //IEnumerable<INSURANCE> lstTestBH = db.INSURANCEs;
                //foreach (var itemTestBH in lstTestBH)
                //{
                //    foreach (var itemBH in lstBH)
                //    {
                //        if (itemTestBH.INSURANCEID == itemBH.INSURANCEID)
                //        {
                //            return false;
                //        }
                //    }
                //}
                //if (lstBH.Count > 1)
                //{
                //    for (int i = 0; i < lstBH.Count; i++)
                //    {
                //        for (int j = i + 1; j < lstBH.Count; j++)
                //        {
                //            if (lstBH.ElementAt(i) == lstBH.ElementAt(j))
                //            {
                //                return false;
                //            }
                //        }
                //    }
                //}

                IEnumerable<INSURANCE> lstBaoHiemDelete = dbo.INSURANCEs.Where(n => n.EID == EID);
                if(lstBaoHiemDelete.Count()!=0)
                {
                    dbo.INSURANCEs.RemoveRange(lstBaoHiemDelete);
                    dbo.SaveChanges();
                    dbo.Dispose();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
