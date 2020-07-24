<%@ Page Language="C#" AutoEventWireup="true" CodeFile="注册界面.aspx.cs" Inherits="注册界面" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户注册</title>
    <link rel="shortcut icon" href="Resources\Image\首页徽章.png" type="image/x-icon" />
    <link rel="stylesheet" href="style\注册界面.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TopBar">
            <asp:Image ID="ImgTitle" runat="server" Width="40px" ImageUrl="Resources\Image\首页徽章.png" ImageAlign="Left" />
            <span style="float: left; width: 500px; font-size: 30px; white-space: normal;">游戏维度www.yxwd.com</span>


            <span><a href="首页.aspx">维度中心</a></span>
        </div>
        <div>
            <asp:Image ID="ImgHome" runat="server" ImageUrl="Resources\Image\游戏维度.jpg" />
        </div>
        <div class="content">
            <div><span class="Title">欢迎加入游戏维度</span></div>
            <div>
                <asp:Image ID="image" runat="server" Width="100px" Height="100px" CssClass="tb" ImageAlign="Middle" /><asp:FileUpload ID="fu" runat="server" Text="上传头像" />
                <br />
            </div>
            <div>
                <asp:TextBox ID="tb1" runat="server" placeholder="请输入手机号" CssClass="tb" CausesValidation="True"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="tb1" ErrorMessage="请检查手机号是否填写！" Text="手机号不能为空" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox ID="tb2" runat="server" TextMode="Password" placeholder="密码(6-20位字母与数字、符号组合)" CssClass="tb" CausesValidation="True"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tb2" ErrorMessage="请检查密码是否填写！" Text="密码不能为空" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox ID="tb3" runat="server" TextMode="Password" placeholder="请再次输入要密码" CssClass="tb" CausesValidation="True"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="tb3" ControlToCompare="tb2" ErrorMessage="请确认两次密码是否一致!" Text="两次密码不一致" ValidationGroup="submit"></asp:CompareValidator>
            </div>
            <div>
                <asp:TextBox ID="tbname" runat="server" CssClass="tb" name="name" CausesValidation="true" placeholder="请输入您的收货姓名"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfname" runat="server" ControlToValidate="tbname" ErrorMessage="姓名不能为空！" Text="请输入姓名" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox ID="tbid" runat="server" CssClass="tb" name="id" CausesValidation="true" placeholder="维度账号"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfid" runat="server" ControlToValidate="tbid" ErrorMessage="账号不能为空！" Text="请输入账号" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:TextBox ID="tbnick" runat="server" CssClass="tb" name="id" CausesValidation="true" placeholder="维度昵称"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfnick" runat="server" ControlToValidate="tbnick" ErrorMessage="昵称不能为空！" Text="请输入昵称" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:RadioButton ID="rdb1" runat="server" CssClass="tb" Text="男" GroupName="sex" /><asp:RadioButton ID="rdb2" runat="server" CssClass="tb" Text="女" GroupName="sex" />
                <br />
            </div>
            <%--            <div>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="tb" name="id" CausesValidation="true" placeholder="维度昵称"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnick" ErrorMessage="昵称不能为空！" Text="请输入昵称" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>--%>
            <br />
            <br />
            <div>
                <asp:CheckBox ID="cb1" runat="server" Text="已同意《游戏维度条款》" /><br />

                <asp:ImageButton ID="ImgBtn" runat="server" ImageUrl="Resources\Image\注册登陆1.png" CssClass="ImgBtn" OnClick="ImgBtn_Click" ValidationGroup="submit" />
            </div>
        </div>
        <!--<div class="LoginBox" id="LoginBox" runat="server">
            <h1>用户登录</h1>
            <div>用户名(或手机号):<asp:TextBox ID="asdtbID" runat="server" Height="21px" Width="212px"></asp:TextBox><asp:RequiredFieldValidator ID="tbbb123" runat="server" ControlToValidate="tbID" ErrorMessage="账号不能为空"></asp:RequiredFieldValidator></div>
            <br />
            <div>密码：<asp:TextBox ID="tbPsw" runat="server" TextMode="Password" Height="21px" Width="212px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPsw" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator></div>
            <br />
            <br />
            <asp:Button ID="BtnLoginin" runat="server" Text="登陆" Width="85px" OnClick="Loginin_Click"></asp:Button>
            <asp:Button ID="BtnExit" runat="server"  Text="退出" Width="85px" OnClick="Exit_Click" CausesValidation="false"></asp:Button>
        </div>-->
    </form>
</body>
</html>
