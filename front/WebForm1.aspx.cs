using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement.front
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                //String strSql = "SELECT * FROM USER";
                String strSql = "SELECT * FROM REPAIR_APPLICATION";
                conn.Open();
                da = new MySqlDataAdapter(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                bind_gridview();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }


        private void bind_gridview()
        {
            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //DataSet dst = new DataSet(); da.Fill(dst); 
                //DataRow dr = dst.Tables[0].NewRow();
                //dr["user_id"] = 1;
                //dr["room_id"] = Int64.Parse(this.TextBox1.Text);
                //dr["isCompleted"] = false; 
                //dr["time"] = DBNull; 
                //dst.Tables[0].Rows.Add(dr); 
                //da.Update(dst); 
                bind_gridview();
            }
            catch (MySqlException ex) 
            { 
                Response.Write(ex.Message.ToString()); 
            }

        }
        public MySqlConnection getConn()
        {
            string connetStr = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            return conn;
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}