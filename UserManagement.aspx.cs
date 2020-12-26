using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DormitoryManagement
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        private MySqlDataAdapter da;
        private MySqlCommand da1;
        private static String[] builds = new string[55];
        private static int[] builds_id = new int[55];
        private static String[] roles = new string[55];
        private static int[] roles_id = new int[55];
        private static String[] rooms = new string[505];
        private static int[] rooms_id = new int[505];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "";
                //记得删除

                conn.Open();
                //查公寓号
                strSql = "SELECT apartment.id FROM apartment,user, room, room_user " +
                    "where user.id = room_user.user_id and room_user.room_id = room.id  and " +
                    "apartment.id = room.apartment_id  and user.id = ";
                strSql += Session.Contents["id"];
                System.Diagnostics.Debug.Write("获取所在宿舍楼id的sql语句:" + strSql + "\n");
                da = new MySqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int deparId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (Session.Contents["role_id"].Equals("1"))
                {
                    strSql = "select username,user.name,description,no,IDCard,contact,apartment.name as aprt," +
                    "room_no from user, apartment, room, room_user, role " +
                    "where user.id = room_user.user_id and room_user.room_id = room.id" +
                    " and role.id = user.role_id " +
                    "and apartment.id = room.apartment_id and role.id != 1 ";
                }
                else
                {
                    strSql = "select username,user.name,description,no,IDCard,contact,apartment.name as aprt," +
                        "room_no from user, apartment, room, room_user, role " +
                        "where user.id = room_user.user_id and room_user.room_id = room.id" +
                        " and role.id = user.role_id " +
                        "and apartment.id = room.apartment_id and role.id != 1 and apartment.id = ";
                    strSql += deparId;
                }
                da = new MySqlDataAdapter(strSql, conn);
                bind_gridview();
                strSql = "select id,description from role";
                da = new MySqlDataAdapter(strSql, conn);
                bind_role();
                strSql = "select id,name from apartment";
                da = new MySqlDataAdapter(strSql, conn);
                bind_part();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

            username1.Visible = false;
            username2.Visible = false;
            username3.Visible = false;
            name1.Visible = false;
            name2.Visible = false;
            role1.Visible = false;
            role2.Visible = false;
            no1.Visible = false;
            no2.Visible = false;
            IDcard1.Visible = false;
            IDCard2.Visible = false;
            contact1.Visible = false;
            contact2.Visible = false;
            build1.Visible = false;
            build2.Visible = false;
            room1.Visible = false;
            room2.Visible = false;
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;

            //role2.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
        }
        private void bind_part()
        {
            build2.Items.Clear();
            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    builds_id[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    builds[i] = Convert.ToString(ds.Tables[0].Rows[i][1]);
                    System.Diagnostics.Debug.Write(roles_id[i] + "\n");
                    System.Diagnostics.Debug.Write(roles[i] + "\n");
                    build2.Items.Add(new ListItem(Convert.ToString(ds.Tables[0].Rows[i][1])));
                }
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private void bind_role()
        {
            role2.Items.Clear();
            try
            {

                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    roles_id[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    //Int32.Parse(Convert.ToString(ds.Tables[0].Rows[i][0]));
                    roles[i] = Convert.ToString(ds.Tables[0].Rows[i][1]);
                    System.Diagnostics.Debug.Write(roles_id[i] + "\n");
                    System.Diagnostics.Debug.Write(roles[i] + "\n");
                    role2.Items.Add(new ListItem(Convert.ToString(ds.Tables[0].Rows[i][1])));
                }
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
                UserView.DataSource = ds.Tables[0].DefaultView;
                UserView.DataBind();

            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private void bind_room(String build)
        {
            room2.Items.Clear();
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                String strSql = "Select room.id,room_no from room,apartment where apartment.id = room.apartment_id and apartment.name = '" + build + "'";
                conn.Open();
                da = new MySqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    rooms_id[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    //Int32.Parse(Convert.ToString(ds.Tables[0].Rows[i][0]));
                    rooms[i] = Convert.ToString(ds.Tables[0].Rows[i][1]);
                    System.Diagnostics.Debug.Write("room==" + rooms_id[i] + "\n");
                    System.Diagnostics.Debug.Write(rooms[i] + "\n");
                    room2.Items.Add(new ListItem(Convert.ToString(ds.Tables[0].Rows[i][1])));
                }
            }
            catch (MySqlException ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }
        private static int ind;
        private static int r_id;
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Int32.Parse(e.CommandArgument.ToString());
            ind = index;
            System.Diagnostics.Debug.Write("index" + index + "\n");
            String username = UserView.Rows[index].Cells[0].Text;
            System.Diagnostics.Debug.Write(username);
            r_id = getRoomId(UserView.Rows[index].Cells[7].Text);
            if (e.CommandName == "del")
            {
                try
                {
                    String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(strConnection);
                    String strSql = "DELETE FROM user WHERE username = '" + username + "'";
                    System.Diagnostics.Debug.Write(strSql + "\n");
                    conn.Open();
                    da1 = new MySqlCommand(strSql, conn);
                    int result = da1.ExecuteNonQuery();
                    System.Diagnostics.Debug.Write("数据库影响行数，健康记录添加：" + result + "\n");

                    //获得现在住的宿舍的人数
                    strSql = "Select num_peo from room where id = " + r_id + "";
                    System.Diagnostics.Debug.Write("66666666666666666666:" + strSql + "\n");
                    da = new MySqlDataAdapter(strSql, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int num_peo1 = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    num_peo1--;


                    //改原来的宿舍人数
                    String sql = "update room set num_peo = " + num_peo1 + " where id = " + r_id;
                    System.Diagnostics.Debug.Write("111111111111111:" + sql + "\n");
                    da1 = new MySqlCommand(sql, conn);
                    result = da1.ExecuteNonQuery();
                    System.Diagnostics.Debug.Write("11111111111改原来的宿舍人数行数：" + result + "\n");

                    conn.Close();
                    Response.Redirect("UserManagement.aspx");
                }
                catch (MySqlException ex)
                {
                    Response.Write(@"<script>alert('不能删除该用户！');</script>");
                    Response.Write(ex.Message.ToString());
                }
            }
            if (e.CommandName == "upd")
            {
                username1.Visible = true;
                username2.Visible = false;
                username3.Visible = true;
                name1.Visible = true;
                name2.Visible = true;
                role1.Visible = true;
                role2.Visible = true;
                no1.Visible = true;
                no2.Visible = true;
                IDcard1.Visible = true;
                IDCard2.Visible = true;
                contact1.Visible = true;
                contact2.Visible = true;
                build1.Visible = true;
                build2.Visible = true;
                room1.Visible = true;
                room2.Visible = true;
                btnUpdate.Visible = true;
                btnBack.Visible = true;
                btnSubmit.Visible = false;
                room2.Items.Clear();
                username3.Text = UserView.Rows[index].Cells[0].Text;
                name2.Text = UserView.Rows[index].Cells[1].Text;
                role2.ClearSelection();
                role2.Items.FindByText(UserView.Rows[index].Cells[2].Text).Selected = true;
                no2.Text = UserView.Rows[index].Cells[3].Text;
                IDCard2.Text = UserView.Rows[index].Cells[4].Text;
                contact2.Text = UserView.Rows[index].Cells[5].Text;
                build2.ClearSelection();
                build2.Items.FindByText(UserView.Rows[index].Cells[6].Text).Selected = true;
                bind_room(UserView.Rows[index].Cells[6].Text);
                room2.ClearSelection();
                room2.Items.FindByText(UserView.Rows[index].Cells[7].Text).Selected = true;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            username1.Visible = true;
            username2.Visible = true;
            username3.Visible = false;
            name1.Visible = true;
            name2.Visible = true;
            role1.Visible = true;
            role2.Visible = true;
            no1.Visible = true;
            no2.Visible = true;
            IDcard1.Visible = true;
            IDCard2.Visible = true;
            contact1.Visible = true;
            contact2.Visible = true;
            build1.Visible = true;
            build2.Visible = true;
            room1.Visible = true;
            room2.Visible = true;
            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            btnBack.Visible = true;
            room2.Items.Clear();
            username3.Text = "";
            name2.Text = "";
            role2.ClearSelection();
            no2.Text = "";
            IDCard2.Text = "";
            contact2.Text = "";
            build2.ClearSelection();
            room2.ClearSelection();
            bind_room("松园一号楼");
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            username1.Visible = false;
            username2.Visible = false;
            username3.Visible = false;
            name1.Visible = false;
            name2.Visible = false;
            role1.Visible = false;
            role2.Visible = false;
            no1.Visible = false;
            no2.Visible = false;
            IDcard1.Visible = false;
            IDCard2.Visible = false;
            contact1.Visible = false;
            contact2.Visible = false;
            build1.Visible = false;
            build2.Visible = false;
            room1.Visible = false;
            room2.Visible = false;
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            String sql = "";
            String strSql = "";
            try
            {

                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                //获得现在住的宿舍的人数
                strSql = "Select max,num_peo from room where id = " + r_id + "";
                //  System.Diagnostics.Debug.Write("获取宿舍人数的sql语句:" + strSql + "\n");
                da = new MySqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int num_peo1 = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                num_peo1--;

                //获得要搬去宿舍的人数，空余人数
                strSql = "Select max,num_peo from room where id = " + getRoomId(room2.SelectedValue) + "";
                // System.Diagnostics.Debug.Write("获取宿舍人数的sql语句:" + sql + "\n");
                da = new MySqlDataAdapter(strSql, conn);
                ds = new DataSet();
                da.Fill(ds);
                int num = Convert.ToInt32(ds.Tables[0].Rows[0][0]) - Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                int num_peo2 = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                if (num <= 0)
                {
                    conn.Close();
                    Response.Write(@"<script>alert('该宿舍人数已经满了，不能入住');</script>");
                    return;
                }

                //改user表;
                sql = "update user set role_id = " + getRoleId(role2.SelectedValue) + "" +
               ", name= '" + name2.Text + "',no='" + no2.Text + "',IDCard='" + IDCard2.Text + "',contact='" + contact2.Text +
               "' where username = '" + username3.Text + "'";
                da1 = new MySqlCommand(sql, conn);
                int result = da1.ExecuteNonQuery();
                // System.Diagnostics.Debug.Write("修改用户,数据库影响行数，健康记录添加：" + result + "\n");

                //查用户id
                strSql = "Select id from user where username = '" + username3.Text + "'";
                //System.Diagnostics.Debug.Write("获取id的sql语句:" + sql+"\n");
                da = new MySqlDataAdapter(strSql, conn);
                ds = new DataSet();
                da.Fill(ds);
                int user_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                //改住宿表;
                sql = "update room_user set room_id = " + getRoomId(room2.SelectedValue) + " where user_id = " + user_id;
                System.Diagnostics.Debug.Write("修改住宿表的sql语句:" + sql);
                da1 = new MySqlCommand(sql, conn);
                result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("修改住宿数据库影响行数：" + result + "\n");

                //改原来的宿舍人数
                sql = "update room set num_peo = " + num_peo1 + " where id = " + r_id;
                System.Diagnostics.Debug.Write("111111111111111:" + sql + "\n");
                da1 = new MySqlCommand(sql, conn);
                result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("11111111111改原来的宿舍人数行数：" + result + "\n");

                //改新的宿舍人数
                num_peo2 = num_peo2 + 1;
                sql = "update room set num_peo = " + num_peo2 + " where id = " + getRoomId(room2.SelectedValue);
                System.Diagnostics.Debug.Write("2222222222222222222222:" + sql + "\n");
                da1 = new MySqlCommand(sql, conn);
                result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("2222222222222222222222增加住宿人数行数，健康记录添加：" + result + "\n");

                conn.Close();
                Response.Write(@"<script>alert('修改用户信息成功');</script>");
                Response.Redirect("UserManagement.aspx");
            }
            catch
            {
                System.Diagnostics.Debug.Write("sql出错了！！！！！！！！！！！！！\n");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            username1.Visible = false;
            username2.Visible = false;
            username3.Visible = false;
            name1.Visible = false;
            name2.Visible = false;
            role1.Visible = false;
            role2.Visible = false;
            no1.Visible = false;
            no2.Visible = false;
            IDcard1.Visible = false;
            IDCard2.Visible = false;
            contact1.Visible = false;
            contact2.Visible = false;
            build1.Visible = false;
            build2.Visible = false;
            room1.Visible = false;
            room2.Visible = false;
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            String sql = "";
            String strSql = "";
            try
            {
                String strConnection = "server=49.234.112.12;port=3306;user=root;password=122316;database=gongyu;Charset=utf8;Allow Zero Datetime=True;";
                MySqlConnection conn = new MySqlConnection(strConnection);
                conn.Open();
                //查要住的宿舍，空余人数
                strSql = "Select max,num_peo from room where id = " + getRoomId(room2.SelectedValue) + "";
                System.Diagnostics.Debug.Write("获取宿舍人数的sql语句:" + sql + "\n");
                da = new MySqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int num = Convert.ToInt32(ds.Tables[0].Rows[0][0]) - Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                int num_peo = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                if (num <= 0)
                {
                    conn.Close();
                    Response.Write(@"<script>alert('该宿舍人数已经满了，不能入住');</script>");
                    return;
                }


                //改user表;初始密码为身份证号
                sql = "insert into user (role_id,username,password,name,no,IDCard,contact) " +
                    "values (" + getRoleId(role2.SelectedValue) + ",'" + username2.Text + "'" +
                    ",'" + IDCard2.Text + "','" + name2.Text + "','" + no2.Text + "','" + IDCard2.Text + "','" + contact2.Text + "')";
                System.Diagnostics.Debug.Write("增加用户,数据库sql1：" + role2.SelectedValue + "\n");
                System.Diagnostics.Debug.Write("增加用户,数据库sql2：" + roles[1] + "\n");
                System.Diagnostics.Debug.Write("增加用户,数据库sql3：" + sql + "\n");
                da1 = new MySqlCommand(sql, conn);
                int result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("增加用户,数据库影响行数，健康记录添加：" + result + "\n");

                //查用户id
                strSql = "Select id from user where username = '" + username2.Text + "'";
                System.Diagnostics.Debug.Write("获取id的sql语句:" + sql + "\n");
                da = new MySqlDataAdapter(strSql, conn);
                ds = new DataSet();
                da.Fill(ds);
                int user_id = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                //改住宿表;
                sql = "insert into room_user(room_id,user_id) values (" + getRoomId(room2.SelectedValue) + "," + user_id + ")";
                System.Diagnostics.Debug.Write("增加住宿表的sql语句:" + sql);
                da1 = new MySqlCommand(sql, conn);
                result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("增加住宿数据库影响行数，健康记录添加：" + result + "\n");

                //改room表人数;
                sql = "update room set num_peo = " + (num_peo + 1) + " where id = " + getRoomId(room2.SelectedValue);
                System.Diagnostics.Debug.Write("增加住宿表的sql语句:" + sql);
                da1 = new MySqlCommand(sql, conn);
                result = da1.ExecuteNonQuery();
                System.Diagnostics.Debug.Write("增加住宿人数行数，健康记录添加：" + result + "\n");

                //增加成功
                conn.Close();
                Response.Write(@"<script>alert('增加用户成功');</script>");
                Response.Redirect("UserManagement.aspx");
            }
            catch
            {
                System.Diagnostics.Debug.Write("sql出错了！！！！！！！！！！！！！\n");
            }
        }

        public int getRoomId(String s)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (s.Equals(rooms[i]))
                {
                    return rooms_id[i];
                }
            }
            return 0;
        }
        public int getRoleId(String s)
        {
            for (int i = 0; i < roles.Length; i++)
            {
                /*System.Diagnostics.Debug.Write("dayin2:" + roles[i] + "\n");
                System.Diagnostics.Debug.Write("dayin2:" + s + "\n");
                System.Diagnostics.Debug.Write("dayin2:" + roles_id[i] + "\n");*/
                if (s.Equals(roles[i]))
                {
                    return roles_id[i];
                }
            }
            return 0;
        }
        public int getBuildId(String s)
        {
            for (int i = 0; i < builds.Length; i++)
            {
                if (s.Equals(builds[i]))
                {
                    return builds_id[i];
                }
            }
            return 0;
        }

        protected void build2_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Write("11111111111111111111111111111\n");
            bind_room(build2.SelectedValue);
        }
        /*
         * 读取所有字段，赋值，insert user表，和room表
         */
        protected void btnBack_Click(object sender, EventArgs e)
        {
            username1.Visible = false;
            username2.Visible = false;
            username3.Visible = false;
            name1.Visible = false;
            name2.Visible = false;
            role1.Visible = false;
            role2.Visible = false;
            no1.Visible = false;
            no2.Visible = false;
            IDcard1.Visible = false;
            IDCard2.Visible = false;
            contact1.Visible = false;
            contact2.Visible = false;
            build1.Visible = false;
            build2.Visible = false;
            room1.Visible = false;
            room2.Visible = false;
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;

        }
    }
}