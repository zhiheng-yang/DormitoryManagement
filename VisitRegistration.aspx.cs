
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
    public partial class WebForm9 : System.Web.UI.Page
    {
        private const string strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
        private MySqlDataAdapter da;
        private string arrMsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
            SetName(GridView1);
            SetGrantedStatus(GridView1);
            SetTitle();
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


        private string GetCurrentIDCard()
        {
            string idCard = "";
            string userId = Session.Contents["id"].ToString();
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select IDCard from user where id = " + userId;
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                idCard = ds.Tables[0].Rows[0][0].ToString();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            return idCard;
        }

        private void FillGridView()
        {
            string userId = Session.Contents["id"].ToString();
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select * from visit_record where IDCard = " + GetCurrentIDCard();
                conn.Open();
                SqlAndGridView(conn, strSql, GridView1);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private void FillGridView_UnGranted()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "select * from visit_record where IDCard = " + GetCurrentIDCard() + " and isGranted = 0";
                conn.Open();
                SqlAndGridView(conn, strSql, GridView1);
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
                string strSql = str + gv.Rows[i].Cells[0].Text;
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.Rows[i].Cells[0].Text = ds.Tables[0].Rows[0][0].ToString();
            }

        }
        private void SetGrantedStatus(GridView gv)
        {
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                if (gv.Rows[i].Cells[4].Text.Equals("0"))
                {
                    gv.Rows[i].Cells[4].Text = "未被批准";
                }
                else if (gv.Rows[i].Cells[4].Text.Equals("1"))
                {
                    gv.Rows[i].Cells[4].Text = "已被批准";
                }
                //Response.Write("<script>alert(' " + gv.Rows[i].Cells[6].Text + " ');</script>");
            }

        }
        private void SetTitle()
        {
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "暂无申请";
                cbUnGranted.Visible = false;
            }
            else
            {
                Label1.Text = "我的访问申请";
                cbUnGranted.Visible = true;
            }
        }
        private int GetGuarantorId(string name)
        {
            int gId = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(strConnection);
                string strSql = "select id from user where name = \'" + name + "\'";
                //Response.Write("<script>alert(' " + strSql + " ');</script>");
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                da = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    gId = -1;
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }
            return gId;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckIfValid() == 1)
            {
                try
                {
                    string strSql = "insert into visit_record(guarantor,IDCard,begin_time,end_time,description,isGranted) values (\'"
                        + GetGuarantorId(txtGuarantor.Text) + "\',\'" + GetCurrentIDCard() + "\',\'" + txtBeginTime.Text + "\',\'" + txtEndTime.Text + "\',\'" + txtDescription.Text + "\',\'0\')";
                    Response.Write("<script>alert(' " + strSql + " ');</script>");
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    conn.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(strSql, conn);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    da = new MySqlDataAdapter(mySqlCommand);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    FillGridView();
                    SetName(GridView1);
                    SetGrantedStatus(GridView1);
                    SetTitle();

                }
                catch (MySqlException ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
            else
            {
                Response.Write(@"<script>alert(' " + arrMsg + " ');</script>");
            }
        }
        public int CheckIfValid()
        {
            //符合要求
            int isValid = 1;
            arrMsg = "";
            if (txtGuarantor.Text.Length == 0)
            {
                //输入为空
                isValid = 0;
                arrMsg += "担保人信息输入为空;";
            }
            else
            {
                if (GetGuarantorId(txtGuarantor.Text).ToString().Equals(Session.Contents["id"].ToString()))
                {
                    //输入的担保人为自己
                    isValid = -1;
                    arrMsg += "不能选自己为担保人;";
                }
                else if (GetGuarantorId(txtGuarantor.Text).ToString().Equals("-1"))
                {
                    isValid = -2;
                    arrMsg += "担保人不存在;";
                }
            }
            if (txtBeginTime.Text.Length != 19)
            {
                isValid = -4;
                arrMsg += "来访日期输入不正确;";
            }
            if (txtEndTime.Text.Length != 19)
            {
                isValid = -5;
                arrMsg += "离开日期输入不正确;";
                arrMsg += txtEndTime.Text.Length;
            }
            return isValid;
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == false)
            {
                Panel1.Visible = true;
            }
            else if (Panel1.Visible == true)
            {
                txtGuarantor.Text = "";
                txtGuarantor.Text = "";
                txtBeginTime.Text = "";
                txtEndTime.Text = "";
                txtDescription.Text = "";
                Panel1.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            txtGuarantor.Text = "";
            txtGuarantor.Text = "";
            txtBeginTime.Text = "";
            txtEndTime.Text = "";
            txtDescription.Text = "";
            Panel1.Visible = false;
        }

        protected void cbUnGranted_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnGranted.Checked == true)
            {
                FillGridView_UnGranted();
            }
            else
            {
                FillGridView();
            }
            SetName(GridView1);
            SetGrantedStatus(GridView1);
        }
    }

}
