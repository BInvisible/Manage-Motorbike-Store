using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DegreeDAL
    {
        public static List<DEGREE>LoadDegree()
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstDegree = db.DEGREEs;
            return lstDegree.ToList();
        }
    }
}
