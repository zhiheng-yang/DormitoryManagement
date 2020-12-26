<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NoticeHistory.aspx.cs" Inherits="DormitoryManagement.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">
            <div>
                <table class="nav-justified" id="tableMain" style="border: thick solid #FF0000">
                    <tr>
                        <td>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" BorderColor="#3333FF">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="编号" HeaderStyle-BackColor="Fuchsia" >
<HeaderStyle BackColor="Fuchsia"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="description" HeaderText="公告内容" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="time" HeaderText="发布时间" HeaderStyle-BackColor="Red" />
                    <asp:BoundField DataField="user_id" HeaderText="发布人" HeaderStyle-BackColor="Lime" />
                </Columns>
            </asp:GridView>
                            </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text="公告内容："></asp:Label>
                            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            <asp:Button ID="btnFind" runat="server" Text="查询" class="btn" OnClick="btnFind_Click"/>
                        </td>
                    </tr>
                    </table>
            </div>
        </div>
    </div>

</asp:Content>
