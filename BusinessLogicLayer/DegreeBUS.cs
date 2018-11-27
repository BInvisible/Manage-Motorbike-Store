using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DegreeBUS
    {
        public static List<DEGREE> LoadDegree()
        {
            return DegreeDAL.LoadDegree();
        }
    }
}
