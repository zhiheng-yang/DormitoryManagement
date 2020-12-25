<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorityManagement.aspx.cs" Inherits="DormitoryManagement.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        float: left;
        width: 276px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbox">
        
        <div class="responsive" >
            <div>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label CssClass="btn btn-secondary" ID="Label1" runat="server" Text="选择身份：" ForeColor="Black"></asp:Label>
                        <asp:DropDownList CssClass="btn" ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnTextChanged="DropDownList1_TextChanged">
                         
            </asp:DropDownList>
            </div>
            <div style="margin-left:5%;width=20%;margin-right:10%" class="auto-style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF0055"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="所有权限" DataField="description" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="del" HeaderText="操作" Text="分配" HeaderStyle-BackColor="Black" Visible="True">
                        <HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>

                </Columns>
            </asp:GridView>
            </div>
            <asp:GridView Width="23%" ID="GridView2" runat="server" AutoGenerateColumns ="False" OnRowCommand="GridView2_RowCommand">
                <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="id" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF0055"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="拥有权限" DataField="description" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="del" HeaderText="操作" Text="取消分配" HeaderStyle-BackColor="Black" Visible="True">
                        <HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>

                </Columns>
            </asp:GridView>
          

          
        </div>
    </div>
</asp:Content>
