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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL.Instance.DTSV;
            getCBBLSH();
            getCBBSort();
            
        }
        public void getCBBLSH()
        {
            DataTable dt = CSDL.Instance.DTLSH;
            foreach(DataRow dr in dt.Rows){
                cblsh.Items.Add(dr["NameLop"]);
            }
            cblsh.Items.Add("All");
        }
        public void getCBBSort()
        {
            DataTable dt = CSDL.Instance.DTSV;
            foreach(DataColumn dc in dt.Columns)
            {
                cbSort.Items.Add(dc.ColumnName);
            }
            cbSort.SelectedItem = "MSSV";
        }
        private void refresDataGrid()
        {
            int index = cblsh.SelectedIndex;
            if (index == cblsh.Items.Count - 1)
            {
                dataGridView1.DataSource = CSDL.Instance.DTSV;
                return;
            }
            CBBItems cbb = new CBBItems()
            {
                Text = cblsh.Items[index].ToString(),
                Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
            };
            dataGridView1.DataSource = CSDL.Instance.createDataTable(cbb.Value.ToString());
        }
        private void cblsh_SelectedIndexChanged(object sender, EventArgs e)
        {

            refresDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            //phair lấy được vị trí thực của index theo chỉ số mssv
            int index = dataGridView1.CurrentRow.Index;
            f3.Sender(index, "add");
            f3.ShowDialog();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            int index = 0;
            string SVID = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            index = CSDL.Instance.getRealIndex(SVID);
            f3.Sender(index, "edit");
            f3.ShowDialog();
            this.Hide();
        }
        //lấy data từ  DataTabletương ứng với DataGridView.CurrentRow để hiện thị lên forrm o
        //private void getFunc()
        //{
        //    object[] SV = new object[CSDL.Instance.DTSV.Columns.Count];

        //}

        private void btnDel_Click(object sender, EventArgs e)
        {
            //hiện tại mình chua biết được thằng nào sẽ bị xóa , mình sẽ lựa chọn vị trí bị xóa , thông qua lựa chọn mssv 
            //từ thằng gridview tiếp theo là biết được vị trí của nó trong bảng DTSV thông qua realIndex
            //string IDSV = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            //int index = CSDL.Instance.getRealIndex(IDSV);
            //CSDL.Instance.delegeDTSV(index);
            //refresDataGrid();
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            for (int i = 0; i < r.Count; i++)
            {
                CSDL.Instance.DelSV(r[i].Cells["MSSV"].Value.ToString());
            }
            dataGridView1.DataSource = CSDL.Instance.DTSV;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //DataTable temp = new DataTable();
            //CSDL.Instance.DTSVClone(temp);
            //CSDL.Instance.sortDataTable(temp, cbSort.SelectedIndex.ToString());
            //dataGridView1.DataSource = temp;
            string demand = cbSort.SelectedItem.ToString();
            CSDL.Instance.sortForDemand(demand);
            dataGridView1.DataSource = CSDL.Instance.DTSV;

        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            string nameData = txtSeach.Text;
            dataGridView1.DataSource = CSDL.Instance.createDataTable(nameData);
            dataGridView1.Refresh();
        }
    }
}
