using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLSV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL.Instance.DTSV;
            getCbbLSH();
            getCbbSort();


        }
        public void getCbbLSH()
        {
            //DataTable r = new DataTable();
            //r = CSDL.Instance.DTLSH;
            //for (int i = 0; i < r.Rows.Count; i++) {
            //    cbbLSH.Items.Add(r.Rows[i]["NameLSH"]);
            //}
            //cbbLSH.Items.Add("All");
            cbbLSH.Items.Add(new CBBItems
            {
                Text = "All",
                Value = 0
            });
            foreach(DataRow dr in CSDL.Instance.DTLSH.Rows)
            {
                cbbLSH.Items.Add(new CBBItems
                {
                    Text = dr["NameLSH"].ToString(),
                    Value = Convert.ToInt32(dr["ID_Lop"].ToString())
                }); 

            }
            cbbLSH.SelectedIndex = 0;
        }
        //Suwj kienj chọn cbbLSH thì xuất hiện những sinh viên thuộc lớp đó
        private void cbbLSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbbLSH.SelectedItem.ToString() == "All")
            //{
            //    dataGridView1.DataSource = CSDL.Instance.DTSV;
            //    return;
            //}
            //else
            //{
            //    int index = cbbLSH.SelectedIndex;
            //    CBBItems cbb = new CBBItems
            //    {
            //        Text = cbbLSH.Items[index].ToString(),
            //        Value = Convert.ToInt32(CSDL.Instance.DTLSH.Rows[index]["ID_Lop"])
            //    };
            //    //taoj mot datatable có lớp = Items của combox để lấy data
            //    DataTable dt = new DataTable();
            //    dt = CSDL.Instance.createDataSV(cbb.Value);
            //    dataGridView1.DataSource = dt;
            //}

            if (cbbLSH.SelectedItem.ToString() == "All")
            {
                dataGridView1.DataSource = CSDL.Instance.DTSV;
                return;
            }
            //sau khi chon duoc cbbClass thì nó phải cho ra được id lớp đó, chuyeenr qua hàm getIDbyClass của CSDL
            else
            {
                string namelop = cbbLSH.Text;
                dataGridView1.DataSource = CSDL.Instance.showSVForClassName(namelop);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            //Phải lấy được index thực trong datatable => viết hàm lấy index theo khóa chính là mssv
           int index = dataGridView1.CurrentRow.Index; 
            f.Sender("", "add");
            f.ShowDialog();
            this.Hide();

        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string id = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            //int index = CSDL.Instance.getRealIndex(id);
            f.Sender(id, "edit");
            f.ShowDialog();
            this.Hide();
        }
        //public bool checkIn(DataGridViewSelectedRowCollection r,DataRow dr)
        //{
        //    for(int i = 0; i < r.Count; i++)
        //    {
        //        if (r[i]==dr) return true;
        //    }
        //    return false;
        //}
        //Mình chọn từ dataGridView sau đó những thằng mình chọn sẽ xóa 
        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            
            
            
            for(int i = 0; i < r.Count; i++)
            {
                CSDL.Instance.deleteSV( r[i].Cells["MSSV"].Value.ToString());
            }
            dataGridView1.DataSource = CSDL.Instance.DTSV;


        }
        public void getCbbSort()
        {
            DataTable dt = CSDL.Instance.DTSV;
            foreach(DataColumn dr in dt.Columns)
            {
                cbbSort.Items.Add(dr.ToString());
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string demand = cbbSort.SelectedItem.ToString();
            CSDL.Instance.sortForDemand(demand);
            dataGridView1.DataSource = CSDL.Instance.DTSV;
        }
    }
        //lấy dữ liệu từ thằng ban đầu chọn sau đó truyền vào sẵn dữ liệu của Form2 
        //chỉnh sửa tay sau đó , cập nhật lại và truyền lại

    }


