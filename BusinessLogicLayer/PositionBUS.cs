using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PositionBUS
    {
        public static List<POSITION>LoadPosition()
        {
            return PositionDAL.LoadPosition();
        }
    }
}
 