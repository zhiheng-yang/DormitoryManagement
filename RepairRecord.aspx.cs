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
                String strSql = "select repair_application.id,room_no,time,description,isCompleted from repair_application INNER JOIN room on repair_application.room_id = room.id where isCompleted=1";
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
    }

}