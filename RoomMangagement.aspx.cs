using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DormitoryManagement
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        private static int updateId;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblApart2.Visible = false;
            txtApart2.Visible = false;
            lblRoom.Visible = false;
            txtRoom.Visible = false;
            lblMax.Visible = false;
            txtMax.Visible = false;
            lblNum.Visible = false;
            txtNum.Visible = false;
            saveAdd.Visible = false;
            cancelAdd.Visible = false;

            lblApart3.Visible = false;
            txtApart3.Visible = false;
            lblRoom1.Visible = false;
            txtRoom1.Visible = false;
            lblMax1.Visible = false;
            txtMax1.Visible = false;
            btnUpdate.Visible = false;
            cancelUpdate.Visible = false;



            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "SELECT * FROM room";
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
                //建立DataSet对象(相当于建立前台的虚拟数据库)
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 aID = Int16.Parse(txtApart1.Text.ToString());

                if (aID > 7 || aID < 1)
                {
                    Response.Write(@"<script>alert('没有这个宿舍楼！');</script>");
                    return;
                }
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True";
                string res = "SELECT id,apartment_id,room_no,max,num_peo FROM room WHERE ( apartment_id like '%" + txtApart1.Text.ToString() + "%') Order by id Desc";
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                da = new MySqlDataAdapter(res, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                bind_gridview();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(@"<script>alert('查询失败！');</script>");
                //Response.Write(ex.Message.ToString());
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            String id = GridView1.Rows[index].Cells[0].Text;
            if (e.CommandName == "deleteData")
            {

                try
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "DELETE FROM room WHERE id = @id";
                    //使用MySqlParameter定义表中各列的值
                    MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = strSql;
                    cmd.Parameters.AddRange(parameters);
                    DataSet ds = new DataSet();
                    da = new MySqlDataAdapter(cmd);
                    //将删除的结果存到虚拟数据库ds中
                    da.Fill(ds);
                    cmd.CommandText = "SELECT * FROM room";
                    bind_gridview();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    Response.Write(@"<script>alert('删除失败！');</script>");
                    //Response.Write(ex.Message.ToString());
                }
            }
            //修改
            if (e.CommandName == "upData")
            {

                lblApart3.Visible = true;
                txtApart3.Visible = true;
                txtApart3.Text = GridView1.Rows[index].Cells[1].Text;
                lblRoom1.Visible = true;
                txtRoom1.Visible = true;
                txtRoom1.Text = GridView1.Rows[index].Cells[2].Text;
                lblMax1.Visible = true;
                txtMax1.Visible = true;
                txtMax1.Text = GridView1.Rows[index].Cells[3].Text;
                btnUpdate.Visible = true;
                cancelUpdate.Visible = true;
                updateId = Int32.Parse(id);
            }

        }

        protected void addData_Click(object sender, EventArgs e)
        {
            lblApart2.Visible = true;
            txtApart2.Visible = true;
            lblRoom.Visible = true;
            txtRoom.Visible = true;
            lblMax.Visible = true;
            txtMax.Visible = true;
            lblNum.Visible = true;
            txtNum.Visible = true;
            saveAdd.Visible = true;
            cancelAdd.Visible = true;

        }

        protected void cancelAdd_Click(object sender, EventArgs e)
        {
            lblApart2.Visible = false;
            txtApart2.Visible = false;
            lblRoom.Visible = false;
            txtRoom.Visible = false;
            lblMax.Visible = false;
            txtMax.Visible = false;
            lblNum.Visible = false;
            saveAdd.Visible = false;
            cancelAdd.Visible = false;

        }
        protected void saveAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "INSERT INTO room(apartment_id,room_no,max,num_peo) VALUES (@apartment_id,@room_no,@max,@num_peo)";
                MySqlParameter[] parameters = { new MySqlParameter("@apartment_id", txtApart2.Text),
                                                new MySqlParameter("@room_no", txtRoom.Text),
                                                new MySqlParameter("@max", txtMax.Text),
                                                new MySqlParameter("@num_peo", lblNum.Text) };
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strSql;
                cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.CommandText = "SELECT * FROM room";
                da = new MySqlDataAdapter(cmd);
                bind_gridview();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(@"<script>alert('数据无效！');</script>");
                // Response.Write(ex.Message.ToString());
            }
            lblApart2.Visible = false;
            txtApart2.Visible = false;
            lblRoom.Visible = false;
            txtRoom.Visible = false;
            lblMax.Visible = false;
            txtMax.Visible = false;
            lblNum.Visible = false;
            saveAdd.Visible = false;
            cancelAdd.Visible = false;

        }

        protected void cancelUpdate_Click(object sender, EventArgs e)
        {
            lblApart3.Visible = false;
            txtApart3.Visible = false;
            lblRoom1.Visible = false;
            txtRoom1.Visible = false;
            lblMax1.Visible = false;
            txtMax1.Visible = false;
            btnUpdate.Visible = false;
            cancelUpdate.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "UPDATE room SET apartment_id = @apartment_id,room_no= @room_id,max =  @max  WHERE id= @id";
                MySqlParameter[] parameters = { new MySqlParameter("@apartment_id", txtApart3.Text),
                                                new MySqlParameter("@room_id",txtRoom1.Text),
                                                new MySqlParameter("@max", txtMax1.Text),
                                                new MySqlParameter("@id", updateId)};
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strSql;
                cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.CommandText = "SELECT * FROM room";
                da = new MySqlDataAdapter(cmd);
                bind_gridview();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(@"<script>alert('数据无效！');</script>");
                //Response.Write(ex.Message.ToString());
            }
            lblApart3.Visible = false;
            txtApart3.Visible = false;
            lblRoom1.Visible = false;
            txtRoom1.Visible = false;
            lblMax1.Visible = false;
            txtMax1.Visible = false;
            btnUpdate.Visible = false;
            cancelUpdate.Visible = false;
        }
    }
}


