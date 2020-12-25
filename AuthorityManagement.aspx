<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorityManagement.aspx.cs" Inherits="DormitoryManagement.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">
            
            
            <asp:GridView Width="40%" ID="GridView1" runat="server" AutoGenerateColumns ="False" AllowPaging="True" OnRowCommand="GridView1_OnRowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="描述" DataField="description" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="del" HeaderText="操作" Text="勾选" HeaderStyle-BackColor="Black" Visible="True">
                        <HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>

                </Columns>
            </asp:GridView>

            <asp:GridView Width="40%" ID="GridView2" runat="server" AutoGenerateColumns ="False" AllowPaging="True" OnRowCommand="GridView1_OnRowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="描述" DataField="description" HeaderStyle-BackColor="#FF6699" >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="del" HeaderText="操作" Text="勾选" HeaderStyle-BackColor="Black" Visible="True">
                        <HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
