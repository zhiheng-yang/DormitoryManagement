<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NoticeManagement.aspx.cs" Inherits="DormitoryManagement.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive">
            <div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BorderColor="#3333FF" OnRowCommand ="GridView_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="编号" HeaderStyle-BackColor="Fuchsia" >
<HeaderStyle BackColor="Fuchsia"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="description" HeaderText="公告内容" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="time" HeaderText="发布时间" HeaderStyle-BackColor="Red" >
<HeaderStyle BackColor="Red"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="user_id" HeaderText="发布人" HeaderStyle-BackColor="Lime" >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" HeaderText="更改公告" Text="更改" HeaderStyle-BackColor="Yellow" CommandName="upData"/>
                    <asp:ButtonField ButtonType="Button" HeaderText="删除公告" Text="删除" HeaderStyle-BackColor="Aqua"  CommandName="deleteData"/>
                </Columns>
            </asp:GridView>
            </div>
            <table class="nav-justified">
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="编辑新增公告" class="btn" OnClick="btnAdd_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="退出" class="btn" OnClick="btnBack_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="公告内容："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="提交修改" class="btn" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnSubmit" runat="server" Text="发布公告" class="btn" OnClick="btnSubmit_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
