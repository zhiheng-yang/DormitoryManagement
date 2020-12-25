using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DormitoryManagement
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select description from role";
                conn.Open();
                da = new MySqlDataAdapter(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                bind_gridview();
                conn.Close();
            }
            catch (MySqlException e1)
            {
                Response.Write(e1.Message.ToString());
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

            }catch (MySqlException e2)
            {
                Response.Write(e2.Message.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dst = new DataSet();
                da.Fill(dst);
                DataRow dr = dst.Tables[0].NewRow();
                dr["description"] = this.TextBox1.Text;
                dst.Tables[0].Rows.Add(dr);
                da.Update(dst);
                bind_gridview();
                Response.Write("RoleManagement.aspx");
            }
            catch(MySqlException e3)
            {
                Response.Write(e3.Message.ToString());
            }
        }

        [Obsolete]
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Int32.Parse(e.CommandArgument.ToString());
            String description = this.GridView1.Rows[index].Cells[0].Text;

            String sql = "delete from role where description = @description";
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("@description", description)};
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                //cmd.Parameters.AddRange(parameters);
                cmd.CommandText = sql;

                //Response.Write(cmd.ExecuteNonQuery());
                cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                //DataTable table = ds.Tables[0];
                Response.Redirect("RoleManagement.aspx");
            }
            catch (Exception e4)
            {
                this.Page.RegisterStartupScript(" ", "<script>alert(' 已有了该身份的用户，不能删除！ '); </script> "); 
                // Response.Write(e4.Message.ToString());
            }
        }

    }
}