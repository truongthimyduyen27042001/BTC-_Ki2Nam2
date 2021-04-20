using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSVMVC3Layer
{
    class SV
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public int ID_Lop { get; set; }
        public static bool CmpMSSV(SV s1, SV s2)
        {
            if (String.Compare(s1.MSSV,s2.MSSV)>0) return true;
            return false;

        }

        public static bool CmpName(SV s1, SV s2)
        {
            if (String.Compare(s1.NameSV, s2.NameSV) > 0) return true;
            return false;

        }

        public static bool CmpGender(SV s1, SV s2)
        {
            if (!s1.Gender && s2.Gender) return true;
            return false;

        }

        public static bool CmpNS(SV s1, SV s2)
        {

            if (String.Compare(s1.NS.ToString(), s2.NS.ToString()) > 0) return true;
            return false;

        }

        public static bool CmpID_Lop(SV s1, SV s2)
        {
            if (s1.ID_Lop > s2.ID_Lop) return true;
            return false;

        }
    }
}
