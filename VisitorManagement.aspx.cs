


using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DormitoryManagement
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private const string strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
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
                if (ds.Tables.Count != 0)
                {
                    GridView1.DataSource = ds.Tables[0].DefaultView;
                    GridView1.DataBind();
                }

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private void FillData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT * FROM visit_record";
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                da = new MySqlDataAdapter(mySqlCommand);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                bind_gridview();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private int GrantedCheck(int x)
        {
            int num = -5;
            try
            {

                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT isGranted FROM visit_record";
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                da = new MySqlDataAdapter(mySqlCommand);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows[x].ToString().Equals("0"))
                {
                    num = 0;
                }
                else if (ds.Tables[0].Rows[x].ToString().Equals("1"))
                {
                    num = 1;
                }
                else if (ds.Tables[0].Rows[x].ToString().Equals("-1"))
                {
                    num = -1;
                }
                else
                {
                    num = 5;
                }
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            return num;
        }
        private void Grant(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                string str = "update visit_record set isGranted = 1 where id = ";
                string strSql = str + (id + 1);
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                mySqlCommand = new MySqlCommand("SELECT * FROM visit_record", conn);
                da = new MySqlDataAdapter(mySqlCommand);
                ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
        private void Refuse(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                string str = "update visit_record set isGranted = -1 where id = ";
                string strSql = str + (id + 1);
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                mySqlCommand = new MySqlCommand("SELECT * FROM visit_record", conn);
                da = new MySqlDataAdapter(mySqlCommand);
                ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Int32.Parse(e.CommandArgument.ToString());
            //string id = GridView1.Rows[index].Cells[6].Text;
            if (e.CommandName == "grant")
            {
                string tip = @"<script>alert('已批准该访问！');</script>";
                Grant(index);
                Response.Write(tip);
            }
            if (e.CommandName == "refuse")
            {
                string tip = @"<script>alert('已拒绝该访问！');</script>";
                Refuse(index);
                Response.Write(tip);
            }
        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}