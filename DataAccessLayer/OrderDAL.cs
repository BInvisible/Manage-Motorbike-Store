using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using DataAccessLayer;
using AutoMapper;

namespace DataAccessLayer
{
    public class OrderDAL
    {
        public static List<OrderDTO> LoadBill(int? maBILL)
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstOrder = db.BILLs.Where(n => n.CUSID == maBILL);
            var lstMoto = db.MOTORBIKEs;
            var lstCus = db.CUSTOMERs;
            List<OrderDTO> lstOrderDTO = new List<OrderDTO>();
            OrderDTO orDTO;
            foreach (var item in lstOrder)
            {
                orDTO = new OrderDTO();
                orDTO.BID = item.BID;
                orDTO.DATEBUY = item.DATEBUY;
                orDTO.QUANTITY = item.QUANTITY;
                MOTORBIKE mt = lstMoto.SingleOrDefault(n => n.MOTOID == item.MOTOID);
                if (mt != null)
                {
                    orDTO.MOTOID = mt.MOTOID;
                    orDTO.MOTONAME = mt.MOTONAME;
                    orDTO.TOTALMONEY = mt.PRICE * orDTO.QUANTITY;
                }
                CUSTOMER cs = lstCus.SingleOrDefault(n => n.CUSID == item.CUSID);
                if (cs != null)
                {
                    orDTO.CUSID = cs.CUSID;
                    orDTO.FIRSTNAME = cs.FIRSTNAME;
                    orDTO.LASTNAME = cs.LASTNAME;
                }
                lstOrderDTO.Add(orDTO);               
            }
            return lstOrderDTO;
        }
        public static List<OrderDTO> ThemBill(List<OrderDTO> lstBILL)
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstmoto = db.MOTORBIKEs;
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDTO, BILL>();
            });
            MotoDB1 dbo = new MotoDB1();
            List<BILL> nvInsert = Mapper.Map<List<OrderDTO>, List<BILL>>(lstBILL.ToList());
            try
            {
                nvInsert = dbo.BILLs.AddRange(nvInsert).ToList();
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            //nvInsert.
            //if (mt != null)
            //{
            //    nvDTO.DEPARTMENTNAME = bp.DEPARTMENTNAME;
            //}
            return lstBILL;

        }
        public static List<OrderDTO> UpdateBill(int CUSID, List<OrderDTO> lstBILL)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                bool kq = XoaBill(CUSID, lstBILL);
                if (kq == true)
                {
                    lstBILL = ThemBill(lstBILL);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return lstBILL;
        }
        public static bool XoaBill(int CUSID, List<OrderDTO> lstBILL)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                MotoDB1 dbo = new MotoDB1();
                IEnumerable<BILL> lstBillDelete = dbo.BILLs.Where(n => n.CUSID == CUSID);
                if (lstBillDelete.Count() != 0)
                {
                    dbo.BILLs.RemoveRange(lstBillDelete);
                    dbo.SaveChanges();
                    dbo.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
