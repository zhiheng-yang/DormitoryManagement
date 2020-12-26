using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DormitoryManagement.front
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Contents["role_id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                getMenus();
            }
            NAME.Text = "退出： " + Session.Contents["name"].ToString();

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //getMenus();
        }

        private void getMenus()
        {
            String role_id = Session.Contents["role_id"].ToString();
            // 嵌套查询，查该用户拥有的菜单
            String sql = "select * from menu where id in (select menu_id from role_menu where role_id = @role_id)";
            String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;Allow User Variables=True";
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("@role_id", role_id) };
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                DataTable table = ds.Tables[0];
                // Response.Write(ds.Tables[0].Rows.Count);
                String wxsq = "维修申请";
                Label label = (Label)Page.FindControl("维修申请");


                //label.Visible = false;
                //维修申请.Visible = false;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    String menu = table.Rows[i]["description"].ToString();
                    if ("维修申请".Equals(menu)) 维修申请.Visible = true;
                    else if ("维修申请管理".Equals(menu)) 维修申请管理.Visible = true;
                    else if ("维修记录查看".Equals(menu)) 维修记录查看.Visible = true;
                    else if ("权限管理".Equals(menu)) 权限管理.Visible = true;
                    else if ("通知公告查看".Equals(menu)) 公告查看.Visible = true;
                    else if ("通知公告管理".Equals(menu)) 公告管理.Visible = true;
                    else if ("来访申请".Equals(menu)) 来访申请.Visible = true;
                    else if ("来访管理".Equals(menu)) 来访管理.Visible = true;
                    else if ("房间管理".Equals(menu)) 房间管理.Visible = true;
                    else if ("查看房间".Equals(menu)) 查看房间.Visible = true;
                    else if ("学生管理".Equals(menu)) 学生管理.Visible = true;
                    else if ("修改密码".Equals(menu)) 修改密码.Visible = true;
                    else if ("上报健康".Equals(menu)) 上报健康.Visible = true;
                    else if ("健康上报记录".Equals(menu)) 健康上报记录.Visible = true;
                    else if ("学生健康管理".Equals(menu)) 学生健康管理.Visible = true;
                    else if ("身份管理".Equals(menu)) 身份管理.Visible = true;
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Response.Write(e.Message.ToString());
            }
        }
    }
}