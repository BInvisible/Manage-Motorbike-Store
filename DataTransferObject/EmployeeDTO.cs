using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject;

namespace DataTransferObject
{
    public class EmployeeDTO
    {
        public int EID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string PHONENUMBER { get; set; }
        public string ADDDRESSS { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public byte[] PICTURE { get; set; }
        public string IDCARD { get; set; }
        public Nullable<int> DEGREEID { get; set; }
        public Nullable<int> POSITIONID { get; set; }
        public Nullable<int> DEPARTMENTID { get; set; }
        public Nullable<int> INSURANCEID { get; set; }
        public string DEGREENAME { get; set; }
        public string POSITIONNAME { get; set; }
        public string DEPARTMENTNAME { get; set; }
    }
}
