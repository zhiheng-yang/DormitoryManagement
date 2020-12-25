using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DormitoryManagement
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT * FROM health_record where user_id =";
                strSql += Session.Contents["id"];
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
                HealHis.DataSource = ds.Tables[0].DefaultView;
                HealHis.DataBind();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

    }
}