using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLSVMVC3Layer.DTO;
namespace QLSVMVC3Layer.DAL
{
    class DAL_QLSV
    {
        private static DAL_QLSV _Instance;

        public static DAL_QLSV Instance 
        { 
            get
            {
                if (_Instance == null)
                    _Instance = new DAL_QLSV();
                return _Instance;
            }
            private set { } 
        }
        private DAL_QLSV()
        {

        }
        public List<SV> getListSV_DAL()
        {
            List<SV> data = new List<SV>();
            string query = "select * from SV";
            foreach (DataRow dr in DBHelper.Instance.getRecords(query).Rows)
            {
                data.Add(getSV(dr));
            }
            return data;
        }
        public SV getSV(DataRow dr)
        {
            return new SV
            {
                MSSV = dr["MSSV"].ToString(),
                NameSV = dr["NameSV"].ToString(),
                Gender = Convert.ToBoolean(dr["Gender"].ToString()),
                NS = Convert.ToDateTime(dr["NS"].ToString()),
                ID_Lop = Convert.ToInt32(dr["ID_Lop"].ToString())
            };
        
        }
        public void AddSVDAL(SV s)
        {
            string querry="select * from SV where MSSV='101'";
            DBHelper.Instance.ExecuteDB(querry);
        }
        public List<LSH> getAllLSH_DAL()
        {
            List<LSH> list = new List<LSH>();
            string query = "select * from LSH";
            foreach(DataRow dr in DBHelper.Instance.getRecords(query).Rows)
            {
                LSH lsh = new LSH();
                lsh.ID_Lop = Convert.ToInt32(dr["ID_Lop"]);
                lsh.NameLop = dr["NameLop"].ToString();
                list.Add(lsh);
            }
            return list;
        }
        public void addSV_DAL(SV s)
        {
            string query = "insert into SV values ('";
            query += s.MSSV + "', '" + s.NameSV + "', '" + s.Gender + "', '"
                + s.NS + "', '" + s.ID_Lop + "');";
            DBHelper.Instance.ExecuteDB(query);

        }
        public void updateSVByMSSV_DAL(SV s)
        {
            string querry = "update SV set MSSV = '" + s.MSSV + "', NameSV = '" + s.NameSV
                + "', Gender = '" + s.Gender + "', NS = '" + s.NS + "', ID_Lop = '" + s.ID_Lop
                + "' where MSSV = '" + s.MSSV + "'";
            DBHelper.Instance.ExecuteDB(querry);
        }
        public List<SV> getSVByDemand_DAL(string name,int idlop)
        {
            string querry = "select * from SV";
            List<SV> list = new List<SV>();
            foreach(DataRow dr in DBHelper.Instance.getRecords(querry).Rows)
            {
                if (idlop == 0)
                {
                    if(name!="")
                    {
                        if (dr["NameSV"].ToString().Contains(name)) list.Add(getSVByRow(dr));
                    }
                    else
                    {
                        list.Add(getSVByRow(dr));
                    }
                }
                else
                {
                    if(name!="")
                    {
                       if(idlop==Convert.ToInt32(dr["ID_Lop"])&& dr["NameSV"].ToString().Contains(name)) list.Add(getSVByRow(dr));
                    }
                    else
                    {
                        if (idlop == Convert.ToInt32(dr["ID_Lop"])) list.Add(getSVByRow(dr));
                    }
                }
            }
            return list;
        }
       
        public SV getSVByRow(DataRow dr)
        {
            return new SV
            {
                MSSV=dr["MSSV"].ToString(),
                NameSV=dr["NameSV"].ToString(),
                Gender=Convert.ToBoolean(dr["Gender"]),
                NS=Convert.ToDateTime(dr["NS"]),
                ID_Lop=Convert.ToInt32(dr["ID_lop"])
            };
        }
        public SV getSVByMSSV_DAL(string mssv)
        {
            string querry = "select * from SV where MSSV =  "+ mssv;
            return getSVByRow(DBHelper.Instance.getRecords(querry).Rows[0]);

        }
        public void deleteSV_DAL(string ms)
        {
            string query = "delete from SV where MSSV = " + ms;
            DBHelper.Instance.ExecuteDB(query);
        }
        public List<CBBItems> getDemandSort_DAL()
        {
            List<CBBItems> list = new List<CBBItems>();
            string query = "select * from SV";
            int value = 1;
            foreach (DataColumn dc in DBHelper.Instance.getRecords(query).Columns)
            {
                list.Add(new CBBItems()
                {
                    Text = dc.ColumnName,
                    Value = value
                });
                value++;
            }
            return list;
        }
        //Thực hiện phương pháp select 
        public delegate bool Compare(object a, object b);
       public List<SV> getListSVByListMSSV_DAL(List<String> listMSSV)
        {
            List<SV> list = new List<SV>();
            string querry = "select * from SV where MSSV = ";
            foreach(var i in listMSSV)
            {
                list.Add(getSVByRow(DBHelper.Instance.getRecords(querry + i).Rows[0]));
            }
            return list;
        }

    }
}
