using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class OrderDTO
    {
        public int BID { get; set; }
        public Nullable<int> CUSID { get; set; }
        public Nullable<int> MOTOID { get; set; }
        public Nullable<System.DateTime> DATEBUY { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public Nullable<double> TOTALMONEY { get; set; }

        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string MOTONAME { get; set; }
        public Nullable<double> PRICE { get; set; }
    }
}
