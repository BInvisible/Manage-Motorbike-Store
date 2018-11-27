using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;
using AutoMapper;

namespace DataAccessLayer
{
    public class EmployeeDAL
    {

        public static List<EmployeeDTO> LoadEmployee()
        {

            MotoDB1 db = DataProvider.dbContext;
            var lstEmployee = db.EMPLOYEEs;
            var lstDegree = db.DEGREEs;
            var lstPosition = db.POSITIONs;
            var lstDepartment = db.DEPARTMENTs;
            List<EmployeeDTO> lstEmployeeDTO = new List<EmployeeDTO>();
            EmployeeDTO emDTO;
            foreach(var item in lstEmployee)
            {
                emDTO = new EmployeeDTO();
                emDTO.EID = item.EID;
                emDTO.FIRSTNAME = item.FIRSTNAME;
                emDTO.LASTNAME = item.LASTNAME;
                emDTO.PHONENUMBER = item.PHONENUMBER;
                emDTO.ADDDRESSS = item.ADDDRESSS;
                emDTO.GENDER = item.GENDER;
                emDTO.DOB = item.DOB;
                emDTO.PICTURE = item.PICTURE;
                emDTO.IDCARD = item.IDCARD;
                DEGREE dg = lstDegree.SingleOrDefault(n => n.DEGREEID == item.DEGREEID);
                if(dg!=null)
                {
                    emDTO.DEGREENAME = dg.DEGREENAME;
                }
                POSITION ps = lstPosition.SingleOrDefault(n => n.POSITIONID == item.POSITIONID);
                if (ps != null)
                {
                    emDTO.POSITIONNAME = ps.POSITIONNAME;
                }
                DEPARTMENT dp = lstDepartment.SingleOrDefault(n => n.DEPARTMENTID == item.DEPARTMENTID);
                if (dp != null)
                {
                    emDTO.DEPARTMENTNAME = dp.DEPARTMENTNAME;
                }

                lstEmployeeDTO.Add(emDTO);
            }
            return lstEmployeeDTO;
        }

        public static EmployeeDTO UpdateEm(EmployeeDTO nvDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstDegree = db.DEGREEs;
            var lstPosition = db.POSITIONs;
            var lstDepartment = db.DEPARTMENTs;
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<EmployeeDTO, EMPLOYEE>();
                });
                MotoDB1 dbo = new MotoDB1();
                EMPLOYEE nvUpdate = Mapper.Map<EmployeeDTO, EMPLOYEE>(nvDTO);
                //MotoDB1 dbo = new MotoDB1();
                //EMPLOYEE nvUpdate = dbo.EMPLOYEEs.SingleOrDefault(n => n.EID == nvDTO.EID);
                //nvUpdate.EID = nvDTO.EID;
                //nvUpdate.FIRSTNAME = nvDTO.FIRSTNAME;
                //nvUpdate.LASTNAME = nvDTO.LASTNAME;
                //nvUpdate.IDCARD = nvDTO.IDCARD;
                //nvUpdate.GENDER = nvDTO.GENDER;
                //nvUpdate.DOB = nvDTO.DOB;
                //nvUpdate.ADDDRESSS = nvDTO.ADDDRESSS;
                //nvUpdate.PHONENUMBER = nvDTO.PHONENUMBER;
                //nvUpdate.PICTURE = nvDTO.PICTURE;
                //nvUpdate.POSITIONID = nvDTO.POSITIONID;
                //nvUpdate.DEPARTMENTID = nvDTO.DEPARTMENTID;
                //nvUpdate.DEGREEID = nvDTO.DEGREEID;
                dbo.Entry(nvUpdate).State = System.Data.Entity.EntityState.Modified;
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch(Exception ex)
            {
                return null;
            }
            DEGREE dg = lstDegree.SingleOrDefault(n => n.DEGREEID == nvDTO.DEGREEID);
            if (dg != null)
            {
                nvDTO.DEGREENAME = dg.DEGREENAME;
            }
            POSITION ps = lstPosition.SingleOrDefault(n => n.POSITIONID == nvDTO.POSITIONID);
            if (ps != null)
            {
                nvDTO.POSITIONNAME = ps.POSITIONNAME;
            }
            DEPARTMENT dp = lstDepartment.SingleOrDefault(n => n.DEPARTMENTID == nvDTO.DEPARTMENTID);
            if (dp != null)
            {
                nvDTO.DEPARTMENTNAME = dp.DEPARTMENTNAME;
            }
            return nvDTO;
        }

        public static EmployeeDTO AddEm(EmployeeDTO nvDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstDepartment = db.DEPARTMENTs;
            var lstPosition = db.POSITIONs;
            var lstDegree = db.DEGREEs;
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, EMPLOYEE>();
            });
            MotoDB1 dbo = new MotoDB1();
            EMPLOYEE nvInsert = Mapper.Map<EmployeeDTO, EMPLOYEE>(nvDTO);
            //EMPLOYEE nvInsert = new EMPLOYEE();
            //nvInsert.FIRSTNAME=
            try
            {
                nvInsert = dbo.EMPLOYEEs.Add(nvInsert);
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch(Exception ex)
            {
                return null;
            }
            nvDTO.EID = nvInsert.EID;
            DEPARTMENT bp = lstDepartment.SingleOrDefault(n => n.DEPARTMENTID == nvInsert.DEPARTMENTID);
            if(bp!=null)
            {
                nvDTO.DEPARTMENTNAME = bp.DEPARTMENTNAME;
            }
            DEGREE dg = lstDegree.SingleOrDefault(n => n.DEGREEID == nvInsert.DEGREEID);
            if (dg != null)
            {
                nvDTO.DEGREENAME = dg.DEGREENAME;
            }
            POSITION ps = lstPosition.SingleOrDefault(n => n.POSITIONID == nvInsert.POSITIONID);
            if (ps != null)
            {
                nvDTO.POSITIONNAME = ps.POSITIONNAME;
            }
            return nvDTO;

        }
        public static bool DeleteEm(int maNV)
        {
            try
            {
                MotoDB1 dbo = new MotoDB1();
                EMPLOYEE em = dbo.EMPLOYEEs.SingleOrDefault(n => n.EID == maNV);
                if(em!=null)
                {
                    dbo.EMPLOYEEs.Remove(em);
                    dbo.SaveChanges();
                    dbo.Dispose();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
