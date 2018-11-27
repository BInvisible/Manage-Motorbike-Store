using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DepartmentBUS
    {
        public static List<DEPARTMENT> LoadDepartment()
        {
            return DepartmentDAL.LoadDepartment();
        }
    }
}
