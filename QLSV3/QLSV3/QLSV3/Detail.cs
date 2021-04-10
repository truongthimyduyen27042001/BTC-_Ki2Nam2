using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV3
{
    public partial class Form2 : Form
    {
        public delegate void getData(string index, string option);
        static string mssv = "";
        static string option = "";
        public  getData Sender;
        private static void getIndex(string value,string msg)
        {
            mssv = value;
            option = msg;
        }
        public Form2()
        {
            Sender = new getData(getIndex);
            InitializeComponent();
            getCbbLSH();
            rdFemale.Checked = true;
            //setFunc();
        }
        public void getCbbLSH()
        {
            DataTable r = new DataTable();
            r = CSDL.Instance.DTLSH;
            for (int i = 0; i < r.Rows.Count; i++)
            {
                cbbLSH.Items.Add(r.Rows[i]["NameLSH"]);
            }
        }
        //test 
      
        private void btnOK_Click(object sender, EventArgs e)
        {
            //switch (option)
            //{
            //    case "add":
            //        if (!setFunc()) ;
            //        break;
            //    case "edit":
            //        if (!updateSV()) ;
            //        break;
            //}
           
        }
        //Laays id lớp thông qua namelop
        public int getId_Lop()
        {
            int index = cbbLSH.SelectedIndex;
            CBBItems cbb = new CBBItems
            {
                Text =cbbLSH.Items[index].ToString(),
                Value=Convert.ToInt32(CSDL.Instance.DTSV.Rows[index]["ID_Lop"])
            };
            return cbb.Value;
        }

        //private bool setFunc()
        //{
        //    //object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
        //    //SV[0] = txtID.Text;
        //    //SV[1] = txtName.Text;
        //    //if (rdMale.Checked) SV[2] = false;
        //    //else SV[2] = true;
        //    //SV[4] = getIDLSH();
        //    //SV[3] = dateTimePicker1.Value;
        //    //CSDL.Instance.setDataTable(SV);
        //    //return true;
        //}
        //public bool getFun()
        //{
        //    //object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
        //    ////giá trị index được truyền từ form1 
        //    //SV = CSDL.Instance.getSV(SV, mssv);
        //    //// hieenr thij lên màn hình 
        //    //txtID.Text = SV[0].ToString();
        //    //txtName.Text = SV[1].ToString();
        //    //if (Convert.ToBoolean(SV[2])) rdFemale.Checked = true;
        //    //else rdMale.Checked = true;
        //    ////lay namelop thong qua cbbItems class

        //    //dateTimePicker1.Value = Convert.ToDateTime(SV[3]);
        //    ////Phải lấy được cbb name lớp
        //    //CBBItems cbb = new CBBItems()
        //    //{
        //    //    Text = CSDL.Instance.getNameLop(Convert.ToInt32(SV[4].ToString()))
        //    //};
        //    //cbbLSH.SelectedItem = cbb.Text;
            
        //    return true;
        //}
        //private int getIDLSH()
        //{
        //    //int index = cbbLSH.SelectedIndex;
        //    //CBBItems cbb = new CBBItems
        //    //{
        //    //    Text = cbbLSH.Items[index].ToString(),
        //    //    Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
        //    //};
        //    //return cbb.Value;
          
           
        //    //foreach (DataRow dr in CSDL.Instance.DTLSH.Rows)
        //    //{
        //    //    if (String.Compare((dr["NameLSH"].ToString()), cbbLSH.SelectedItem.ToString()) == 0) return Convert.ToInt32(dr["ID_Lop"].ToString());
        //    //}
        //    return 0;
        //}
        //public bool updateSV()
        //{
        //    //object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
        //    //SV[0] = txtID.Text;
        //    //SV[1] = txtName.Text;
        //    //if (rdFemale.Checked) SV[2] = false;
        //    //else SV[2] = false;
        //    //SV[3] = dateTimePicker1.Value;
        //    //SV[4] = getIDLSH();
        //    //CSDL.Instance.changeDTSV(SV, mssv);
        //    //return true;
        //}

        //private void Form2_Load(object sender, EventArgs e)
        //{
        //    if (option == "edit") getFun();
        //}



        //Tự làm lại bài code Add and Edit

        //Tự làm lại hàm Add
        public bool setFunc()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV[0] = txtID.Text;
            SV[1] = txtName.Text;
            if (rdFemale.Checked) SV[2] = false;
            else SV[2] = true;
            SV[3] = Convert.ToDateTime(dateTimePicker1.Value);
            SV[4] = CSDL.Instance.getIDByClassName(cbbLSH.Text);
            CSDL.Instance.addSV(SV);
            return true;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("AAA");
            //setFunc();
            //editSV();
            if (!setFun()) setFun();
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
        //Tự làm lại hàm edit SV
        //public bool editSV()
        //{
        //    //Làm một hàm get dữ liệu từ bên kia bên row mình đã chọn qua bên này 

        //    //mình cập nhật lại thằng SV thông qua những gì mình đã nhập lại mới?
        //    object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
        //    SV[0] = txtID.Text;
        //    SV[1] = txtName.Text;
        //    if (rdFemale.Checked) SV[2] = false;
        //    else SV[2] = false;
        //    SV[3] = dateTimePicker1.Value;
        //    SV[4] = CSDL.Instance.getIDClassByClassName(cbbLSH.Text);
        //    CSDL.Instance.changeDTSV(SV, mssv);
        //    return true;
            
        //}
        // làm một hàm để lấy những dữ liệu của thằng dataSv từ bên form1 qua bên form 2    
        //qua been thawngf SV mình biết trước mssv của nó sau đó dùng mssv sinh viên đó trả về lại sv 
        //làm hàm getFun() lấy SV bên CSDL vừa trả về sau đó gán từng phần tử của nó với mỗi cái column tương ứng
           public void getDataSV()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV = CSDL.Instance.getSV(SV,mssv);
            txtID.Text = SV[0].ToString();
            txtName.Text = SV[1].ToString();
            if (Convert.ToBoolean(SV[2].ToString()) == false) rdFemale.Checked = true;
            else rdMale.Checked = true;
            dateTimePicker1.Value = Convert.ToDateTime(SV[3].ToString());
            //mot ham lay name lop thong qua id lop
            cbbLSH.SelectedItem = CSDL.Instance.getNameLop(Convert.ToInt32(SV[4].ToString()));


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (option == "edit") getDataSV();
        }
        //lamf mootj ham cap nhat lai du lieu 
        public bool setFun()
        {
            object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];
            SV[0] = txtID.Text;
            SV[1] = txtName.Text;
            if (rdFemale.Checked) SV[2] = false;
            else SV[2] = true;
            SV[3] = dateTimePicker1.Value;
            SV[4] = CSDL.Instance.getIDByClassName(cbbLSH.Text);
            MessageBox.Show(SV[0]+","+SV[1]+","+SV[2]+","+SV[3]+","+SV[4]+"\n");
            CSDL.Instance.updateSV(SV, mssv);
            return true; 

        }
    }
}
