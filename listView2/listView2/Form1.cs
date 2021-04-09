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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //setLV();
            setDGV();
        }
        public void setLV()
        {
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "MSSV";
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Ten";
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "DTB";
            listView1.Columns.AddRange(new ColumnHeader[] { c1, c2, c3 });
            ListViewItem i1 = new ListViewItem();
            i1.Text = "102190160";
            ListViewItem.ListViewSubItem sb1 = new ListViewItem.ListViewSubItem();
            sb1.Text = "Truong Thi My Duyen";
            ListViewItem.ListViewSubItem sb2 = new ListViewItem.ListViewSubItem();
            sb2.Text = "8.51";
            i1.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { sb1, sb2 });
            listView1.Items.Add(i1);


            ListViewItem i2 = new ListViewItem();
            i2.Text = "102190161";
            ListViewItem.ListViewSubItem sb21 = new ListViewItem.ListViewSubItem();
            sb21.Text = "Le Hoang Ngoc Han";
            ListViewItem.ListViewSubItem sb22 = new ListViewItem.ListViewSubItem();
            sb22.Text = "8.8";
            i2.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { sb21, sb22 });
            listView1.Items.Add(i2);

        }
        //những row được lựa chọn sẽ chuyển thành list vieew item
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection r = listView1.SelectedItems;
            if (r.Count > 0)
            {
                string s = "";
                foreach (ListViewItem i in r)
                {
                    string MSSV = i.Text;
                    string Name = i.SubItems[1].Text;
                    string dtb = i.SubItems[2].Text;
                    s += MSSV + "," + Name + "," + dtb + "\n";
                }
                MessageBox.Show(s, "thong tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void setDGV()
        {
            SV[] arr = new SV[]
            {
                new SV { MSSV = "102190160", Name = "Truong Thi My Duyen", DTB = 8.5, Gender = "True" },
                new SV { MSSV = "102190161", Name = "Le hoang ngoc han", DTB = 9.5, Gender = "True" },
                new SV { MSSV = "102190175", Name = "Tran Thi Phuong", DTB = 7.5, Gender = "True" }
         
            };
            List<SV> l = new List<SV>();
            l.AddRange(new SV[]
            {
                new SV { MSSV = "102190160", Name = "Truong Thi My Duyen", DTB = 8.5, Gender = "True" },
                new SV { MSSV = "102190161", Name = "Le hoang ngoc han", DTB = 9.5, Gender = "True" },
                new SV { MSSV = "102190175", Name = "Tran Thi Phuong", DTB = 7.5, Gender = "True" }
            });
            //Datatable
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("Name"),
                new DataColumn("DTB"),
                new DataColumn("Gender",typeof(bool))
            });
            foreach(SV i in l)
            {
                DataRow dr = dt.NewRow();
                dr["MSSV"] = i.MSSV;
                dr["Name"] = i.Name;
                dr["DTB"] = i.DTB.ToString();
                dr["Gender"] = i.Gender;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if (r.Count > 0)
            {
                string s = "";
                foreach(DataGridViewRow i in r)
                {
                    string MSSV = i.Cells["MSSV"].Value.ToString();
                    string Name = i.Cells["Name"].Value.ToString();
                    double DTB = Convert.ToDouble(i.Cells["DTB"].Value.ToString());
                    bool Gender = Convert.ToBoolean(i.Cells["Gender"].Value.ToString());

                    s += MSSV + "," + Name + "," + DTB.ToString() + "," + Gender.ToString() + "\n";
                }
                MessageBox.Show(s);
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All|*.*|Excel|*.xlsx";
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
        }
    }
}
