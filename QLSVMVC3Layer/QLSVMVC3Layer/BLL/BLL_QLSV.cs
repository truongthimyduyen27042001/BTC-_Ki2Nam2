using QLSVMVC3Layer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSVMVC3Layer.DTO;

namespace QLSVMVC3Layer.BLL
{
    class BLL_QLSV
    {
        private static BLL_QLSV _Instance;

        public static BLL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_QLSV();
                return _Instance;
            }
            private set { }
        }
        private BLL_QLSV()
        {

        }
        public List<SV> getListSV_BLL()
        {
            return DAL_QLSV.Instance.getListSV_DAL();
        }
        public void AddSVBLL(SV s)
        {
           // DAL.DAL_QLSV data = new DAL.DAL_QLSV();
            //data.AddSVDAL(s);
        }
        public List<LSH> getALLLSH_BLL()
        {
            return DAL_QLSV.Instance.getAllLSH_DAL();
        }
        public void updateSVByMSSV_BLL(SV s)
        {
            DAL_QLSV.Instance.updateSVByMSSV_DAL(s);
        }
        public List<SV> getSVByDemand_BLL(string name,int idlop)
        {
            return DAL_QLSV.Instance.getSVByDemand_DAL(name, idlop);
        }
        public SV getSVByMSSV(string mssv)
        {
            return DAL_QLSV.Instance.getSVByMSSV_DAL(mssv);   
        }
        public void addSV_BLL(SV s)
        {
             DAL_QLSV.Instance.addSV_DAL(s);
        }
        public void deleteSV_BLL(string ms)
        {
            DAL_QLSV.Instance.deleteSV_DAL(ms);
        }
        public List<CBBItems> getDemandSort_BLL()
        {
            return DAL_QLSV.Instance.getDemandSort_DAL();
        }
        public List<SV> getListSVByListMSSV_BLL(List<String> l)
        {
            return DAL_QLSV.Instance.getListSVByListMSSV_DAL(l);
        }
        public delegate  bool Compare(SV s1, SV s2);
        public List<SV> sortSVByDemand(List<SV> list,string demand)
        {
            Compare cmp;
            switch (demand)
            {
                case "MSSV":
                    {
                        cmp = SV.CmpMSSV;
                        break;
                    }
                case "NameSV":
                    {
                        cmp = SV.CmpName;
                        break;

                    }
                case "NS":
                    {
                        cmp = SV.CmpNS;
                        break;
                    }
                case "Gender":
                    {
                        cmp = SV.CmpGender;
                        break;

                    }
                case "ID_Lop": {
                        cmp = SV.CmpID_Lop;
                        break;
                    }
                default:
                    {
                        cmp = SV.CmpMSSV;
                        break;
                    }
            }
            SV s1 = list[0];
            SV s2 = list[1];
            for(int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(s1,s2))
                    {
                        SV temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        } 

    }
}
