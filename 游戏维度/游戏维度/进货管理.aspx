<%@ Page Language="C#" AutoEventWireup="true" CodeFile="进货管理.aspx.cs" Inherits="库存管理" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的订单</title>

    <style>
        body {
            color: black;
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
            margin-left:0px;
            left: 210px;
            width: 1350px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: fixed; right: 100px; top: 40px"><a href="首页.aspx">首页</a>&nbsp&nbsp&nbsp</div>

        <div class="v1">
            <h1 class="a">进货管理</h1>
        </div>

        <br />
        <br />
        <br />
        <div class="v2">
            <h1>商品信息</h1>
            <asp:TextBox ID="GameName" runat="server" placeholder="游戏名"></asp:TextBox>
            <asp:TextBox ID="Amount" runat="server" placeholder="进货数"></asp:TextBox>
            <asp:TextBox ID="Price" runat="server" placeholder="进货总价"></asp:TextBox>
            <asp:DropDownList ID="Form" runat="server" >
                <asp:ListItem Selected="True">实体版</asp:ListItem>
                <asp:ListItem>数字版</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="AdIvtr" runat="server" Text="进货" OnClick="AdIvtr_Click" CausesValidation="false" />
            <h1>进货记录</h1>
            <asp:Gridview runat="server" ID="gv1" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="orName" HeaderText="游戏名" SortExpression="orName" />
                    <asp:BoundField DataField="orTime" HeaderText="时间" SortExpression="orTime" />
                    <asp:BoundField DataField="orAmount" HeaderText="数量" SortExpression="orAmount" />
                    <asp:BoundField DataField="orUnitPrice" HeaderText="单价" SortExpression="orUnitPrice" />
                    <asp:BoundField DataField="orPrice" HeaderText="价格" SortExpression="orPrice" />
                    <asp:BoundField DataField="orForm" HeaderText="版本" SortExpression="orForm" />
                </Columns>
            </asp:Gridview>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YXWDConnectionString %>" SelectCommand="SELECT * FROM [OrderRecord]"></asp:SqlDataSource>
        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
