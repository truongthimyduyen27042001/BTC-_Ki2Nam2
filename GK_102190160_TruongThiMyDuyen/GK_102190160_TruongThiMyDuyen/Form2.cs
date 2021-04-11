using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_102190160_TruongThiMyDuyen
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(string mssv, int idlop);
        static string idcs = "";
        static int msgv = 0;
        public MyDel Sender;
        private void getData(string idclass, int mgv)
        {
            idcs = idclass;
            msgv = mgv;

        }


        public Form2()
        {
            Sender = new MyDel(getData);
            InitializeComponent();
            setCBBMCS();
        }
        //set du lieu cho cbbLSH
        public void setCBBMCS()
        {
            foreach(DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                cbbMaCS.Items.Add(dr["NameCS"].ToString());
            }
            cbbMaCS.SelectedIndex = 0;
        }
        //mot ham lay info giao vien tu view tra ve giao vien 
        private GV getInforGV()
        {
            GV g = new GV();
            g.ID_GV = Convert.ToInt32(txtMSGV.Text);
            g.NameGV = txtNameGV.Text;
            g.SDT = txtNumber.Text;
            g.NS = dateTimePicker1.Value;
            g.ID_CS = CSDL_OOP.Instance.getIDCSByCSName(cbbMaCS.Text);
            
            return g;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (msgv == 0)
            {
                CSDL_OOP.Instance.addGV(getInforGV());
            }
            else
            {
                CSDL_OOP.Instance.updateDTSV(msgv, getInforGV());
            }
            Form1 f = new Form1();
            f.Show();
            this.Dispose();
        }

        //Lam ham edit 
        //1. 
        //mot ham bat du lieu day du cua Sv tu CSDL_OOP sau do show len 
        public void showInforGV()
        {
            GV g = CSDL_OOP.Instance.getInforGV(msgv);
            txtMSGV.Text =g.ID_GV.ToString(); 
            txtNameGV.Text = g.NameGV;
            txtNumber.Text = g.SDT;
            dateTimePicker1.Value = g.NS;
            cbbMaCS.Text = CSDL_OOP.Instance.getNameCSByIDCS(idcs);
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (msgv != 0)
                showInforGV();
        }
        //ham delete 

    }
}
