using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BT3_QLSV3Layer
{
    class DAL_QLSV
    {
        private static DAL_QLSV _Instance;
        public static DAL_QLSV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLSV();
                   
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private DAL_QLSV()
        {

        }
       
        public SV getSVByRow(DataRow dr)
        {
            return new SV
            {
                MSSV = dr["MSSV"].ToString(),
                NameSV = dr["NameSV"].ToString(),
                Gender = Convert.ToBoolean(dr["Gender"].ToString()),
                NS = Convert.ToDateTime(dr["NS"].ToString()),
                ID_Lop=Convert.ToInt32(dr["ID_Lop"].ToString()),
             
            };
        }
        public List<SV> getListSV_DAL()
        {
            List<SV> list = new List<SV>();
            string querry = "select * from SV";
            foreach(DataRow dr in DBHelper.Instance.getRecords(querry).Rows)
            {
                list.Add(getSVByRow(dr));
            }
            return list;
        }

        public void addSV_DAL(SV s)
        {
            string querry = "insert into dbo.SV values('" + s.MSSV + "','" + s.NameSV + "','" + s.Gender + "','" + s.NS + "','" + s.ID_Lop + "')";
            DBHelper.Instance.ExecuteDB(querry);

        }

        //lay du lieu cua lop sinh hoat 
        public List<LopSH> getListLopSH_DAL()
        {
            List<LopSH> list = new List<LopSH>();
            string querry = "select * from LopSH";
            foreach(DataRow dr in DBHelper.Instance.getRecords(querry).Rows)
            {
                list.Add(new LopSH
                {
                    ID_Lop = Convert.ToInt32(dr["ID_Lop"].ToString()),
                    NameLop = dr["NameLop"].ToString()
                });
            }
            return list;
        }
        //Lấy được những sinh viên theo yêu cầu , truyền vào id lớp và name chỗ txtName từ GUI
        public List<SV> getListSVByDemand_DAL(string name,int idlop)
        {
            List<SV> list = new List<SV>();
            string querry = "select * from SV";
            foreach(DataRow dr in DBHelper.Instance.getRecords(querry).Rows)
            {
                if (idlop == 0)
                {
                    if (name != " ")
                    {
                        if (dr["NameSV"].ToString().Contains(name))
                        {
                            list.Add(getSVByRow(dr));
                        }
                    }
                    else
                    {
                        list.Add(getSVByRow(dr));
                    }
                }
                else
                {
                    if (name != "")
                    {
                        if (Convert.ToInt32(dr["ID_Lop"].ToString()) == idlop && dr["NameSV"].ToString().Contains(name))
                        {
                            list.Add(getSVByRow(dr));
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dr["ID_Lop"].ToString()) == idlop)
                        {
                            list.Add(getSVByRow(dr));
                        }
                    }
                }
            }
            return list;
        }

        //lam mot ham update SV 
        public void updateSV_DAL(SV s)
        { 
            string querry = "update dbo.SV set NameSV = '" + s.NameSV + "',Gender='" + s.Gender + "',NS='" + s.NS + "',ID_Lop='" + s.ID_Lop + "' where MSSV='" + s.MSSV + "'";
            DBHelper.Instance.ExecuteDB(querry);
        }
        
       //lam mot ham xoa 
       public void deleteSV_DAL(string ms)
        {
            string querry = "delete from dbo.SV where MSSV= " + ms;
            DBHelper.Instance.ExecuteDB(querry);
        }
        
        //lay nhung du lieu de do ra cbbSort 
        public List<CBBItems> getCBBSortDemand()
        {
            List<CBBItems> list = new List<CBBItems>();
            string querry = "select * from dbo.SV";
            int val = 1;
            foreach(DataColumn dc in DBHelper.Instance.getRecords(querry).Columns)
            {
                list.Add(new CBBItems
                {
                    Value = val,
                    Text=dc.ColumnName
                }) ;
                val++;
            }
            return list;
        }

        //Lamf mojt ham getMSSV dua vao vi tri lua chon tu datagrid 
        public string getMSSVByIndex_DAL(int index)
        {
            List<SV> list = DAL_QLSV.Instance.getListSV_DAL();
            return list[index].MSSV;
        }
    }
}
