<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="DormitoryManagement.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive" class="btn">
            <div>
            <asp:GridView ID="UserView" runat="server" AutoGenerateColumns="False" OnRowCommand ="GridView_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="用户名" HeaderStyle-BackColor="lime">
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="姓名" HeaderStyle-BackColor="blue">
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="description" HeaderText="角色身份" HeaderStyle-BackColor="red">
<HeaderStyle BackColor="Red"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="no" HeaderText="学号\工号" HeaderStyle-BackColor="lime">
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IDCard" HeaderText="身份证号" HeaderStyle-BackColor="blue">
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="contact" HeaderText="联系方式" HeaderStyle-BackColor="red">
<HeaderStyle BackColor="Red"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="aprt" HeaderText="公寓" HeaderStyle-BackColor="lime">
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="room_no" HeaderText="房间号" HeaderStyle-BackColor="red">
<HeaderStyle BackColor="Red"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" HeaderText="删除操作" Text="删除" HeaderStyle-BackColor="blue" CommandName="del">
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" HeaderText="修改操作" Text="修改" HeaderStyle-BackColor="lime" CommandName="upd">
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
          </div>
             <table class="nav-justified">
                <tr>
                    <td  style="vertical-align:middle; text-align:left;" colspan="8">
                        <asp:Button ID="btnAdd" runat="server" Text="新增用户" class="btn" OnClick="btnAdd_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="username1" runat="server" Text="用户名"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="name1" runat="server" Text="姓名"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="role1" runat="server" Text="角色身份"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="no1" runat="server" Text="学号/工号"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="IDcard1" runat="server" Text="身份证号"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="contact1" runat="server" Text="联系方式"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="build1" runat="server" Text="宿舍楼"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="room1" runat="server" Text="房间号"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="username2" runat="server"></asp:TextBox>
                        <asp:Label ID="username3" runat="server" Text="用户名"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="name2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="role2" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="no2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="IDCard2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="contact2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="build2" runat="server" MaintainScrollPositionOnPostback="True" OnSelectedIndexChanged="build2_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="room2" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    
                    <td colspan="8">
                        <asp:Button ID="btnUpdate" runat="server" Text="保存修改" class="btn" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnSubmit" runat="server" Text="确认提交" class="btn" OnClick="btnSubmit_Click"/>
                        <asp:Button ID="btnBack" runat="server" Text="退出" class="btn" OnClick="btnBack_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
