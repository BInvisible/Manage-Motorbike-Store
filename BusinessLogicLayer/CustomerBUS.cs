using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class CustomerBUS
    {
        public static List<CustomerDTO> LoadCus()
        {
            return CustomerDAL.LoadCus();
        }
        public static CustomerDTO AddCus(CustomerDTO cusDTO)
        {
            return CustomerDAL.AddCus(cusDTO);
        }
        public static CustomerDTO UpdateEm(CustomerDTO cusDTO)
        {
            return CustomerDAL.UpdateCus(cusDTO);
        }
        public static bool DeleteEm(int CUSID)
        {
            return CustomerDAL.DeletecCUS(CUSID);
        }
    }
}
