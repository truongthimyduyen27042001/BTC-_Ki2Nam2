using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSVMVC3Layer.BLL;
using QLSVMVC3Layer.DTO;
using QLSVMVC3Layer.DAL;


namespace QLSVMVC3Layer
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(string mssv);
        public delegate void refreshGrid();
        public MyDel Sender;
        public refreshGrid refresh;
        string mssv = "";
        private void getMSSV(string ms)
        {
            mssv = ms;
        }
        private void refreshData()
        {

        }
        public Form2()
        {
            InitializeComponent();
            Sender = new MyDel(getMSSV);
            setCBB_Class();
            rdFemale.Checked = true;
           

        }
        public void setCBB_Class()
        {
            List<LSH> list = BLL_QLSV.Instance.getALLLSH_BLL();
            foreach (var i in list)
            {
                cbbLSH.Items.Add(new CBBItems
                {
                    Text = i.NameLop,
                    Value = i.ID_Lop

                });
            }
            cbbLSH.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mssv !="")
            {
                BLL_QLSV.Instance.updateSVByMSSV_BLL(getInforSVToAdd());
            }
            else
            {
                BLL_QLSV.Instance.addSV_BLL(getInforSVToAdd());
            }
            refresh();
            this.Dispose();

        }
         private SV getInforSVToAdd()
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
        public void loadDataSV()
        {
            SV s = BLL_QLSV.Instance.getSVByMSSV(mssv);
            txtMSSV.Text = s.MSSV;
            txtName.Text = s.NameSV;
            if (s.Gender == true) rdMale.Checked = true;
            else rdFemale.Checked = true;
            dateTimePicker1.Value = s.NS;
            foreach(var i in cbbLSH.Items)
            {
                
               if (((CBBItems)i).Value==s.ID_Lop)
                {
                    cbbLSH.SelectedItem = i;
                    return;
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (mssv != "") loadDataSV();
        }
    }
}
