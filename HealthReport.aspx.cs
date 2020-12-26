using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagement
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        private MySqlCommand da;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            String bao1 = "", bao2 = "", bao3 = "", bao4 = "", bao5 = "", bao6 = "";
            if (zaoti1.Checked || zaoti2.Checked)
            {
                if (zaoti1.Checked)
                {
                    bao1 = "正常";
                }
                else
                {
                    bao1 = "异常";
                }
                cnt++;
            }
            if (zaojian1.Checked || zaojian2.Checked)
            {
                if (zaojian1.Checked)
                {
                    bao2 = "正常";
                }
                else
                {
                    bao2 = "异常";
                }
                cnt++;
            }
            if (wuti1.Checked || wuti2.Checked)
            {
                if (wuti1.Checked)
                {
                    bao3 = "正常";
                }
                else
                {
                    bao3 = "异常";
                }
                cnt++;
            }
            if (wujian1.Checked || wujian2.Checked)
            {
                if (wujian1.Checked)
                {
                    bao4 = "正常";
                }
                else
                {
                    bao4 = "异常";
                }
                cnt++;
            }
            if (wanti1.Checked || wanti2.Checked)
            {
                if (wanti1.Checked)
                {
                    bao5 = "正常";
                }
                else
                {
                    bao5 = "异常";
                }
                cnt++;
            }
            if (wanjian1.Checked || wanjian2.Checked)
            {
                if (wanjian1.Checked)
                {
                    bao6 = "正常";
                }
                else
                {
                    bao6 = "异常";
                }
                cnt++;
            }
            if (cnt != 6)
            {
                Response.Write(@"<script>alert('请完成健康信息填报！');</script>");
                System.Diagnostics.Debug.Write(cnt);
                return;
            }
            //记得删
            String sql = "insert into health_record(user_id,time,health_zao1,health_zao2,health_zhong1,health_zhong2,health_wan1,health_wan2" +
                ") values (";
            sql += Session.Contents["id"] + ",";
            sql += "curdate(),";
            sql += "\'" + bao1 + "\',";
            sql += "\'" + bao2 + "\',";
            sql += "\'" + bao3 + "\',";
            sql += "\'" + bao4 + "\',";
            sql += "\'" + bao5 + "\',";
            sql += "\'" + bao6 + "\')";
            System.Diagnostics.Debug.Write(sql);
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                da = new MySqlCommand(sql, conn);
                int result = da.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("数据库影响行数，健康记录添加：" + cnt + "\n");
                // MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                conn.Close();
                Response.Write(@"<script>alert('上报成功');</script>");
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                Response.Write(@"<script>alert('你今天已经上报过了');</script>");
            }
        }

    }
}