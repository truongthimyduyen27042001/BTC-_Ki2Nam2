using QLSVMVC3Layer.BLL;
using QLSVMVC3Layer.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSVMVC3Layer.DTO;

namespace QLSVMVC3Layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            setCBBLSH();
            getCBBSort();


        }

       
        public void setCBBLSH()
        {
            List<LSH> list = BLL_QLSV.Instance.getALLLSH_BLL();
            cbbLSH.Items.Add(new CBBItems
            {
                Text="All",
                Value=0
            });
            foreach(var i in list)
            {
                cbbLSH.Items.Add(new CBBItems
                {
                    Text=i.NameLop,
                    Value=i.ID_Lop
                });
            }
            cbbLSH.SelectedIndex = 0;
        }
        public void getCBBSort()
        {
            List<CBBItems> list = BLL_QLSV.Instance.getDemandSort_BLL();
            foreach(var i in list)
            {
                cbbSo.Items.Add(i);
                
            }
            cbbSo.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            dataGridView2.DataSource = BLL_QLSV.Instance.getListSV_BLL();
        }
       

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string MSSV = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            int idlop = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_LSH"].Value.ToString());
            f.Sender(MSSV);
            f.ShowDialog();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string MSSV = "";
            f.Sender(MSSV);
            f.refresh = getSVByDemand_GUI;
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string mssv = dataGridView2.CurrentRow.Cells["MSSV"].Value.ToString();
            f.Sender(mssv);
            f.refresh= getSVByDemand_GUI;
            f.ShowDialog();
           
        }
        private void getSVByDemand_GUI()
        {
            string name = textBox1.Text;
            int idlop = ((CBBItems)cbbLSH.SelectedItem).Value;
            dataGridView2.DataSource = BLL_QLSV.Instance.getSVByDemand_BLL(name, idlop);

        }

        private void cbbLSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSVByDemand_GUI();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getSVByDemand_GUI();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MSSV = dataGridView2.CurrentRow.Cells["MSSV"].Value.ToString();
            BLL_QLSV.Instance.deleteSV_BLL(MSSV);
            getSVByDemand_GUI();
        }

        public delegate bool Compare(object a, object b);
        private void btnSort_Click(object sender, EventArgs e)
        {
            //Lấy được dãy mssv hiện có trong datagridview 
            List<String> listMSSV = new List<String>();
           
            foreach(DataGridViewRow dr in dataGridView2.Rows)
            {
                listMSSV.Add(dr.Cells["MSSV"].Value.ToString());
            }
        
            string demand = cbbSo.SelectedItem.ToString();
            dataGridView2.DataSource = BLL_QLSV.Instance.sortSVByDemand(BLL_QLSV.Instance.getListSVByListMSSV_BLL(listMSSV), demand);
           

        }
    }
}
