using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSV3
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
            //khai baso một datatable dãy SV
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[] {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int))
            });
            //khai báo 1 row cho datatable
            DataRow dr = DTSV.NewRow();
            dr["MSSV"] = "101";
            dr["Name"] = "Trương thị Mỹ Duyên";
            dr["Gender"] = false;
            dr["NS"] = DateTime.Now;
            dr["ID_Lop"] = 4;
            DTSV.Rows.Add(dr);
            //khai báo 1 row cho datatable
            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "102";
            dr2["Name"] = "Trân Thanh Hiền";
            dr2["Gender"] = false;
            dr2["NS"] = DateTime.Now;
            dr2["ID_Lop"] = 2;
            DTSV.Rows.Add(dr2);

            //khai báo 1 row cho datatable
            DataRow dr3 = DTSV.NewRow();
            dr3["MSSV"] = "103";
            dr3["Name"] = "Hoàng Thu Như";
            dr3["Gender"] = false;
            dr3["NS"] = DateTime.Now;
            dr3["ID_Lop"] = 2;
            DTSV.Rows.Add(dr3);

            //khai báo 1 row cho datatable
            DataRow dr4 = DTSV.NewRow();
            dr4["MSSV"] = "104";
            dr4["Name"] = "Lê Tuân";
            dr4["Gender"] = true;
            dr4["NS"] = DateTime.Now;
            dr4["ID_Lop"] = 4;
            DTSV.Rows.Add(dr4);

            //Khai báo thông tin các Row cho DTLSH
            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                  new DataColumn("ID_Lop",typeof(int)),
                  new DataColumn("NameLSH",typeof(string))
            });
            DataRow dr5 = DTLSH.NewRow();
            dr5["ID_Lop"] = 2;
            dr5["NameLSH"] = "19TCLC-DT2";
            DTLSH.Rows.Add(dr5);
            DataRow dr6 = DTLSH.NewRow();
            dr6["ID_Lop"] = 4;
            dr6["NameLSH"] = "19TCLC-DT4";
            DTLSH.Rows.Add(dr6);

        }
        public DataTable createDataSV(int id_lop)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int))
            });
            foreach (DataRow dr in DTSV.Rows)
            {
                if (Convert.ToInt32(dr["ID_Lop"].ToString()) == id_lop)
                {
                    dt.Rows.Add(dr.ItemArray);
                }
            }
            return dt;
        }
        public void setDataTable(object[] SV)
        {
            //DataRow dr = DTSV.NewRow();
            //dr.ItemArray = SV;
            //DTSV.Rows.Add(dr);
        }
        //phucj vuj cho hàm edit // truyền vào một thằng SV rỗng sau đó cho ra một thằng Sv đã được lấy 
        //dữ liệu từ Rows mình đã chọn từ griddata
        //public object[] getSV(object[] SV,string mssv)
        //{
        //    SV = DTSV.Rows["MSSV"].ItemArray;
        //    return SV;
        //}
        public int getRealIndex(string value)
        {
            int index = 0;
            foreach (DataRow dr in DTSV.Rows)
            {
                if (dr["MSSV"].ToString() == value)
                {
                    return index;

                }
                else
                {
                    index++;
                }
            }
            return index;
        }
        //Thay dôi dữ liệu sinh viên, truyền thằng SV đã được cập nhật dữ liệu mới và index
        //public void changeDTSV(object[] SV,int index)
        //{
        //    DTSV.Rows[index].ItemArray = SV;
        //}
        public void changeDTSV(object[] SV, int index)
        {
            DTSV.Rows[index].ItemArray = SV;
        }
        //public string getNameLop(int id)
        //{
        //    string namelop = "";
        //    foreach(DataRow dr in DTLSH.Rows)
        //    {
        //        if (Convert.ToInt32(dr["ID_Lop"].ToString()) == id)
        //        {
        //          namelop=dr["NameLSH"].ToString();
        //            break;
        //        }

        //    }
        //    return namelop;
        //}
        //public string getIDLop(string namelop)
        //{
        //    string id = "";
        //    foreach (DataRow dr in DTLSH.Rows)
        //    {
        //        if (String.Compare(dr["NameLSH"].ToString(), namelop, false) == 0)
        //        {
        //            id = dr["ID_Lop"].ToString();
        //            break;
        //        }
        //    }
        //    return id;
        //}
        public void deleteSV(string id)
        {
            DataTable dt = DTSV;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MSSV"].ToString() == id) dt.Rows.Remove(dt.Rows[i]);
            }
            DTSV = dt;

        }
        public void sortForDemand(string demand)

        {
            DataRow temp = DTSV.NewRow();
            for (int i = 0; i < DTSV.Rows.Count - 1; i++)
            {

                for (int j = i; j < DTSV.Rows.Count; j++)
                {

                    if (String.Compare(DTSV.Rows[i][demand].ToString(), DTSV.Rows[j][demand].ToString()) > 0)
                    {
                        temp.ItemArray = DTSV.Rows[i].ItemArray;
                        DTSV.Rows[i].ItemArray = DTSV.Rows[j].ItemArray;
                        DTSV.Rows[j].ItemArray = temp.ItemArray;

                    }
                }
            }
        }
        public void addSVtodata(object[] SV)
        {
            DataRow dr = DTSV.NewRow();
            dr.ItemArray = SV;

            DTSV.Rows.Add(dr);
        }
        //ham checkShow Sv theo lop
        public void selectSVforClass(int id_lop)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int))
            });
            foreach (DataRow dr in dt.Rows)
            {
                if (String.Compare((dr["ID_Lop"]).ToString(), id_lop.ToString()) == 0)
                {
                    dt.Rows.Add(dr);
                }
            }

        }
        //hàm lấy id_ lớp của thằng mình chọn từ cbbBox lớp sh
        public int getIDByClassName(string namelop)
        {
            foreach (DataRow dr in DTLSH.Rows)
            {
                if (String.Compare((dr["NameLSH"].ToString()), namelop) == 0) return Convert.ToInt32(dr["ID_Lop"].ToString());
            }
            return 0;
        }
        //sau khi có được thằng id lớp rồi , thì mình sẽ đi lấy csdl dtsv đi check, thằng nào có id lớp đó thì lấy
        public DataTable showSVForClassName(string namelop)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int))
            });
            foreach (DataRow dr in DTSV.Rows)
            {

                if (Convert.ToInt32(dr["ID_Lop"].ToString()) == getIDByClassName(namelop))
                {
                    dt.Rows.Add(dr.ItemArray);
                }
            }
            return dt;
        }
        //lam mot ham lay id sv 
        public int getIDClassByClassName(string namelop)
        {
            foreach (DataRow dr in DTLSH.Rows)
            {
                if (String.Compare(dr["NameLSH"].ToString(), namelop) == 0)
                {
                    return Convert.ToInt32(dr["ID_Lop"].ToString());
                }
            }
            return 0;
        }
        //mot ham add du lieu 
        public void addSV(object[] SV)
        {
            DataRow dr = DTSV.NewRow();
            dr.ItemArray = SV;
            DTSV.Rows.Add(dr);

        }
        //mot ham get Sv dua vao mssv 
        public object[] getSV(object[] SV, string mssv)
        {

            foreach (DataRow dr in DTSV.Rows)
            {
                if (String.Compare(dr["MSSV"].ToString(), mssv) == 0)
                {
                    SV = dr.ItemArray;
                    return SV;
                }
            }
            return SV;
        }
        public string getNameLop(int id_lop)
        {
            string namelop = "";
            foreach (DataRow dr in DTLSH.Rows)
            {
                if (Convert.ToInt32(dr["ID_Lop"].ToString()) == id_lop) return dr["NameLSH"].ToString();
            }
            return namelop;
        }
        public void updateSV(object[] SV, string mssv)
        {
            foreach (DataRow dr in DTSV.Rows)
            {
                if (String.Compare((dr["MSSV"].ToString()), mssv) == 0)
                {
                    dr.ItemArray = SV;
                    return;
                }
            }

        }
    }
}
