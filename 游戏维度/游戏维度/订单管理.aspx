<%@ Page Language="C#" AutoEventWireup="true" CodeFile="订单管理.aspx.cs" Inherits="订单详情" %>

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
            margin-left: 0px;
            left: 210px;
            width: 1350px;
        }

        div.v3 {
            color:black;
            font-weight: 600;
            font-size: 30px;
            display: block;
            z-index: 999999;
            padding: 20px;
            background-color: white;
            border-radius: 20px;
            width: 1100px; /*500px;*/
            height: 640px; /*320px*/
            margin: auto;
            position: fixed;
            Top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            box-shadow: 3px 3px 20px 20px #696969;
            background-size: 820px;
            background-position-x: right;
            background-color: white;
        }

        div.v4 {
            position: relative;
            top: 100px;
            left: 210px;
            width: 70%;
        }

        .Tbv3 {
            width: 400px;
            height: 70px;
        }
           .v3 > div {
        text-align: left;
        margin: 30px;
    }
           .v3>:nth-child(8) {
        position: relative;
        top: -430px;
        left: 450px;
        background-color: transparent;
        font-weight: 700;
        font-size:42px;
        color: wheat;
        border: none;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: fixed; right: 100px; top: 40px"><a href="首页.aspx">首页</a>&nbsp&nbsp&nbsp</div>

        <div class="v1">
            <h1 class="a">订单管理</h1>
        </div>

        <br />
        <br />
        <br />
        <div class="v2">
            <h1>订单处理</h1>
            <asp:GridView runat="server" ID="gv1" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="Shipped_RowCommand" OnSelectedIndexChanged="gv1_SelectedIndexChanged" DataKeyNames="moTime,moUID" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="moName" HeaderText="游戏名称" SortExpression="moName" />
                    <asp:BoundField DataField="moUID" HeaderText="用户ID" SortExpression="moUID" />
                    <asp:BoundField DataField="moPrice" HeaderText="价格" SortExpression="moPrice" />
                    <asp:BoundField DataField="moAmount" HeaderText="数量" SortExpression="moAmount" />
                    <asp:BoundField DataField="moTime" HeaderText="下单时间" SortExpression="moTime" />
                    <asp:BoundField DataField="moForm" HeaderText="版本" SortExpression="moForm" />
                    <asp:BoundField DataField="moStatus" HeaderText="状态" SortExpression="moStatus" />
                    <asp:ButtonField ButtonType="Button" CommandName="Shipped" HeaderText="处理" ShowHeader="True" Text="发货" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YXWDConnectionString %>" SelectCommand="SELECT [moName], [moUID], [moPrice], [moAmount], [moTime], [moForm], [moStatus] FROM [MyOrder] ORDER BY [moTime]"></asp:SqlDataSource>
        </div>
        <div class="v3" id="v3" runat="server">
            <div>
                版本:<asp:RadioButton ID="rbd" runat="server" Checked="true"  Text="数字版" GroupName="form" AutoPostBack="True" OnCheckedChanged="rbd_CheckedChanged" /><asp:RadioButton ID="rbe" runat="server" GroupName="form" Text="实体版" OnCheckedChanged="rbe_CheckedChanged" AutoPostBack="True" />
            </div>
            <div id="entity" runat="server">
                <div>快递公司:<asp:TextBox ID="tbCompany" runat="server" CssClass="Tbv3"></asp:TextBox><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="tbCompany" ErrorMessage="快递公司不能为空" Style="color: red; font-size: 26px;"></asp:RequiredFieldValidator></div>
                <br />
                <div>运单号&nbsp：<asp:TextBox ID="tbTracking" runat="server" CssClass="Tbv3" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tbTracking" ErrorMessage="运单号不能为空" Style="color: red; font-size: 26px;"></asp:RequiredFieldValidator></div>
            </div>
            <div id="digital" runat="server">
                <div>序列码:<asp:TextBox ID="tbKey" runat="server" CssClass="Tbv3" ></asp:TextBox><asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="tbKey" ErrorMessage="游戏key不能为空" Style="color: red; font-size: 26px;"></asp:RequiredFieldValidator></div>
            </div>
            <br />
            <br />
            <br />
            <asp:ImageButton ID="BtnNext" runat="server" Text="登陆" ImageUrl="Resources/Image/登录.png" Width="570px" OnClick="Next_Click"></asp:ImageButton>
            <asp:Button ID="BtnExit" runat="server" Text="X" OnClick="Exit_Click" CausesValidation="False" style="width: 28px"></asp:Button>
        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
