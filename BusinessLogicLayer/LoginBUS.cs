using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class LoginBUS
    {
        LoginDAL objEM = new LoginDAL();
        public bool Check(string username,string password)
        {
            return objEM.KTDangNhap(username,password);
        }
        public static List<LoginDTO> LoadLogin()
        {
            return LoginDAL.LoadLogin();
        }
        public static LoginDTO AddLogin(LoginDTO logDTO)
        {
            return LoginDAL.AddLogin(logDTO);
        }
        public static LoginDTO UpdateLogin(LoginDTO logDTO)
        {
            return LoginDAL.UpdateLogin(logDTO);
        }
        public static bool DeleteAccount(string username)
        {
            return LoginDAL.DeleteAccount(username);
        }
    }
}
