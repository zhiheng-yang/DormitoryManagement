<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RepairApplication.aspx.cs" Inherits="DormitoryManagement.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style3 {
            color: #000000;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox">
        <div class="responsive">
            
            <table class="nav-justified">
                <tr>
                    <th>
                        
                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                            <table class="nav-justified">
                                <tr>
                                    <td colspan="2" style="background: #e4644a;">
                                        <asp:Label ID="Label2" runat="server" Text="申请维修"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescription" runat="server" CssClass="auto-style3" Text="详情描述"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine" ForeColor="Black" CssClass="auto-style6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn" OnClick="btnSubmit_Click" Text="提交" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnBack" runat="server" class="btn" OnClick="btnBack_Click" Text="返回" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </th>
                </tr>
                                <tr>
                    <th style="background:#e4644a;text-align:center">
                        
                        <asp:Label ID="Label1" runat="server" Text="我的维修申请"></asp:Label>
                        <asp:CheckBox ID="cbUnGranted" runat="server" AutoPostBack="True" OnCheckedChanged="cbUnGranted_CheckedChanged" Text="只显示未批准" />
                        <asp:Button style="margin-left:50%" ID="btnRequest" runat="server" Text="填报申请" class="btn" OnClick="btnRequest_Click" />
                    </th>
                </tr>
                <tr>
                    <th>



                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="room_no" HeaderText="宿舍号" HeaderStyle-BackColor="Aqua" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="time" HeaderText="申请时间" HeaderStyle-BackColor="#6699FF" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="#6699FF"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="description" HeaderText="详情描述" HeaderStyle-BackColor="#6600FF" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="#6600FF"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="isCompleted" HeaderText="批准状态" HeaderStyle-BackColor="#6600CC" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="#6600CC"></HeaderStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>



                    </th>
                </tr>
                </table>

        </div>
    </div>

</asp:Content>
