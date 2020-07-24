<%@ Page Language="C#" AutoEventWireup="true" CodeFile="游戏管理.aspx.cs" Inherits="管理员页面" %>

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
            <h1 class="a">管理员页面</h1>
        </div>

        <br />
        <br />
        <br />
        <div class="v4">
            <h1>游戏添加</h1>
            <asp:TextBox ID="tb1" runat="server" placeholder="游戏名称" CssClass="tb" CausesValidation="False"></asp:TextBox>
            <asp:TextBox ID="tb2" runat="server" placeholder="游戏价格(元)" CssClass="tb" CausesValidation="False"></asp:TextBox>
            <asp:TextBox ID="tb3" runat="server" placeholder="游戏详情" CssClass="tb" CausesValidation="False"></asp:TextBox>
            <br />
            封面:<asp:FileUpload ID="fu1" runat="server" Text="上传封面" CssClass="tb" placeholder="请上传封面" />
            背景:<asp:FileUpload ID="fu2" runat="server" Text="上传背景" CssClass="tb" placeholeder="上传背景" />
            <asp:Button ID="AddGame" runat="server" Text="添加" OnClick="AddGame_Click" CausesValidation="False" />
            <h1>详情编辑</h1>
            <asp:GridView ID="gv" runat="server" Width="100%" OnRowDeleting="gv_RowDeleting" DataKeyNames="gName" OnRowEditing="gv_RowEditing" OnRowUpdating="gv_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="gv_RowCancelingEdit">
                <Columns>
                    <asp:ImageField DataImageUrlField="gImage" HeaderText="游戏">
                    </asp:ImageField>
                    <asp:BoundField DataField="gName" HeaderText="游戏名" />
                    <asp:BoundField DataField="gPrice" HeaderText="价格" />
                    <asp:BoundField DataField="gInformation" HeaderText="游戏详情" />
                    <asp:BoundField DataField="gVideo" HeaderText="背景地址"></asp:BoundField>
                    <asp:BoundField DataField="gSold" HeaderText="已售" />
                    <asp:BoundField DataField="gInventory" HeaderText="库存" />
                    <asp:BoundField DataField="gPreturn" HeaderText="退货中" />
                    <asp:BoundField DataField="gReturn" HeaderText="已退" />
                    <asp:CommandField ItemStyle-Width="100px" ShowDeleteButton="True" ShowEditButton="True" CancelText="完成" NewText="添加游戏">
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
