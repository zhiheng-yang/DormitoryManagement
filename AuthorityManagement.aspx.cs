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
    public partial class WebForm17 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        private MySqlDataAdapter da2;
        String update_role_id = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["default_role_id"] != null)
                update_role_id = Session.Contents["default_role_id"].ToString();
            else
                update_role_id = "1";
            if (!Page.IsPostBack)
            {
               

                try
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "select * from menu";
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

                try
                {
                    String strConnection2 = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                    MySqlConnection conn2 = new MySqlConnection(strConnection2);
                    String strSql2 = "select * from menu where id in (SELECT menu_id FROM role_menu where role_id = " + update_role_id + ")";
                    conn2.Open();
                    da2 = new MySqlDataAdapter(strSql2, conn2);
                    MySqlCommandBuilder cb2 = new MySqlCommandBuilder(da2);
                    bind_gridview2();
                    conn2.Close();
                }
                catch (MySqlException e1)
                {
                    Response.Write(e1.Message.ToString());
                }

                string sql = string.Format("select * from role");

                DropDownList1.DataSource = Table(sql);
                DropDownList1.DataTextField = "description";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
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
            catch (MySqlException e2)
            {
                Response.Write(e2.Message.ToString());
            }
        }


        private void bind_gridview2()
        {
            try
            {
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                GridView2.DataSource = ds2.Tables[0].DefaultView;
                GridView2.DataBind();

            }
            catch (MySqlException e2)
            {
                Response.Write(e2.Message.ToString());
            }
        }

        [Obsolete]
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            String menu_id = this.GridView1.Rows[index].Cells[0].Text;
            Response.Write(update_role_id);
            Response.Write(menu_id);
            String sql = "INSERT INTO role_menu (role_id,menu_id) VALUES (@role_id,@menu_id);";
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("@role_id", update_role_id), new MySqlParameter("@menu_id", menu_id) };
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
                // Response.Redirect("RoleManagement.aspx");
            }
            catch (Exception e4)
            {
                // this.Page.RegisterStartupScript(" ", "<script>alert(' 已经拥有了该权限，不能再次分配 '); </script> ");
                Response.Write(e4.Message.ToString());
            }


            try
            {
                String strConnection2 = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                MySqlConnection conn2 = new MySqlConnection(strConnection2);
                String strSql2 = "select * from menu where id in (SELECT menu_id FROM role_menu where role_id = " + update_role_id + ")";
                conn2.Open();
                da2 = new MySqlDataAdapter(strSql2, conn2);
                MySqlCommandBuilder cb2 = new MySqlCommandBuilder(da2);
                bind_gridview2();
                conn2.Close();
            }
            catch (MySqlException e1)
            {
                Response.Write("emmmmm" + e1.Message.ToString());
            }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            String menu_id = this.GridView2.Rows[index].Cells[0].Text;
            Response.Write(update_role_id);
            Response.Write(menu_id);
            String sql = "DELETE FROM role_menu WHERE role_id = @role_id and menu_id = @menu_id;";
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("@role_id", update_role_id), new MySqlParameter("@menu_id", menu_id) };
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
                // Response.Redirect("RoleManagement.aspx");
            }
            catch (Exception e4)
            {
                // this.Page.RegisterStartupScript(" ", "<script>alert(' 已经拥有了该权限，不能再次分配 '); </script> ");
                Response.Write(e4.Message.ToString());
            }


            try
            {
                String strConnection2 = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                MySqlConnection conn2 = new MySqlConnection(strConnection2);
                String strSql2 = "select * from menu where id in (SELECT menu_id FROM role_menu where role_id = " + update_role_id + ")";
                conn2.Open();
                da2 = new MySqlDataAdapter(strSql2, conn2);
                MySqlCommandBuilder cb2 = new MySqlCommandBuilder(da2);
                bind_gridview2();
                conn2.Close();
            }
            catch (MySqlException e1)
            {
                Response.Write("emmmmm" + e1.Message.ToString());
            }
        }

        //static string ConnStr = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";//声明一个字符串用来存放连接数据库的信息
        public static DataTable Table(string sql)
        {
            // 这个Table很强
            using (MySqlConnection conn = new MySqlConnection("server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True"))
            {
                
                MySqlDataAdapter sda = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_role_id = this.DropDownList1.SelectedItem.Value;
            
            Session.Contents["default_role_id"] = this.DropDownList1.SelectedItem.Value;
            try
            {
                String strConnection2 = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                MySqlConnection conn2 = new MySqlConnection(strConnection2);
                String strSql2 = "select * from menu where id in (SELECT menu_id FROM role_menu where role_id = " + update_role_id + ")";
                conn2.Open();
                da2 = new MySqlDataAdapter(strSql2, conn2);
                MySqlCommandBuilder cb2 = new MySqlCommandBuilder(da2);
                bind_gridview2();
                conn2.Close();
            }
            catch (MySqlException e1)
            {
                Response.Write(e1.Message.ToString());
            }
            //Response.Redirect("AuthorityManagement.aspx");
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            //Response.Write("<script>alert(' " + this.DropDownList1.SelectedItem.Text + " '); </script> ");
        }
    }
}