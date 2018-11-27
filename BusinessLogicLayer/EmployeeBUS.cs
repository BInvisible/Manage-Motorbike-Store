using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class EmployeeBUS
    {
        public static List<EmployeeDTO> LoadEmployee()
        {
            return EmployeeDAL.LoadEmployee();
        }
        public static EmployeeDTO AddEm(EmployeeDTO nvDTO)
        {
            return EmployeeDAL.AddEm(nvDTO);
        }
        public static EmployeeDTO UpdateEm(EmployeeDTO nvDTO)
        {
            return EmployeeDAL.UpdateEm(nvDTO);
        }
        public static bool DeleteEm(int EID)
        {
            return EmployeeDAL.DeleteEm(EID);
        }
    }
}
