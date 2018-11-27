using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PositionDAL
    {
        public static List<POSITION>LoadPosition()
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstPosition = db.POSITIONs;
            return lstPosition.ToList();
        }
    }
}
