using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace QLSVMVC3Layer
{
    class DBHelper
    {
        private static DBHelper _Instance;
        private SqlConnection cnn;
        static string connec = ConfigurationManager.ConnectionStrings["connec"].ConnectionString;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string cnnstr = @"Data Source=DESKTOP-D9VU28Q\SQLEXPRESS;Initial Catalog=QLSV2;Integrated Security=True";
                    _Instance = new DBHelper(cnnstr);
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExecuteDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql,cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable getRecords(string sql)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        


    }
}
