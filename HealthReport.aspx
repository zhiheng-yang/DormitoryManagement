<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HealthReport.aspx.cs" Inherits="DormitoryManagement.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="mainbox" >
        <div class="responsive">
            
            <h1 style="color:white; width:100%;text-align:center " >个人健康上报</h1>
            
            <br />
            <table>
                <tr>
                    <td style="text-align:left " colspan="2">*早上体温情况</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButton ID="zaoti1" runat="server" GroupName="zao1" Text="正常37.2°及以下" />
                    </td>
                    <td>
                        <asp:RadioButton ID="zaoti2" runat="server" GroupName="zao1" Text="异常37.3°及以上" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left ">*早上身体健康状况</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButton ID="zaojian1" runat="server" GroupName="zao2" Text="健康" />
                    </td>
                    <td>
                        <asp:RadioButton ID="zaojian2" runat="server" GroupName="zao2" Text="有乏力、发热、干咳等呼吸道症状" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left ">*中午体温情况</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButton ID="wuti1" runat="server" GroupName="wu1" Text="正常37.2°及以下" />
                    </td>
                    <td>
                        <asp:RadioButton ID="wuti2" runat="server" GroupName="wu1" Text="异常37.3°及以上" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left ">*中午身体健康状况</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButton ID="wujian1" runat="server" GroupName="wu2" Text="健康" />
                    </td>
                    <td>
                        <asp:RadioButton ID="wujian2" runat="server" GroupName="wu2" Text="有乏力、发热、干咳等呼吸道症状" />
                    </td>
                </tr>
                <tr>
                     <td colspan="2" style="text-align:left ">*晚上体温情况</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButton ID="wanti1" runat="server" GroupName="wan1" Text="正常37.2°及以下" />
                    </td>
                    <td>
                        <asp:RadioButton ID="wanti2" runat="server" GroupName="wan1" Text="异常37.3°及以上" />
                    </td>
                </tr>
                <tr>
                     <td colspan="2" style="text-align:left ">*晚上身体健康状况</td>
                </tr>
                <tr>
                     <td class="auto-style1">
                         <asp:RadioButton ID="wanjian1" runat="server" GroupName="wan2" Text="健康" />
                     </td>
                    <td>
                        <asp:RadioButton ID="wanjian2" runat="server" Text="有乏力、发热、干咳等呼吸道症状" GroupName="wan2" />
                     </td>
                </tr>
            </table>
            <br />
            <br />
            <span style="text-align: center;display:block;"><asp:Button ID="Button1" runat="server" Text="提交" Height="30px" OnClick="Button1_Click" Width="100px" /></span>
        </div>
         
    </div>

</asp:Content>
