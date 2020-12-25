<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VisitorManagement.aspx.cs" Inherits="DormitoryManagement.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive">
            <table class="nav-justified" id="tableMain" style="border: thick solid #FF0000">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red" Text="来访申请审批"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged1" OnRowCommand="GridView2_OnRowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="担保人" DataField="guarantor" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访人身份证号" DataField="IDCard"  HeaderStyle-BackColor="Yellow" >
<HeaderStyle BackColor="Yellow"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访时间" DataField="begin_time" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="离开时间" DataField="end_time" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="详情描述" DataField="description" HeaderStyle-BackColor="#CC00CC"  >
<HeaderStyle BackColor="#CC00CC"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="批准状态" DataField="isGranted" HeaderStyle-BackColor="#3399FF"  >
<HeaderStyle BackColor="#3399FF"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="grant" HeaderText="操作" Text="批准" HeaderStyle-BackColor="Black" Visible="True">
<HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>
                </Columns>
    </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="Black" Text="来访记录总表"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="担保人" DataField="guarantor" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访人身份证号" DataField="IDCard"  HeaderStyle-BackColor="Yellow" >
<HeaderStyle BackColor="Yellow"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="来访时间" DataField="begin_time" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="离开时间" DataField="end_time" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="详情描述" DataField="description" HeaderStyle-BackColor="#CC00CC"  >
<HeaderStyle BackColor="#CC00CC"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="批准状态" DataField="isGranted" HeaderStyle-BackColor="#3399FF"  >
<HeaderStyle BackColor="#3399FF"></HeaderStyle>
                    </asp:BoundField>
                </Columns>
    </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
            </div>

</asp:Content>