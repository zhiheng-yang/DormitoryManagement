<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VisitRegistration.aspx.cs" Inherits="DormitoryManagement.WebForm9" %>
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
                        <asp:Button ID="btnRequest" runat="server" Text="填报申请" class="btn" OnClick="btnRequest_Click" />
                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                            <table class="nav-justified">
                                <tr>
                                    <td colspan="2" style="background: #e4644a;">
                                        <asp:Label ID="Label2" runat="server" Text="访问申请填写"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5"><span class="auto-style1">*</span><asp:Label ID="lblGuarantor" runat="server" CssClass="auto-style3" Text="担保人姓名"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:TextBox ID="txtGuarantor" runat="server" ForeColor="Black" CssClass="auto-style6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><span class="auto-style1">*</span><asp:Label ID="lblBeginTime" runat="server" CssClass="auto-style3" Text="来访时间"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBeginTime" runat="server" TextMode="DateTime" ForeColor="Black" CssClass="auto-style6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><span class="auto-style1">*</span><asp:Label ID="lblEndTime" runat="server" CssClass="auto-style3" Text="离开时间"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndTime" runat="server" TextMode="DateTime" ForeColor="Black" CssClass="auto-style6"></asp:TextBox>
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
                    <th style="background:#e4644a;">
                        <asp:Label ID="Label1" runat="server" Text="我的访问申请"></asp:Label>
                        <asp:CheckBox ID="cbUnGranted" runat="server" AutoPostBack="True" OnCheckedChanged="cbUnGranted_CheckedChanged" Text="只显示未批准" />
                    </th>
                </tr>
                <tr>
                    <th>



                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="guarantor" HeaderText="担保人" HeaderStyle-BackColor="Aqua" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="Aqua"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="begin_time" HeaderText="来访时间" HeaderStyle-BackColor="#6699FF" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="#6699FF"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="end_time" HeaderText="离开时间" HeaderStyle-BackColor="#6666FF" ItemStyle-ForeColor="Black" >
<HeaderStyle BackColor="#6666FF"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="description" HeaderText="详情描述" HeaderStyle-BackColor="#6600FF" ItemStyle-ForeColor="Black">
<HeaderStyle BackColor="#6600FF"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="isGranted" HeaderText="批准状态" HeaderStyle-BackColor="#6600CC" ItemStyle-ForeColor="Black">
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
