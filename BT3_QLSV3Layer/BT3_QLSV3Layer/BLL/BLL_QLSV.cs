using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3_QLSV3Layer
{
    class BLL_QLSV
    {
        private static BLL_QLSV _Instance;
        public static BLL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        //get list Sv 
        public List<SV> getListSV_BLL()
        {
            return DAL_QLSV.Instance.getListSV_DAL();
        }
        //Lasy list LopSH
        public List<LopSH> getListLopSH_BLL()
        {
            return DAL_QLSV.Instance.getListLopSH_DAL();
        }

        //lay sinh vien theo demand
        public List<SV> getSVByDemand_BLL(string name,int idlop)
        {
            return DAL_QLSV.Instance.getListSVByDemand_DAL(name, idlop);
        }
        //Làm một hàm để check MSSV chỗ hàm add trước khi đưa vào inset
        public bool checkMSSV(SV s)
        {
            List<SV> list = DAL_QLSV.Instance.getListSV_DAL();
            foreach(var i in list)
            {
                if (s.MSSV == i.MSSV) return false;
            }
            return true;
        }
        //ham add Sv 

        public void addSV_BLL(SV s)
        {
             
              DAL_QLSV.Instance.addSV_DAL(s);
        }

        public void updateSV_BLL(SV s)
        {
            DAL_QLSV.Instance.updateSV_DAL(s);
        }
        public void deleteSV_BLL(string ms)
        {
            DAL_QLSV.Instance.deleteSV_DAL(ms);
        }
        public List<CBBItems> getCBBSortDemand()
        {
            return DAL_QLSV.Instance.getCBBSortDemand();
        }
        //Thuwjc hien ham sort 
        public  delegate bool Compare(SV s1, SV s2);
        public List<SVView> SortListSVByDemand(string demand)
        {
            List<SV> list =getListSV_BLL();
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
                        cmp = SV.CmpNameSV;
                        break;
                    }
                case "Gender":
                    {
                        cmp = SV.CmpGender;
                        break;
                    }
                case "NS":
                    {
                        cmp = SV.CmpNS;
                        break;
                    }
                case "ID_Lop":
                    {
                        cmp = SV.CmpID_Lop;
                        break;
                    }
                default:
                    {
                        cmp = SV.CmpMSSV;
                        break;
                    }
            }
      
            for (int i = 0; i < list.Count - 1; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(list[i],list[j]))
                    {
                        SV temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return getListSVView_BLL(list);
        }
        //Làm một hàm để đổi từ idlop sang namelop
        public CBBItems namelop(int id)
        {
            CBBItems lsh = new CBBItems();
            foreach (var i in DAL_QLSV.Instance.getListLopSH_DAL())
            {
                if (i.ID_Lop == id)
                {
                    lsh.Value = i.ID_Lop;
                    lsh.Text = i.NameLop;
                }
            }
            return lsh;

        }

        //Hàm thay đổi giao diện 
        public List<SVView> getListSVView_BLL(List<SV> list)
        {
            
            List<SVView> listView = new List<SVView>();
            foreach(var i in list)
            {
                listView.Add(new SVView
                {
                    NameSV = i.NameSV,
                    Gender = i.Gender,
                    NS = i.NS,
                    NameLop = namelop(i.ID_Lop).Text
                }) ;
            }
            return listView;

        }
        //lay mssv dua vao index
        public string getMSSVByIndex_BLL(int index)
        {
            return DAL_QLSV.Instance.getMSSVByIndex_DAL(index);
        }
       
    }
}
