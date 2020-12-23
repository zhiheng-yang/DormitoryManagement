<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VisitorManagement.aspx.cs" Inherits="DormitoryManagement.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive" class="btn">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="担保人编号" SortExpression="guarantor" DataField="guarantor" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访人身份证号" SortExpression="IDCard" DataField="IDCard"  HeaderStyle-BackColor="Yellow" >
<HeaderStyle BackColor="Yellow"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访时间" SortExpression="begin_time" DataField="begin_time" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="离开时间" SortExpression="end_time" DataField="end_time" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="详情描述" SortExpression="description" DataField="description" HeaderStyle-BackColor="#CC00CC"  >
<HeaderStyle BackColor="#CC00CC"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="批准状态" SortExpression="isGranted" DataField="isGranted" HeaderStyle-BackColor="#3399FF"  >
<HeaderStyle BackColor="#3399FF"></HeaderStyle>
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" HeaderText="操作" ShowEditButton="True" HeaderStyle-BackColor="#CC00CC"/>
                </Columns>
    </asp:GridView>
            </div>
            </div>
</asp:Content>