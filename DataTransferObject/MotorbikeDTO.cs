using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class MotorbikeDTO
    {
        public int MOTOID { get; set; }
        public string MOTONAME { get; set; }
        public byte[] PICTURE { get; set; }
        public string PRODUCER { get; set; }
        public Nullable<int> CAPACITY { get; set; }
        public string COLOR { get; set; }
        public Nullable<double> PRICE { get; set; }
    }
}
