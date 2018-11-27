using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CustomerDTO
    {
        public int CUSID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string IDCARD { get; set; }
        public string PHONENUMBER { get; set; }
        public string ADDRESSS { get; set; }
    }
}
