using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace My_Links
{
    class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection consql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyLink.mdf;Integrated Security=True");
            return consql;
        }

        public DataSet getData(String query)
        {
            SqlConnection consql = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = consql;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public void setData(String query, String message)
        {
            SqlConnection consql = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = consql;
            consql.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            MessageBox.Show(" '" + message + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public SqlDataReader getForCombo(String query)
        {
            SqlConnection consql = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = consql;
            consql.Open();
            cmd = new SqlCommand(query, consql);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;

        }
    }
}
