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

        }

        protected void Button1_Click(object sender, EventArgs e) {
            //Response.Write("<script>alert('"+username.Text+" "+password.Text+"')</script>");
            Login();
        }

        public void Login()
        {
            // **************************************************
            // 为了方便测试而不需要输入用户名密码，后期需要删掉**
            Response.Redirect("example.aspx"); //              **
            // 为了方便测试而不需要输入用户名密码，后期需要删掉**
            // **************************************************


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
            String sql = "select name from user where username=@username and password=@password";
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
                // 通过判断记录的条数来确定是否有该用户
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Response.Redirect("example.aspx"); 
                }

                else
                {
                    Response.Write(@"<script>alert('密码错误，登录失败！');</script>");
                }
                
                conn.Close();

            }
            catch (Exception e)
            {
                
                Response.Write(e.Message.ToString());
            }
            //string str = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;";
            //SqlConnection conn = new SqlConnection(str);
            //conn.Open();
            //string sql = "select * from user where username=@userName and password=@password";
            //SqlCommand comm = new SqlCommand(sql, conn);
            //comm.Parameters.Add("useruame", username.Text);
            //comm.Parameters.Add("password", password.Text);
            //SqlDataReader sdr = comm.ExecuteReader();
            //if (sdr.Read())
            //{
            //    Session["userName"] = username.Text;
            //    Session["password"] = password.Text;
            //    //lblMessage.Text = "登陆成功！";
            //    Response.Write("<script>alert('欢迎" + Session["userName"] + ",您成功登录!');location.href='WebForm1.aspx';</script>");
            //    //Response.Write("<script>alert('登录成功欢迎您');location.href='../secure/report/test2.aspx';</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('用户名或者密码错误！')</script>");
            //    //Response.Redirect("login.aspx");
            //}

            ////Server.Transfer("../secure/report/test2.aspx");
            ////Response.Write("<script>alert('登录成功欢迎您');location.href='../secure/report/test2.aspx';</script>");
            ////Response.Write("../secure/report/test.aspx");
            ////Response.Redirect("../secure/report/test.aspx");
            //conn.Close();
        }
    }
}