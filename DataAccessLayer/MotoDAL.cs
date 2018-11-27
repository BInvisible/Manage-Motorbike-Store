using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using AutoMapper;

namespace DataAccessLayer
{
    public class MotoDAL
    {
        public static List<MotorbikeDTO> LoadMOTORBIKE()
        {

            MotoDB1 db = DataProvider.dbContext;
            var lstMoto = db.MOTORBIKEs;
            List<MotorbikeDTO> lstMotorbikeDTO = new List<MotorbikeDTO>();
            MotorbikeDTO motoDTO;
            foreach (var item in lstMoto)
            {
                motoDTO = new MotorbikeDTO();
                motoDTO.MOTOID = item.MOTOID;
                motoDTO.MOTONAME = item.MOTONAME;
                motoDTO.PRODUCER = item.PRODUCER;
                motoDTO.CAPACITY = item.CAPACITY;
                motoDTO.COLOR = item.COLOR;
                motoDTO.PICTURE = item.PICTURE;
                motoDTO.PRICE = item.PRICE;
                lstMotorbikeDTO.Add(motoDTO);
            }
            return lstMotorbikeDTO;
        }
        public static MotorbikeDTO Load(MotorbikeDTO motoDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<MotorbikeDTO, MOTORBIKE>();
                });
                MotoDB1 dbo = new MotoDB1();
                MOTORBIKE nvUpdate = Mapper.Map<MotorbikeDTO, MOTORBIKE>(motoDTO);
                dbo.Entry(nvUpdate).State = System.Data.Entity.EntityState.Unchanged;
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            return motoDTO;

            //MotoDB1 db = DataProvider.dbContext;
            //var lstMoto = db.MOTORBIKEs;
            //MotorbikeDTO lstMotorbikeDTO = new MotorbikeDTO();
            //MotorbikeDTO motoDTO;
            //foreach (var item in lstMoto)
            //{
            //    motoDTO = new MotorbikeDTO();
            //    motoDTO.MOTOID = item.MOTOID;
            //    motoDTO.MOTONAME = item.MOTONAME;
            //    motoDTO.PRODUCER = item.PRODUCER;
            //    motoDTO.CAPACITY = item.CAPACITY;
            //    motoDTO.COLOR = item.COLOR;
            //    motoDTO.PICTURE = item.PICTURE;
            //    motoDTO.PRICE = item.PRICE;
            //    lstMotorbikeDTO(motoDTO);
            //}
            //return lstMotorbikeDTO;
        }
        public static MotorbikeDTO UpdateMOTORBIKE(MotorbikeDTO nvDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<MotorbikeDTO, MOTORBIKE>();
                });
                MotoDB1 dbo = new MotoDB1();
                MOTORBIKE nvUpdate = Mapper.Map<MotorbikeDTO, MOTORBIKE>(nvDTO);
                dbo.Entry(nvUpdate).State = System.Data.Entity.EntityState.Modified;
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            return nvDTO;
        }

        public static MotorbikeDTO AddMOTORBIKE(MotorbikeDTO nvDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MotorbikeDTO, MOTORBIKE>();
            });
            MotoDB1 dbo = new MotoDB1();
            MOTORBIKE nvInsert = Mapper.Map<MotorbikeDTO, MOTORBIKE>(nvDTO);
            try
            {
                nvInsert = dbo.MOTORBIKEs.Add(nvInsert);
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            //nvDTO.MOTOID = nvInsert.MOTOID;
            return nvDTO;

        }
        public static bool DeleteMOTORBIKE(int maNV)
        {
            try
            {
                MotoDB1 dbo = new MotoDB1();
                MOTORBIKE em = dbo.MOTORBIKEs.SingleOrDefault(n => n.MOTOID == maNV);
                if (em != null)
                {
                    dbo.MOTORBIKEs.Remove(em);
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
