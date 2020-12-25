<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HealthHistory.aspx.cs" Inherits="DormitoryManagement.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">
            <asp:GridView ID="HealHis" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="True" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="time" HeaderText="日期" HeaderStyle-BackColor="lime"/>
                    <asp:BoundField DataField="health_zao1" HeaderText="早上的体温情况"  HeaderStyle-BackColor="blue"/>
                    <asp:BoundField DataField="health_zao2" HeaderText="早上健康状况" HeaderStyle-BackColor="red"/>
                    <asp:BoundField DataField="health_zhong1" HeaderText="中午的体温情况" HeaderStyle-BackColor="blue"/>
                    <asp:BoundField DataField="health_zhong2" HeaderText="中午健康状况" HeaderStyle-BackColor="lime"/>
                    <asp:BoundField DataField="health_wan1" HeaderText="晚上的体温情况" HeaderStyle-BackColor="blue"/>
                    <asp:BoundField DataField="health_wan2" HeaderText="晚上健康状况" HeaderStyle-BackColor="red"/>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </div>
            </div>

</asp:Content>
