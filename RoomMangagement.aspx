<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomMangagement.aspx.cs" Inherits="DormitoryManagement.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin: 25px 0 0 0;
            height: 304px;
        }
        .auto-style3 {
            margin-bottom: 0;
        }
        .auto-style4 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="mainbox">
       
        <div class="auto-style2">
            <div>
                <asp:Label ID="lblApart1" runat="server" Text="公寓楼编号" BackColor="White"></asp:Label>
                <asp:TextBox ID="txtApart1" runat="server"></asp:TextBox>
                <asp:Button ID="btnSelect" runat="server" Text="查询" OnClick="btnSelect_Click" />
                <asp:Button ID="addData" runat="server" OnClick="addData_Click" Text="增加" />
           </div>

            <asp:GridView ID="GridView1" runat="server" CellPadding="4" AutoGenerateColumns ="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" Height="311px" CssClass="auto-style3" Width="1187px">
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
    <table>
        <tr>
            <td>
                <asp:Label ID="lblApart2" runat="server" Text="公寓楼编号"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApart2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblRoom" runat="server" Text="宿舍房间编号"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblMax" runat="server" Text="宿舍最大人数"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMax" runat="server"></asp:TextBox>
            </td>
             <td>
                 <asp:Label ID="lblNum" runat="server" Text="宿舍现有人数"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
            </td>
      </tr>
      <tr>
            <td>
                <asp:Button ID="saveAdd" runat="server" Text="保存" OnClick="saveAdd_Click"/>
            </td>
            <td>
                <asp:Button ID="cancelAdd" runat="server" OnClick="cancelAdd_Click" Text="退出" />
            </td>
        </tr>
   </table>
   <table >
       <tr>
           <td>
               <asp:Label ID="lblApart3" runat="server" Text="公寓楼编号"></asp:Label>
               </td>
             <td>
                 <asp:TextBox ID="txtApart3" runat="server"></asp:TextBox>
               </td>
             <td>
                 <asp:Label ID="lblRoom1" runat="server" Text="宿舍房间编号"></asp:Label>
               </td>
             <td>
                 <asp:TextBox ID="txtRoom1" runat="server"></asp:TextBox>
               </td>
             <td>
                 <asp:Label ID="lblMax1" runat="server" Text="最大人数"></asp:Label>
               </td>
             <td>
                 <asp:TextBox ID="txtMax1" runat="server"></asp:TextBox>
               </td>
           </tr>
         <tr>
           <td >
               <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"  CssClass="btn" Text="修改" />
               </td>
             <td rowspan="4">
                 <asp:Button ID="cancelUpdate" runat="server" OnClick="cancelUpdate_Click" Text="退出"  CssClass="btn btn-secondary"/>
               </td>
             <td></td>
             <td></td>
             <td></td>
             <td></td>
           </tr>
       </table>
    </div>
       </div>
</asp:Content>
