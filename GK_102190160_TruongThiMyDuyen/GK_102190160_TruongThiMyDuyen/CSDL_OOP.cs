using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GK_102190160_TruongThiMyDuyen
{
    class CSDL_OOP
    {
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();

                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static CSDL_OOP _Instance;
        //Làm một list SV đổ dữ liệu từ bên CSDL.DTGV qua bên List GV và trả về list GV
        public List<GV> getDataGV()
        {
            List<GV> dataGV = new List<GV>();
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                GV g = new GV();
                g.ID_GV = Convert.ToInt32(dr["ID_GV"].ToString());
                g.NameGV = dr["Name"].ToString();
                g.SDT = dr["SDT"].ToString();
                g.NS = Convert.ToDateTime(dr["NS"].ToString());
                g.ID_CS = dr["ID_CS"].ToString();
                dataGV.Add(g);
            }
            return dataGV;
        }
        public string getIDCSByCSName(string namecs)
        {

            foreach (DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                if (dr["NameCS"].ToString()==namecs) return dr["ID_CS"].ToString();

            }
            return "";

        }
        //ham add mot sv bang mot datarow 
        public GV getSV(DataRow dr)
        {
            GV g = new GV();
            g.ID_GV = Convert.ToInt32(dr["ID_GV"]);
            g.NameGV = dr["Name"].ToString();
            g.SDT = dr["SDT"].ToString();
            g.NS = Convert.ToDateTime(dr["NS"]);
            g.ID_CS = dr["ID_CS"].ToString();
            return g;
        }
        //ham show theo yeu cau 
        public List<GV> getGVByCSName(string namecs)
        {
            List<GV> list = new List<GV>();
            string idcs = getIDCSByCSName(namecs);
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if (idcs ==dr["ID_CS"].ToString()) list.Add(getSV(dr));
            }
            return list;
        }
        //lay danh sach sinh vien theo id cs 
        public List<GV> getSVByIDCS(string idcs)
        {
            List<GV> list = new List<GV>();
            foreach(DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if (dr["ID_CS"].ToString() == idcs) list.Add(getSV(dr));
            }
            return list;
        }
        public List<GV> searchSVByDemand(string idcs, string name)
        {
            List<GV> list = new List<GV>();
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if (idcs == "" && name == "")
                {
                    list.Add(getSV(dr));
                }
                else
                {
                    if (idcs != "" && name == "")
                    {
                        return getSVByIDCS(idcs);
                    }
                    else
                    {
                        if (idcs == "" && name != "")
                        {
                            if (dr["Name"].ToString().Contains(name)) list.Add(getSV(dr));
                        }
                        else
                        {
                            if (dr["ID_CS"].ToString() == idcs && dr["Name"].ToString().Contains(name)) list.Add(getSV(dr));
                        }
                    }
                }
            }
            return list;
        }
        //ham phuc vu ham add 
        public void addGV(GV g)
        {
            List<GV> list = CSDL_OOP.Instance.getDataGV();
            list.Add(g);
            CSDL.Instance.setDataGV(list);
            
        }

        //lay du lieu cua thang GV tu msgv minh da chon 
        public GV getInforGV(int msgv)
        {
            GV g = new GV();
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if (Convert.ToInt32(dr["ID_GV"].ToString() )== msgv)
                {
                    g.ID_GV = Convert.ToInt32(dr["ID_GV"].ToString());
                    g.NameGV = dr["Name"].ToString();
                    g.SDT = dr["SDT"].ToString();
                    g.NS = Convert.ToDateTime(dr["NS"].ToString());
                    g.ID_CS = dr["ID_CS"].ToString();

                    return g;
                }
            }
            return g;
        }
        
        public string getNameCSByIDCS(string idcs)
        {
            foreach(DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                if (dr["ID_CS"].ToString() == idcs) return dr["NameCS"].ToString();
            }
            return "";
        }
        //ham updateSV
        public void updateDTSV(int mssv, GV g)
        {
            List<GV> list = getDataGV();
            int index = 0;
            foreach (GV temp in list)
            {
                if (list[index].ID_GV == mssv)
                {
                    list[index] = g;
                    break;
                }
            }
            CSDL.Instance.setDataGV(list);
        }
        //ham delete co du lieu truyen vao ma mot magv
        public void deleteGV(int magv)
        {
            List<GV> list = getDataGV();

            foreach (GV temp in list)
            {

                if (temp.ID_GV == magv)
                {
                    list.Remove(temp);
                    break;
                }
            }
            CSDL.Instance.setDataGV(list);
        }
    }
}
