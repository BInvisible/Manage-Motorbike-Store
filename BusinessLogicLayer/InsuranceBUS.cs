using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class InsuranceBUS
    {
        public static List<INSURANCE>LoadBaoHiem(int maNV)
        {
            return InsuranceDAL.LoadBaoHiem(maNV);
        }
        public static List<INSURANCE>UpdateBaoHiem(int EID,List<INSURANCE>lstBH)
        {
            return InsuranceDAL.UpdateBaoHiem(EID, lstBH);
        }
    }
}
