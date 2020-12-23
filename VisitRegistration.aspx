<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VisitRegistration.aspx.cs" Inherits="DormitoryManagement.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: smaller;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">

            <table class="nav-justified">
                <tr>
                    <th style="background:#e4644a;" colspan ="2">来访申请填报</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblGuarantor" runat="server" Text="担保人"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGuarantor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIDCard" runat="server" Text="身份证号码"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIDCard" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBeginTime" runat="server" Text="来访时间"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBeginTime" runat="server" TextMode="DateTime"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEndTime" runat="server" Text="离开时间"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndTime" runat="server" TextMode="DateTime"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="详情描述"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" class="btn" OnClick="btnSubmit_Click"/>
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="返回" class="btn"/>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

