using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DepartmentDAL
    {
        public static List<DEPARTMENT> LoadDepartment()
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstDepartment = db.DEPARTMENTs;
            return lstDepartment.ToList();
        }
    }
}
