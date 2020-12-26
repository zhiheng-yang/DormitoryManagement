using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace DormitoryManagement
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            //Response.Write("<script>alert('"+username.Text+" "+password.Text+"')</script>");
        }

        protected void Button1_Click(object sender, EventArgs e) {

            // QuickLogin是可以直接点击登录，默认登录zach用户，密码123456，测试时使用
            // QuickLogin();

            // 正确的登录界面，正式使用时用这个
            Login();

        }

        public void Login()
        {

            string username = this.username.Text;
            string password = this.password.Text;

            if (username == "")
            {
                Response.Write(@"<script>alert('用户名不能为空！');</script>");
                return;
            }
            if (password == "")
            {
                Response.Write(@"<script>alert('密码不能为空！');</script>");
                return;
            }
            String sql = "select * from user where username=@username and password=@password";
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("@username", username), new MySqlParameter("@password", password) };
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
                DataTable table = ds.Tables[0];

                // 获得了他的身份id,并存在session中
                Session.Contents["id"] = table.Rows[0]["id"].ToString();
                Session.Contents["role_id"] = table.Rows[0]["role_id"].ToString();
                Session.Contents["IDCard"] = table.Rows[0]["IDCard"].ToString();
                Session.Contents["name"] = table.Rows[0]["name"].ToString();
                Session.Contents["username"] = table.Rows[0]["username"].ToString();

                // Session.Contents["name"] = table.Rows[0]["name"].ToString();
                //Session.Contents["username"] = table.Rows[0]["username"].ToString();
                Session.Timeout = 120;
                // 通过判断记录的条数来确定是否有该用户
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Response.Redirect("Empty.aspx"); 
                }

                else
                {
                    Response.Write(@"<script>alert('密码错误，登录失败！');</script>");
                }
                
                conn.Close();

            }
            catch (Exception e)
            {
                Response.Write(@"<script>alert('密码错误，登录失败！');</script>");
                // Response.Write(e.Message.ToString());
            }

        }

        public void QuickLogin()
        {
            Session.Contents["id"] = "1";
            Session.Contents["role_id"] = "1";
            Session.Contents["IDCard"] = "371525200012230037";
            Session.Contents["name"] = "派大星";
            Session.Contents["username"] = "pdx";
            Session.Contents["room_id"] = "2";
            Session.Timeout = 120;
            // 通过判断记录的条数来确定是否有该用户
            Response.Redirect("RepairApplication.aspx");
            //try
            //{
            //    //MySqlParameter[] parameters = { new MySqlParameter("@username", username), new MySqlParameter("@password", password) };
            //    //MySqlConnection conn = new MySqlConnection(strConnection);
            //    //conn.Open();
            //    //MySqlCommand cmd = conn.CreateCommand();
            //    //cmd.CommandText = sql;

            //    ////Response.Write(cmd.ExecuteNonQuery());
            //    //cmd.Parameters.AddRange(parameters);
            //    //DataSet ds = new DataSet();
            //    //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            //    //adapter.Fill(ds);
            //    //DataTable table = ds.Tables[0];

            //    // 获得了他的身份id,并存在session中
            //    Session.Contents["id"] = "1";
            //    Session.Contents["role_id"] = "1";
            //    Session.Contents["IDCard"] = "371525200012230037";
            //    Session.Contents["name"] = "派大星";
            //    Session.Contents["username"] = "pdx";
            //    Session.Contents["room_id"] = "2";
            //    Session.Timeout = 120;
            //    // 通过判断记录的条数来确定是否有该用户
            //    Response.Redirect("RepairApplication.aspx");

            //}
            //catch (Exception e)
            //{
            //    Response.Write(e.Message.ToString());
            //}
        }
    }
}