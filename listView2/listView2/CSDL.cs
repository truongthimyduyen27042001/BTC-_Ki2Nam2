using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace listView2
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static CSDL _Instance;
        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV",typeof(string)),
                  new DataColumn("Name",typeof(string)),
                    new DataColumn("Gender",typeof(bool)),
                      new DataColumn("ID_Lop",typeof(int)),
                       new DataColumn("NS",typeof(DateTime)),
            });
            DataRow dr = DTSV.NewRow();
            dr["MSSV"] = "101";
            dr["Name"] = "NVA";
            dr["Gender"] = true;
            dr["ID_Lop"] = 1;
            dr["NS"] = DateTime.Now;
            DTSV.Rows.Add(dr);


            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "102";
            dr1["Name"] = "NVB";
            dr1["Gender"] = false;
            dr1["ID_Lop"] = 2;
            dr1["NS"] = DateTime.Now;
            DTSV.Rows.Add(dr1);

            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "103";
            dr2["Name"] = "NVC";
            dr2["Gender"] = true;
            dr2["ID_Lop"] = 1;
            dr2["NS"] = DateTime.Now;
            DTSV.Rows.Add(dr2);

            DataRow dr4 = DTSV.NewRow();
            dr4["MSSV"] = "104";
            dr4["Name"] = "NVD";
            dr4["Gender"] = true;
            dr4["ID_Lop"] = 2;
            dr4["NS"] = DateTime.Now;
            DTSV.Rows.Add(dr4);

            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("NameLop",typeof(string))
            });
            DataRow dr5 = DTLSH.NewRow();
            dr5["ID_Lop"] = 1;
            dr5["NameLop"] = "19TCLC-DT2";
            DTLSH.Rows.Add(dr5);
            DataRow dr6 = DTLSH.NewRow();
            dr6["ID_Lop"] = 2;
            dr6["NameLop"] = "19TCLC-DT4";
            DTLSH.Rows.Add(dr6);
        }
        

            public DataTable createDataTable(string value)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("Name"),
                new DataColumn("Gender",typeof(bool)),            
                new DataColumn("ID_Lop",typeof(int)),
                 new DataColumn("NS",typeof(DateTime)),

            });
            foreach(DataRow dr in DTSV.Rows)
            {
                if (dr["ID_Lop"].ToString() == value||dr["Name"].ToString().Contains(value)||dr["MSSV"].ToString().Contains(value)) dt.Rows.Add(dr.ItemArray);
            }
            return dt;
        }
        public void setDataTable(object[] SV)
        {
            DataRow dr = DTSV.NewRow();
            dr.ItemArray = SV;
            DTSV.Rows.Add(dr);
        }
        public object[] getDataTable(object[] SV,int index)
        {
            SV = DTSV.Rows[index].ItemArray;
            return SV;
        }
        public int getRealIndex(string value)
        {
            int index = 0;
            foreach(DataRow dr in DTSV.Rows)
            {
                if (dr["MSSV"].ToString() == value) return index;
                index++;
            }
            return index;
        }
        public void changeDTSV(object[] SV,int index)
        {
            DTSV.Rows[index].ItemArray = SV;
        }
        public void delegeDTSV(int index)
        {
            DTSV.Rows.Remove(DTSV.Rows[index]);
        }
        //Tạo ra một hàm DataTable Clone 
        public DataTable DTSVClone(DataTable temp)
        {
            temp.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("Name"),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("NS",typeof(DateTime))
            });
            foreach(DataRow dr in DTSV.Rows)
            {
                temp.Rows.Add(dr.ItemArray);
            }
            return temp;
        }
        public DataTable sortDataTable(DataTable temp,string value)
        {

            switch (value)
            {
                case "MSSV":
                    {

                        for (int i = 0; i < temp.Rows.Count - 1; i++)
                        {
                            for (int j = i + 1; j < temp.Rows.Count; j++)
                            {
                                if (Convert.ToInt32(temp.Rows[i]["MSSV"].ToString()) < Convert.ToInt32(temp.Rows[j]["MSSV"].ToString()))
                                {
                                    Object[] t = temp.Rows[i].ItemArray;
                                    temp.Rows[i].ItemArray = temp.Rows[j].ItemArray;
                                    temp.Rows[j].ItemArray = t;

                                }
                            }
                        }
                        break;
                    }
                case "Name":
                    {
                        for (int i = 0; i < temp.Rows.Count - 1; i++)
                        {
                            for (int j = i + 1; j < temp.Rows.Count; j++)
                            {
                                if (String.Compare(temp.Rows[i]["MSSV"].ToString(), temp.Rows[i]["MSSV"].ToString(), false) < 0)
                                {
                                    Object[] t = temp.Rows[i].ItemArray;
                                    temp.Rows[i].ItemArray = temp.Rows[j].ItemArray;
                                    temp.Rows[j].ItemArray = t;

                                }
                            }
                        }
                        break;
                    }

            }
            return temp;
        }
        //Làm một hàm xóa sinh viên
        public void DelSV(string id)
        {
            DataTable dt = DTSV;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (String.Compare(dt.Rows[i]["MSSV"].ToString(), id) == 0) dt.Rows.Remove(dt.Rows[i]);
            }
            DTSV = dt;
        }
        public void sortForDemand(string demand)
        {
            DataRow dr = DTSV.NewRow();
            string a = "";
            string b = "";
            for(int i = 0; i < DTSV.Rows.Count-1; i++)
            {
                for(int j = i + 1; j < DTSV.Rows.Count; j++)
                {
                    if (String.Compare(DTSV.Rows[i][demand].ToString(), DTSV.Rows[j][demand].ToString())>0)
                    {
                        dr.ItemArray = DTSV.Rows[i].ItemArray;
                        DTSV.Rows[i].ItemArray = DTSV.Rows[j].ItemArray;
                        DTSV.Rows[j].ItemArray = dr.ItemArray;

                    }
                }
            }
        }
        }

    }

