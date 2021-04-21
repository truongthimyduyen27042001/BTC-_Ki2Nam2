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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCBBLopSH();
            getSVByDemand_GUI();
            setcbbSort(); 


        }
        //Lấy dữ liệu lớp sinh hoạt từ DBHelp đổ vào cbb
        public void setCBBLopSH()
        {
            List<LopSH> list = BLL_QLSV.Instance.getListLopSH_BLL();
            cbbLSH.Items.Add(new CBBItems
            {
                Value =0,
                Text="All"
            });
            foreach(var i in list)
            {
                cbbLSH.Items.Add(new CBBItems
                {
                    Value = i.ID_Lop,
                    Text=i.NameLop
                }) ;
            }
            cbbLSH.SelectedIndex = 0;

        }
        //Set cbbSort ()
        public void setcbbSort()
        {
            foreach(var i in BLL_QLSV.Instance.getCBBSortDemand())
            {
                cbbSort.Items.Add(new CBBItems
                {
                    Value = i.Value,
                    Text = i.Text

                }) ;
            }
            cbbSort.SelectedIndex = 0;
        }

        //thuc hien ham show
        private void btnShow_Click(object sender, EventArgs e)
        {

            getSVByDemand_GUI();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            String MSSV = "";
            f.Sender(MSSV);
            f.refresh = getSVByDemand_GUI;
            f.Show();

        }
        //Viết một hàm get Sv theo yêu cầu , ví dụ như chọn lớp sinh hoạt chỗ cbb và nhập tên chỗ txtName
        public void getSVByDemand_GUI()
        {
            string name = txtNameSV.Text;
            int idlop = ((CBBItems)cbbLSH.SelectedItem).Value;
            List<SV> list = BLL_QLSV.Instance.getSVByDemand_BLL(name, idlop);
            dataGridView1.DataSource = BLL_QLSV.Instance.getListSVView_BLL(list);
            
        }
        //Viet ham cho edit sv 
        //Lay du lieu MSSV tu datagrid sau do truyen vao qua form 2 de lay dataSV show len man hinh
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            int index = dataGridView1.CurrentRow.Index;
            string mssv = BLL_QLSV.Instance.getMSSVByIndex_BLL(index);
            f.Sender(mssv);
            f.refresh = getSVByDemand_GUI;
            f.ShowDialog();
   

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentRow.Index;
            string MSSV = BLL_QLSV.Instance.getMSSVByIndex_BLL(index);
            BLL_QLSV.Instance.deleteSV_BLL(MSSV);
            getSVByDemand_GUI();

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            String demand = cbbSort.Text;
            dataGridView1.DataSource = BLL_QLSV.Instance.SortListSVByDemand(demand);
        }
    }
}
