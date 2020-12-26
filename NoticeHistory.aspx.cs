using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DormitoryManagement
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDescription.Text = "按照发布人查找公告(不输入发布人姓名，默认查看全部公告)：";
            findAll();
        }


        private void bind_gridview()
        {
            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                setName(GridView1);

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void setName(GridView gv)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String str = "select name from user where id = ";
                String str_userId = gv.Rows[i].Cells[3].Text;

                String strSql = str + str_userId;
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                da = new MySqlDataAdapter(mySqlCommand);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.Rows[i].Cells[3].Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Equals(""))
            {
                findAll();
            }
            else
                findByName();
        }
        protected void findByName()
        {
            String userid;
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(strConnection);
            //String strSql = "SELECT * FROM USER";
            String strSql1 = "SELECT id FROM user where name = @user_name";
            MySqlParameter[] parameters1 = { new MySqlParameter("@user_name", txtDescription.Text) };
            conn.Open();
            MySqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = strSql1;
            cmd1.Parameters.AddRange(parameters1);
            da = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                Response.Write(@"<script>alert('未找到该发布人发布的公告！');</script>");
                findAll();
            }
            else
            {
                userid = ds1.Tables[0].Rows[0][0].ToString();
                conn.Close();
                String strSql2 = "SELECT * FROM notice where user_id = @user_id";
                MySqlParameter[] parameters2 = { new MySqlParameter("@user_id", userid) };
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                //cmd.Parameters.AddRange(parameters);
                cmd.CommandText = strSql2;
                cmd.Parameters.AddRange(parameters2);
                da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                setName(GridView1);
                conn.Close();
                txtDescription.Text = "";
            }
        }
        protected void findAll()
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                //String strSql = "SELECT * FROM USER";
                String strSql = "SELECT * FROM notice";
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
    }
}