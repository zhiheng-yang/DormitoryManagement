using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        private MySqlCommand da;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void passti_Click(object sender, EventArgs e)
        {
            if (!p1.Text.Equals(p2.Text))
            {
                Response.Write(@"<script>alert('两次密码不一致，请检查');</script>");
                return;
            }
            String sql = "update user set password ='" + p1.Text + "' where id = " + Session.Contents["id"];
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                da = new MySqlCommand(sql, conn);
                int result = da.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("数据库影响行数，修改密码" + result + "\n");
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                conn.Close();
                Response.Write(@"<script>alert('修改密码成功');</script>");
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                Response.Write(@"<script>alert('数据库操作异常');</script>");
            }
        }
    }
}