using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listView2
{
    public partial class Form3 : Form
    {
        public delegate  void getData(int value, string option);
        public getData Sender;
        static int index = 0;
        static  string option = "";
        static public void getIndex(int value,string msg)
        {
            index = value;
            option = msg;
        }
        public Form3()
        {
            InitializeComponent();
            Sender = new getData(getIndex);
            setCBBLSH();
            rdMale.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //switch (option)
            //{
            //    case "add":
            //        if (!setFunc()) ;
            //        break;
            //    case "edit":
            //        if (!upDateSV()) ;
            //        break;
            //}
            setFunc();
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }
        public void setCBBLSH() 
        {
            DataTable dt =CSDL.Instance.DTLSH;
            foreach(DataRow dr in dt.Rows)
            {
                cblsh.Items.Add(dr["NameLop"]);
            }
            cblsh.SelectedIndex = 0;
        }
       
        private int getIDLSH()
        {
            int index = cblsh.SelectedIndex;
            CBBItems cbb = new CBBItems()
            {
                Text = cblsh.Items[index].ToString(),
                Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])

            };
            return cbb.Value;
            }
        //chayj hàm add => thêm dữ liệu vào dataTable
        private bool setFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV[0] = txtMSSV.Text;
            SV[1] = txtName.Text;
            if (rdMale.Checked) SV[2] = false;
            else SV[2] = true;
            SV[3] = getIDLSH();
            SV[4] = dateTimePicker1.Value;
            CSDL.Instance.setDataTable(SV);
            return true;
        }
        private void getFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            //giá trị index được truyền từ form1 
            SV = CSDL.Instance.getDataTable(SV, index);
            // hieenr thij lên màn hình 
            txtMSSV.Text = SV[0].ToString();
            txtName.Text = SV[1].ToString();
            if (Convert.ToBoolean(SV[2])) rdFe.Checked = true;
            else rdMale.Checked = true;
            //lay namelop thong qua cbbItems class
            CBBItems cb = new CBBItems()
            {
                Text = cblsh.Items[Convert.ToInt32(SV[3]) - 1].ToString()

        };
            dateTimePicker1.Value = Convert.ToDateTime(SV[4]);
            cblsh.SelectedItem = cb.Text;
        }
        //Sau khi edit xong cập nhật lại Form3 
       
        public bool upDateSV()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Rows.Count];
            SV[0] = txtMSSV.Text;
            SV[1] = txtName.Text;
            if (rdFe.Checked) SV[2] = true;
            else SV[2] = false;
            SV[3] = getIDLSH();
            SV[4] = dateTimePicker1.Value;
            CSDL.Instance.changeDTSV(SV, index);
            return true;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //load ra SV infor neeus bam nut edit
            if (option == "edit") getFunc();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }
    }
}
