using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3_QLSV3Layer
{
    public partial class Form2 : Form
    {


        public delegate void MyDelegate(string mssv);
        public static string MSSV = "";
        public MyDelegate Sender;
        public delegate void RefreshData();
        public RefreshData refresh;
        public void getMSSV(string ms)
        {
            MSSV = ms;
        }
        public Form2()
        {
            InitializeComponent();
            Sender = new MyDelegate(getMSSV);
            rdFemale.Checked = true;
            setCBBLopSH();

        }
        public void setCBBLopSH()
        {
            List<LopSH> list = BLL_QLSV.Instance.getListLopSH_BLL();

            foreach (var i in list)
            {
                cbbLSH.Items.Add(new CBBItems
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
            cbbLSH.SelectedIndex = 0;
        }
        // mot ham lay du lieu cua sinh vien de add
        private SV getInforSV_GUI()
        {
            SV s = new SV();
            s.MSSV = txtMSSV.Text;
            s.NameSV = txtName.Text;
            if (rdFemale.Checked) s.Gender = false;
            else s.Gender = true;
            s.NS = dateTimePicker1.Value;
            s.ID_Lop = ((CBBItems)cbbLSH.SelectedItem).Value;
            return s;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MSSV == "")
            {
                if (BLL_QLSV.Instance.checkMSSV(getInforSV_GUI()) == false) MessageBox.Show("Đã tồn tại mã số sinh viên đó!", "Error");
                else 
                BLL_QLSV.Instance.addSV_BLL(getInforSV_GUI());
            }
            else
            {

                BLL_QLSV.Instance.updateSV_BLL(getInforSV_GUI());
            }
            refresh();
            this.Dispose();
        }

        public void loadDataSVToEdit()
        {

            List<SV> list = BLL_QLSV.Instance.getListSV_BLL();
            SV s = new SV();
            foreach (var i in list)
            {
                if (MSSV == i.MSSV)
                {
                    s = i;
                    break;
                }

            }
            txtMSSV.Text = s.MSSV;
            txtName.Text = s.NameSV;
            if (s.Gender == true) rdMale.Checked = true;
            else rdFemale.Checked = true;
            dateTimePicker1.Value = s.NS;
            foreach (var i in BLL_QLSV.Instance.getListLopSH_BLL())
            {
                if (s.ID_Lop == i.ID_Lop)
                {
                    cbbLSH.SelectedItem = i;
                    break;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (MSSV != "")
            {
                loadDataSVToEdit();
                txtMSSV.Enabled = false;
            }
        }
    }
}
