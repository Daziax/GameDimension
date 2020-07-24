<%@ Page Language="C#" AutoEventWireup="true" CodeFile="购买页面.aspx.cs" Inherits="购买页面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的订单</title>

    <style>
        body {
            color: fuchsia;
        }

        h1 {
            font-weight: 700;
            font-size: 30px;
            color: black;
        }

        * {
            font-size: 26px;
        }

        h1.a {
            color: darkblue;
            font-family: cursive;
        }

        h2.b {
            color: coral;
            font-family: cursive;
        }

        div.v1 {
            margin: auto;
            width: 200px;
            top: 100px;
        }

        div.v2 {
            text-align: left;
            position: relative;
            margin: 40px;
            margin-left: 0px;
            left: 210px;
            width: 1350px;
        }

        .v2 > div {
            margin: 20px;
        }

        div.v3 {
            position: relative;
            top: 100px;
            left: 210px;
            width: 70%;
        }

        div.v4 {
            position: relative;
            top: 100px;
            left: 210px;
            width: 70%;
        }
        .buy{
            position:absolute;
            top:800px;
            left:1500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: fixed; right: 100px; top: 40px"><a href="首页.aspx">首页</a>&nbsp&nbsp&nbsp<a href="个人中心.aspx">我的维度</a></div>

        <div class="v1">
            <h1 class="a">订单确认</h1>
        </div>
        <br />
        <br />
        <br />
        <div class="v2">
            <h1>详情信息</h1>
            <div style="width:1500px;margin:auto;">
            <table border="2" width="1400px">
                <tr>
                    <th>游戏名</th>
                    <th>用户名</th>
                    <th>价格</th>
                    <th>数量</th>
                    <th>版本</th>
                </tr>
                <tr>
                    <tr>
                    <td><asp:Label ID="Name" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Label ID="UID" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Label ID="Price" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Textbox ID="Amount" runat="server" Text="1"></asp:Textbox></td>
                    <td><asp:DropDownList ID="Form" runat="server">
                            <asp:ListItem Selected="True">实体版</asp:ListItem>
                            <asp:ListItem>数字版</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                    <td><asp:Label ID="Name1" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Label ID="UID1" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Label ID="Price1" runat="server" Text=" "></asp:Label></td>
                    <td><asp:Textbox ID="Amount1" runat="server" Text=" "></asp:Textbox></td>
                    <td><asp:DropDownList ID="Form2" runat="server">
                            <asp:ListItem Selected="True">实体版</asp:ListItem>
                            <asp:ListItem>数字版</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
            </table>

            </div>
            <asp:Button ID="Buy" runat="server" CssClass="buy" Text="下单" OnClick="rBuy_Click" CausesValidation="false" />
        </div>
    </form>
</body>
</html>
