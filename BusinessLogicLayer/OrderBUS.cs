using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class OrderBUS
    {
        public static List<OrderDTO> LoadBill(int? CUSID)
        {
            return DataAccessLayer.OrderDAL.LoadBill(CUSID);
        }
        public static List<OrderDTO> UpdateBill(int CUSID, List<OrderDTO> lstCUS)
        {
            return DataAccessLayer.OrderDAL.UpdateBill(CUSID, lstCUS);
        }
    }
}
