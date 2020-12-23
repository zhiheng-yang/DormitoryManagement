using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT * FROM visit_record";
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}




