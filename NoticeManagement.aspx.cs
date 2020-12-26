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
    public partial class WebForm6 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        private static int toTransId;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblDescription.Visible = false;
            txtDescription.Visible = false;
            btnUpdate.Visible = false;
            btnSubmit.Visible = false;
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
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
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            int id = Int32.Parse(GridView1.Rows[index].Cells[0].Text);
            if (e.CommandName == "deleteData")
            {
                try
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "DELETE FROM notice WHERE id = @id";
                    MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    //cmd.Parameters.AddRange(parameters);
                    cmd.CommandText = strSql;
                    cmd.Parameters.AddRange(parameters);
                    DataSet ds = new DataSet();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.CommandText = "SELECT * FROM notice";
                    bind_gridview();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
            if (e.CommandName == "upData")
            {
                lblDescription.Visible = true;
                txtDescription.Visible = true;
                txtDescription.Text = GridView1.Rows[index].Cells[1].Text;
                btnUpdate.Visible = true;
                toTransId = id;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userId = Session.Contents["id"].ToString();
            try
            {
                if (txtDescription.Text.Equals(""))
                {
                    Response.Write(@"<script>alert('公告内容为空！');</script>");
                }
                else
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "UPDATE notice SET description = @description,time = @time,user_id =  @user_id  WHERE id= @id";
                    MySqlParameter[] parameters = { new MySqlParameter("@description", txtDescription.Text),
                                                new MySqlParameter("@time", System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff")),
                                                new MySqlParameter("@user_id", userId),
                                                new MySqlParameter("@id", toTransId)};
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = strSql;
                    cmd.Parameters.AddRange(parameters);
                    DataSet ds = new DataSet();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.CommandText = "SELECT * FROM notice";
                    da = new MySqlDataAdapter(cmd);
                    bind_gridview();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            lblDescription.Visible = false;
            txtDescription.Visible = false;
            btnUpdate.Visible = false;
            txtDescription.Text = "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            lblDescription.Visible = true;
            txtDescription.Visible = true;
            btnSubmit.Visible = true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userId = Session.Contents["id"].ToString();
            try
            {
                if (txtDescription.Text.Equals(""))
                {
                    Response.Write(@"<script>alert('公告内容为空！');</script>");
                }
                else
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "INSERT INTO notice(description,time,user_id) VALUES (@description,@time,@user_id)";
                    MySqlParameter[] parameters = { new MySqlParameter("@description", txtDescription.Text),
                                                new MySqlParameter("@time", System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff")),
                                                new MySqlParameter("@user_id", userId) };
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = strSql;
                    cmd.Parameters.AddRange(parameters);
                    DataSet ds = new DataSet();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.CommandText = "SELECT * FROM notice";
                    da = new MySqlDataAdapter(cmd);
                    bind_gridview();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            lblDescription.Visible = false;
            txtDescription.Visible = false;
            btnSubmit.Visible = false;
            txtDescription.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
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
    }
}