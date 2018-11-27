using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataProvider
    {
        private static MotoDB1 db;
        public static MotoDB1 dbContext
        {
            get
            {
                if (db == null)
                    db = new MotoDB1();
                return db;
            }
        }
    }
}
