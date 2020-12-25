<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomInfo.aspx.cs" Inherits="DormitoryManagement.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="mainbox">
        <div class="responsive">

            <asp:GridView ID="GridView1" runat="server"  CellPadding="4" AutoGenerateColumns ="False">
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="用户编号" SortExpression="role_id" DataField="role_id" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="用户名" SortExpression="username" DataField="username"  HeaderStyle-BackColor="Yellow" >
<HeaderStyle BackColor="Yellow"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="密码" SortExpression="password" DataField="password" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="姓名" SortExpression="name" DataField="name" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="学号" SortExpression="no" DataField="no" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="身份证号" SortExpression="IDCard" DataField="IDCard" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="电话" SortExpression="contact" DataField="contact" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>

                </Columns>

            </asp:GridView>

            </div>
       </div>
</asp:Content>
