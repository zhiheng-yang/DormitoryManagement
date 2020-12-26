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
    public partial class WebForm18 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select repair_application.id,isOver,room_no,time,description,isCompleted from repair_application INNER JOIN room on repair_application.room_id = room.id where isCompleted=1 and isOver=0";
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
                SetGrantedStatus(GridView1);
            }
            catch (MySqlException e2)
            {
                Response.Write(e2.Message.ToString());
            }
        }

        private void SetGrantedStatus(GridView gv)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {

                gv.Rows[i].Cells[4].Text = "已批准,待维修";
               
                //Response.Write("<script>alert(' " + gv.Rows[i].Cells[6].Text + " ');</script>");
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
                MySqlConnection conn = new MySqlConnection("server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;");
                string str = "update repair_application set isOver = 1 where id = ";
                string strSql = str + id;
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlAndGridView(conn, "select repair_application.id,isOver,room_no,time,description,isCompleted from repair_application INNER JOIN room on repair_application.room_id = room.id where isCompleted=1;", GridView1);

                conn.Close();
                //SetName(GridView1);
                //SetName(GridView2);
                SetGrantedStatus(GridView1);
                Response.Redirect("RepairRecord.aspx");
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            string id_str = GridView1.Rows[index].Cells[0].Text;
            int id = Int32.Parse(id_str);
            
            
            Grant(id);
            
        }
    }

}