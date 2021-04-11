using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GK_102190160_TruongThiMyDuyen
{
    class CSDL
    {
        public DataTable DTCS { get; set; }
        public DataTable DTGV { get; set; }

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
            DTGV = new DataTable();
            DTGV.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID_GV",typeof(int)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("SDT",typeof(string)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_CS",typeof(string))
            });
            //khai báo 1 row cho datatable
            DataRow dr = DTGV.NewRow();
            dr["ID_GV"] = "101";
            dr["Name"] = "Trương thị Mỹ Duyên";
            dr["SDT"] = "0799634056";
            dr["NS"] = DateTime.Now;
            dr["ID_CS"] = "TO100";
            DTGV.Rows.Add(dr);
            //khai báo 1 row cho datatable
            DataRow dr2 = DTGV.NewRow();
            dr2["ID_GV"] = "102";
            dr2["Name"] = "Lê Hoàng Ngọc Hân";
            dr["SDT"] = "07236348876";
            dr2["NS"] = DateTime.Now;
            dr2["ID_CS"] = "TO101";
            DTGV.Rows.Add(dr2);

            //khai báo 1 row cho datatable
            DataRow dr3 = DTGV.NewRow();
            dr3["ID_GV"] = "103";
            dr3["Name"] = "Trần Thị Phượng";
            dr3["SDT"] = "012346789";
            dr3["NS"] = DateTime.Now;
            dr3["ID_CS"] = "TO101";
            DTGV.Rows.Add(dr3);

            //khai báo 1 row cho datatable
            DataRow dr4 = DTGV.NewRow();
            dr4["ID_GV"] = "104";
            dr4["Name"] = "Hồ Văn Vy";
            dr4["SDT"] = "012346789";
            dr4["NS"] = DateTime.Now;
            dr4["ID_CS"] = "TO102";
            DTGV.Rows.Add(dr4);

            DataRow dr5 = DTGV.NewRow();
            dr5["ID_GV"] = "105";
            dr5["Name"] = "Lê Tuân";
            dr5["SDT"] = "07805945015";
            dr5["NS"] = DateTime.Now;
            dr5["ID_CS"] = "TO101";
            DTGV.Rows.Add(dr5);

            //Khai báo thông tin các Row cho DTLSH
            DTCS = new DataTable();
            DTCS.Columns.AddRange(new DataColumn[]
            {
                  new DataColumn("ID_CS",typeof(string)),
                  new DataColumn("NameCS",typeof(string)),
                  new  DataColumn("SLGV",typeof(int))
            });
            
            DataRow dr6 = DTCS.NewRow();
            dr6["ID_CS"] = "TO100";
            dr6["NameCS"] = "Toán";
            dr6["SLGV"] = 5;
            DTCS.Rows.Add(dr6);
            DataRow dr7 = DTCS.NewRow();
            dr7["ID_CS"] = "TO101";
            dr7["NameCS"] = "Tin chuyên ngành";
            dr7["SLGV"] = 5;
            DTCS.Rows.Add(dr7);
            DataRow dr8 = DTCS.NewRow();
            dr8["ID_CS"] = "TO102";
            dr8["NameCS"] = "Hóa chuyên ngành";
            dr8["SLGV"] = 5;
            DTCS.Rows.Add(dr8);

        }
        //ham set du lieu CSDL tu CSDL_OOP
        public void setDataGV(List<GV> list)
        {
            DTGV.Clear();
            foreach(GV g in list)
            {
                DataRow dr = DTGV.NewRow();
                dr["ID_GV"] = g.ID_GV;
                dr["Name"] = g.NameGV;
                dr["SDT"] = g.SDT;
                dr["NS"] = g.NS;
                dr["ID_CS"] = g.ID_CS ;
                DTGV.Rows.Add(dr);
            }
        }
    }
}
