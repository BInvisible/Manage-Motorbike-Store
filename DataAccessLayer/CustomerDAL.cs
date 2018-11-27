using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObject;

namespace DataAccessLayer
{
    public class CustomerDAL
    {
        public static List<CustomerDTO> LoadCus()
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstCus = db.CUSTOMERs;
            List<CustomerDTO> lstCusDTO = new List<CustomerDTO>();
            CustomerDTO cusDTO;
            foreach (var item in lstCus)
            {
                cusDTO = new CustomerDTO();
                cusDTO.CUSID = item.CUSID;
                cusDTO.FIRSTNAME = item.FIRSTNAME;
                cusDTO.LASTNAME = item.LASTNAME;
                cusDTO.ADDRESSS = item.ADDRESSS;
                cusDTO.PHONENUMBER = item.PHONENUMBER;
                cusDTO.IDCARD = item.IDCARD;
                lstCusDTO.Add(cusDTO);
            }
            return lstCusDTO;
        }

        public static CustomerDTO UpdateCus(CustomerDTO cusDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                MotoDB1 dbo = new MotoDB1();
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<CustomerDTO, CUSTOMER>();
                });

                CUSTOMER cusUpdate = Mapper.Map<CustomerDTO, CUSTOMER>(cusDTO);
                //MotorbikeDBEntities dbo = new MotorbikeDBEntities();
                //CUSTOMER cusUpdate = dbo.CUSTOMERs.SingleOrDefault(n => n.CUSID == cusDTO.CUSID);
                //cusUpdate.CUSID = cusDTO.CUSID;
                //cusUpdate.FIRSTNAME = cusDTO.FIRSTNAME;
                //cusUpdate.LASTNAME = cusDTO.LASTNAME;
                //cusUpdate.IDCARD = cusDTO.IDCARD;
                //cusUpdate.GENDER = cusDTO.GENDER;
                //cusUpdate.DOB = cusDTO.DOB;
                //cusUpdate.ADDDRESSS = cusDTO.ADDDRESSS;
                //cusUpdate.PHONENUMBER = cusDTO.PHONENUMBER;
                dbo.Entry(cusUpdate).State = System.Data.Entity.EntityState.Modified;
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            
            return cusDTO;
        }

        public static CustomerDTO AddCus(CustomerDTO cusDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerDTO, CUSTOMER>();
            });

            CUSTOMER cusInsert = Mapper.Map<CustomerDTO, CUSTOMER>(cusDTO);
            try
            {
                cusInsert = db.CUSTOMERs.Add(cusInsert);
                db.SaveChanges();
                //dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            cusDTO.CUSID = cusInsert.CUSID;
           
            return cusDTO;

        }
        public static bool DeletecCUS(int maCUS)
        {
            try
            {
                MotoDB1 dbo = new MotoDB1();
                CUSTOMER cus = dbo.CUSTOMERs.SingleOrDefault(n => n.CUSID == maCUS);
                if (cus != null)
                {
                    dbo.CUSTOMERs.Remove(cus);
                    dbo.SaveChanges();
                    dbo.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
