using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT username,no,health_zao1,health_zao2,health_zhong1,health_zhong2,health_wan1,health_wan2" +
                    " FROM health_record,user where " +
                    "health_record.user_id=user.id and time = curdate() ";
                System.Diagnostics.Debug.Write(strSql);
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
                HealMa.DataSource = ds.Tables[0].DefaultView;
                HealMa.DataBind();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
    }
}