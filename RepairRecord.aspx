<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RepairRecord.aspx.cs" Inherits="DormitoryManagement.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" AllowPaging="True" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="编号" SortExpression="id" DataField="id" HeaderStyle-BackColor="Blue" >
<HeaderStyle BackColor="Blue"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="维修宿舍号" DataField="room_no" HeaderStyle-BackColor="#FF6699"  >
<HeaderStyle BackColor="#FF6699"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="申请时间" DataField="time" HeaderStyle-BackColor="Lime"  >
<HeaderStyle BackColor="Lime"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="详情描述" DataField="description" HeaderStyle-BackColor="#CC00CC"  >
<HeaderStyle BackColor="#CC00CC"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="批准状态" DataField="isCompleted" HeaderStyle-BackColor="#3399FF"  >
<HeaderStyle BackColor="#3399FF"></HeaderStyle>
                    </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="grant" HeaderText="操作" Text="维修完成" HeaderStyle-BackColor="Black" Visible="True">
<HeaderStyle BackColor="Black"></HeaderStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
            </div>
            </div>
</asp:Content>
