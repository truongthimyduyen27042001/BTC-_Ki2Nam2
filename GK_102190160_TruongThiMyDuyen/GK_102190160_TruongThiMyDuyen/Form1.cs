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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL_OOP.Instance.getDataGV();
            getCBBMSV();
            getCBBSort();
        }
        //do du lieu cho cbbLCS
        public void getCBBMSV()
        {
            cbbMCS.Items.Add("All");
            foreach(DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                cbbMCS.Items.Add(dr["NameCS"]);
            }
            cbbMCS.SelectedIndex = 0;
        }
        //lay du lieu cho cbb Sort 
        public void getCBBSort()
        {
            cbbSort.Items.Add("");
            foreach (DataColumn dc in CSDL.Instance.DTGV.Columns)
            {

                cbbSort.Items.Add(dc.ColumnName);

            }
            cbbSort.SelectedIndex = 0;
        }
        //lam ham show theo ma cs da luc chon 
        private void btnShow_Click(object sender, EventArgs e)
        {
            //truyen vao mot cai ma cs sau do lua chonj tu thang dataGV nhung thang co chung mascv
            
            if (cbbMCS.SelectedIndex == 0) dataGridView1.DataSource = CSDL_OOP.Instance.getDataGV();
            
            else
                dataGridView1.DataSource = CSDL_OOP.Instance.getGVByCSName(cbbMCS.SelectedItem.ToString());
        }
        // //code event cho nut search // mình sẽ lấy dữ liệu của thằng cbbCS và dữ liệu tên đã nhập vào để tifm kiếm dữ liệu
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string idcs = CSDL_OOP.Instance.getIDCSByCSName(cbbMCS.Text);
            dataGridView1.DataSource = CSDL_OOP.Instance.searchSVByDemand(idcs, txtSearch.Text);
        }

        //lam ham add 
        //Các bước làm hàm add
        //1.Cần có một hàm get dữ liệu từ tầng giao diện về CSDL_OOP trả về dữ liệu SV 
        //2. Sau đó vào hàm add bên CSDL tạo một list sv lấy dữ liệu từ thằng csdl_oop về 
        //3. add thêm thằng SV vừa get được từ form 2 
        //4. Vào bên hàm CSDL để gán lại CSDL.DTSV cho thằng list ( thằng này là tham số được truyền vào )
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Sender("", 0);
            f.ShowDialog();
            this.Hide();
        }
        //mot ham get GV tu view ve tra ve GV
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string idcs = dataGridView1.CurrentRow.Cells["ID_CS"].Value.ToString();
            int magv = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_GV"].Value.ToString());
            f.Sender(idcs, magv);
            f.ShowDialog();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int magv = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_GV"].Value.ToString());
            CSDL_OOP.Instance.deleteGV(magv);
            referesh();


        }
        public void referesh()
        {
            dataGridView1.DataSource = CSDL.Instance.DTGV;
        }

    }
}
