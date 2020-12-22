<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="example.aspx.cs" Inherits="DormitoryManagement.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainbox">
        <div class="responsive">
            <asp:Textbox ID="Button1" runat="server" Text="Button" class="btn" Width="82px"/>
            <asp:Textbox ID="Button2" runat="server" Text="Button" class="btn btn-secondary" Width="78px" />
            <asp:Label ID="Label1" runat="server" Text="Label" class="btn"></asp:Label>
            <br />
            <table>
            <tbody>
                <tr>
                    <th style="background:#e4644a;">服务器年费套餐</th>
                    <th style="background:#8035fb;border-right:2px solid #fff;">至尊版<span style="display:block;font-size:12px; line-height:1em; font-weight:normal;">(品牌加盟推荐型)</span></th>
                    <th style="background:#eb4848;border-right:2px solid #fff;">营销版</th>
                    <th style="background:#f37815;border-right:2px solid #fff;">标准版</th>
                    <th style="background:#fe0597;border-right:2px solid #fff;">基础版</th>
                    <th style="background:#35c6f0;">展示版</th>
                </tr>
                <tr>
                    <td>费用（元/年）</td>
                    <td class="red">3880</td>
                    <td class="red">2880</td>
                    <td class="red">1880</td>
                    <td class="red">980</td>
                    <td class="red"><asp:Textbox ID="Button3" runat="server" Text="Button" class="btn" Width="82px"/></td>
                </tr>
                <tr>
                    <td>上传文件个数</td>
                    <td>60000</td>
                    <td>60000</td>
                    <td>15000</td>
                    <td>7000</td>
                    <td>200</td>
                </tr>
                <tr>
                    <td>企业动态网站</td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                </tr>
                <tr>
                    <td>去除底部版权</td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td>/</td>
                    <td>/</td>
                </tr>
                <tr>
                    <td>百度小程序</td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td>/</td>
                    <td>/</td>
                    <td>/</td>
                </tr>
                <tr>
                    <td>二级域名</td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                </tr>
                <tr>
                    <td>赠英文.com域名1个</td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                    <td><span class="gou"></span></td>
                </tr>
                <tr>
                    <td>空间大小</td>
                    <td>6G</td>
                    <td>8G</td>
                    <td>15G</td>
                    <td>30G</td>
                    <td>30G</td>
                </tr>
                <tr>
                    <td>赠送.shop域名1个</td>
                    <td>首年</td>
                    <td>首年</td>
                    <td>首年</td>
                    <td>首年</td>
                    <td>首年</td>
                </tr>
                <tr>
                    <td>页面个数</td>
                    <td style="box-shadow: #8035fb 0px 6px 0px; border-radius:0px 0px 5px 5px;padding-bottom:8px;">不限</td>
                    <td style="box-shadow: #eb4848 0px 6px 0px; border-radius:0px 0px 5px 5px;padding-bottom:8px;">不限</td>
                    <td style="box-shadow: #f37815 0px 6px 0px; border-radius:0px 0px 5px 5px;padding-bottom:8px;">不限</td>
                    <td style="box-shadow: #fe0597 0px 6px 0px; border-radius:0px 0px 5px 5px;padding-bottom:8px;">10</td>
                    <td style="box-shadow: #35c6f0 0px 6px 0px; border-radius:0px 0px 5px 5px;padding-bottom:8px;"></td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
