using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3_QLSV3Layer
{
    class SV
    {
        public String MSSV { get; set; }
        public String NameSV { get; set; }
        public Boolean Gender { get; set; }
        public DateTime NS { get; set; }
        public int ID_Lop { get; set; }
        

        //Làm các hàm so sánh 
        public static Boolean CmpMSSV(SV s1,SV s2)
        {
            return (String.Compare(s1.MSSV, s2.MSSV) > 0) ? true: false;
        }
        public static  Boolean CmpNameSV(SV s1, SV s2)
        {
            return (String.Compare(s1.NameSV, s2.NameSV) > 0) ? true : false;
        }
        public static Boolean CmpGender(SV s1,SV s2)
        {
            return (String.Compare(Convert.ToString(s1.Gender), Convert.ToString(s2.Gender)) > 0) ? true : false;
        }
        public static Boolean CmpNS(SV s1, SV s2)
        {
            return (String.Compare(Convert.ToString(s1.NS), Convert.ToString(s2.NS)) > 0) ? true : false;
        }
        public static Boolean CmpID_Lop(SV s1,SV s2)
        {
            return (s1.ID_Lop > s2.ID_Lop) ? true : false;
        }


    }
}
