using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataTransferObject;
using AutoMapper;

namespace DataAccessLayer
{
    public class LoginDAL:DataProvider
    {
        MotoDB1 Account = new MotoDB1();
        public bool KTDangNhap(string username,string password)
        {
            int account = (from tk in Account.Logins
                           where tk.Username == username && tk.Password == password
                           select tk).Count();
            if (account == 1)
                return true;
            else
                return false;
                        
        }
        public static List<LoginDTO> LoadLogin()
        {
            MotoDB1 db = DataProvider.dbContext;
            var lstlog = db.Logins;
            List<LoginDTO> lstlogDTO = new List<LoginDTO>();
            LoginDTO logDTO;
            foreach (var item in lstlog)
            {
                logDTO = new LoginDTO();
                logDTO.Username = item.Username;
                logDTO.Password = item.Password;
                logDTO.Authority = item.Authority;
                lstlogDTO.Add(logDTO);
            }
            return lstlogDTO;
        }
        public static LoginDTO AddLogin(LoginDTO logDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LoginDTO, Login>();
            });
            MotoDB1 dbo = new MotoDB1();
            Login nvInsert = Mapper.Map<LoginDTO, Login>(logDTO);
            try
            {
                nvInsert = dbo.Logins.Add(nvInsert);
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            return logDTO;

        }
        public static LoginDTO UpdateLogin(LoginDTO logDTO)
        {
            MotoDB1 db = DataProvider.dbContext;
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<LoginDTO, Login>();
                });
                MotoDB1 dbo = new MotoDB1();
                Login nvUpdate = Mapper.Map<LoginDTO, Login>(logDTO);
                dbo.Entry(nvUpdate).State = System.Data.Entity.EntityState.Modified;
                dbo.SaveChanges();
                dbo.Dispose();
            }
            catch (Exception ex)
            {
                return null;
            }
            return logDTO;
        }
        public static bool DeleteAccount (string username)
        {
            try
            {
                MotoDB1 dbo = new MotoDB1();
                Login em = dbo.Logins.SingleOrDefault(n => n.Username == username);
                if (em != null)
                {
                    dbo.Logins.Remove(em);
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
