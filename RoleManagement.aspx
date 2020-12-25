<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoleManagement.aspx.cs" Inherits="DormitoryManagement.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button class="btn" ID="Button1" runat="server" OnClick="Button1_Click" Text="增加身份" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" AllowPaging="True" OnRowCommand="GridView1_OnRowCommand">
                <Columns>
                    <asp:BoundField HeaderText="描述" DataField="description" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="del" HeaderText="操作" Text="删除" HeaderStyle-BackColor="Black" Visible="True">
                        <HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>

                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
