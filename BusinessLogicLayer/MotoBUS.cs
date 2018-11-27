using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObject;

namespace BusinessLogicLayer
{
    public class MotoBUS
    {
        public static List<MotorbikeDTO> LoadMOTORBIKE()
        {
            return MotoDAL.LoadMOTORBIKE();
        }
        public static MotorbikeDTO AddMOTORBIKE(MotorbikeDTO nvDTO)
        {
            return MotoDAL.AddMOTORBIKE(nvDTO);
        }
        public static MotorbikeDTO UpdateMOTORBIKE(MotorbikeDTO nvDTO)
        {
            return MotoDAL.UpdateMOTORBIKE(nvDTO);
        }
        public static bool DeleteMOTORBIKE(int EID)
        {
            return MotoDAL.DeleteMOTORBIKE(EID);
        }
        public static MotorbikeDTO Load(MotorbikeDTO motoDTO)
        {
            return MotoDAL.Load(motoDTO);
        }
    }
}
