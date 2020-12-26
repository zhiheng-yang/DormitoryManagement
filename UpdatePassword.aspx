<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="DormitoryManagement.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="mainbox" >
        <div class="responsive">

            <table class="nav-justified">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="pass1" runat="server" Text="请输入新密码"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="p1" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="pass2" runat="server" Text="请再次输入新密码"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="p2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="passti" runat="server" OnClick="passti_Click" Text="提交" />
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>
