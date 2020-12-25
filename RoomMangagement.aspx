<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomMangagement.aspx.cs" Inherits="DormitoryManagement.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="mainbox">
       
        <div class="responsive">
            <div>
                <asp:Label ID="lblApart1" runat="server" Text="公寓楼编号" BackColor="White"></asp:Label>
                <asp:TextBox ID="txtApart1" runat="server"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="查询" OnClick="btnSelect_Click" />
                <asp:Button ID="addData" runat="server" OnClick="addData_Click" Text="增加" />
           </div>

            <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns ="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="公寓楼编号" SortExpression="apartment_id" DataField="apartment_id" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="宿舍房间编号" SortExpression="room_no" DataField="room_no"  HeaderStyle-BackColor="Yellow" >
<HeaderStyle BackColor="Yellow"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="宿舍最大人数" SortExpression="max" DataField="max" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="宿舍现有人数" SortExpression="num_peo" DataField="num_peo" HeaderStyle-BackColor="Aqua"  >
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="upData" HeaderText="操作" Text="修改" HeaderStyle-BackColor="Black" Visible="True">
<HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="deleteData" HeaderText="操作" Text="删除" HeaderStyle-BackColor="Black" Visible="True">
<HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
            <div>
                <asp:Panel ID="Panel1" runat="server" Height="194px" Visible="true">
                    <asp:Label ID="lblApart2" runat="server" Text="公寓楼编号" HeaderStyle-BackColor="white" BackColor="White"></asp:Label>
                    <asp:TextBox ID="txtApart2" runat="server"></asp:TextBox>
                    <asp:Label ID="lblRoom" runat="server" Text="房间编号" HeaderStyle-BackColor="white" BackColor="White"></asp:Label>
                    <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
                    <asp:Label ID="lblMax" runat="server" Text="最大人数" HeaderStyle-BackColor="white" BackColor="White"></asp:Label>
                    <asp:TextBox ID="txtMax" runat="server"></asp:TextBox>
                    <asp:Label ID="lblNum" runat="server" Text="现有人数" HeaderStyle-BackColor="white" BackColor="White"></asp:Label>
                    <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
                    <asp:Button ID="saveAdd" runat="server" Text="保存" HeaderStyle-BackColor="white"/>
                </asp:Panel>
                </div>
            </div>
       </div>
</asp:Content>
