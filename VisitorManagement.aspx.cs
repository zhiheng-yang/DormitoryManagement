
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
            FillGridView();
            SetName(GridView1);
            SetName(GridView2);
            SetGrantedStatus(GridView1);
            SetGrantedStatus(GridView2);
            SetTitle();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FillGridView()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select * from visit_record";
                conn.Open();
                SqlAndGridView(conn, strSql, GridView1);
                SqlAndGridView(conn, "select * from visit_record where isGranted = 0", GridView2);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private void SetName(GridView gv)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                string str = "select name from user where id = ";
                string strSql = str + gv.Rows[i].Cells[1].Text;
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.Rows[i].Cells[1].Text = ds.Tables[0].Rows[0][0].ToString();
            }

        }
        private void SetGrantedStatus(GridView gv)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                if (gv.Rows[i].Cells[6].Text.Equals("0"))
                {
                    gv.Rows[i].Cells[6].Text = "未批准";
                }
                else if (gv.Rows[i].Cells[6].Text.Equals("1"))
                {
                    gv.Rows[i].Cells[6].Text = "已批准";
                }
                //Response.Write("<script>alert(' " + gv.Rows[i].Cells[6].Text + " ');</script>");
            }

        }
        private void SetTitle()
        {
            if (GridView2.Rows.Count == 0)
            {
                Label2.Text = "暂无最新来访申请";
            }
            else
            {
                Label2.Text = "来访申请审批";
            }
        }

        protected void SqlAndGridView(MySqlConnection conn, string sqlStr, GridView gv)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, conn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
            da = new MySqlDataAdapter(mySqlCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count != 0)
            {
                gv.DataSource = ds.Tables[0].DefaultView;
                gv.DataBind();
            }
        }
        private void Grant(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                string str = "update visit_record set isGranted = 1 where id = ";
                string strSql = str + id;
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlAndGridView(conn, "select * from visit_record", GridView1);
                SqlAndGridView(conn, "select * from visit_record where isGranted = 0", GridView2);
                conn.Close();
                SetName(GridView1);
                SetName(GridView2);
                SetGrantedStatus(GridView1);
                SetGrantedStatus(GridView2);
                SetTitle();
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
                GridView2.DataSource = ds.Tables[0].DefaultView;
                GridView2.DataBind();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }

        protected void GridView2_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Int32.Parse(e.CommandArgument.ToString());
            string id_str = GridView2.Rows[index].Cells[0].Text;
            int id = Int32.Parse(id_str);
            if (e.CommandName == "grant")
            {
                string tip = @"<script>alert('已批准该访问！');</script>";
                Grant(id);
                Response.Write(tip);
            }
            if (e.CommandName == "refuse")
            {
                string tip = @"<script>alert('已拒绝该访问！');</script>";
                Refuse(id);
                Response.Write(tip);
            }
        }
        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
