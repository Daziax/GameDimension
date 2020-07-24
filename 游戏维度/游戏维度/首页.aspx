<%@ Page Language="C#" AutoEventWireup="true" CodeFile="首页.aspx.cs" Inherits="首页" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>游戏维度-大型单击游戏媒体</title>
    <link href="style/首页.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="Resources\Image\首页徽章.png" type="image/x-icon" />

</head>
<script type="text/javascript" src="style/jquery-3.4.1.js"></script>
<script src="style/首页.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="TopBar">
            <asp:Image ID="ImgTitle" runat="server" Width="40px" ImageUrl="Resources\Image\首页徽章.png" ImageAlign="Left" />
            <span style="float: left; width: 320px; font-size: 30px; white-space: normal;">游戏维度www.yxwd.com</span>
            <span><a href="首页.aspx">维度中心</a></span>
            <span>网站导航</span>
            <span>
                <asp:Image ID="imgicon" CssClass="ImgBar" ImageUrl="https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1554958914838&di=c3743a2227cbc03be900aa98c6ea8204&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201704%2F27%2F20170427155254_Kctx8.jpeg" runat="server" /></span>
            <div class="TopBarVA1" id="TopBarVA1" runat="server">
                <span>
                    <asp:Button ID="BtnTopBar" runat="server" Text="登陆" CssClass="BtnTopBar" OnClick="Login_Click" CausesValidation="False" /></span>
                <span><a href="注册界面.aspx" id="Register" runat="server">注册</a></span>
            </div>
            <div class="TopBarVA2" id="TopBarVA2" runat="server">
                <span><a href="个人中心.aspx" runat="server">个人中心</a></span>
                <span>
                    <asp:Button ID="Exit" runat="server" Text="退出" CssClass="BtnTopBar" OnClick="Exit_Click" /></span>
            </div>
        </div>
        <div>
            <asp:Image ID="ImgHome" runat="server" ImageUrl="Resources\Image\游戏维度.jpg" />
        </div>
        <div class="nav">
            <nav>
                <a href="首页.aspx">首页</a>
                <a href="交流中心.aspx">交流中心</a>
                <a href="个人中心.aspx">我的维度</a>
            </nav>
        </div>
        <div class="content">
            <div class="clsnav">
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">热门</span></a>
                <a href="#" class="ClsNavCurrent"><span class="ClsNavBlc">最新</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">恐怖</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">僵尸</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">沙盒</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">休闲</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">独立</span></a>
                <a href="#" class="ClsNavNone"><span class="ClsNavBlc">国产</span></a>
            </div>
            <div class="clscont">
                <div></div>
                <div class="ClsContItemCurrent">
                    <div class="ClsContItemPic">
                        <div>
                            <a href="https://www.gamersky.com/z/bf5/" target="_blank">
                                <asp:ImageButton ID="img1" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\1.jpg" OnClick="img1_Click" /><span><asp:Label ID="lb1" runat="server"></asp:Label>
                                </span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/cod15/" target="_blank">
                                <asp:ImageButton ID="img2" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\2.jpg" OnClick="img2_Click" /><span><asp:Label ID="lb2" runat="server"></asp:Label></span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/z358/" target="_blank">
                                <asp:ImageButton ID="img3" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\3.jpg" OnClick="img3_Click" /><span><asp:Label ID="lb3" runat="server"></asp:Label></span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/mesom2/" target="_blank">
                                <asp:Image ID="img4" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\4.jpg" /><span>中土世界战争之影</span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/civilization6/" target="_blank">
                                <asp:Image ID="img5" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\5.jpg" /><span>文明6</span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/totalwarwarhammer2/" target="_blank">
                                <asp:Image ID="img6" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\6.jpg" /><span>战锤：全面战争2</span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/sangokushi13/" target="_blank">
                                <asp:Image ID="img7" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\7.jpg" /><span>三国志13威力加强版</span></a>
                        </div>
                        <div>
                            <a href="https://www.gamersky.com/z/xcom2/" target="_blank">
                                <asp:Image ID="img8" runat="server" CssClass="ClsContItemPicItem" ImageAlign="Middle" ImageUrl="Resources\Image管理员\8.jpg" /><span>幽浮2</span></a>
                        </div>

                    </div>
                </div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
            <div class="search">
                <div class="radio">
                    <asp:RadioButton ID="rdb1" runat="server" Text="本站" CssClass="rdb" Checked="true" />
                    <asp:RadioButton ID="rdb2" runat="server" Text="百度" CssClass="rdb" />
                </div>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <div class="engine" data-action="http://so.gamersky.com/">
                    <asp:TextBox ID="tbe" runat="server" Width="450px" Height="35px" AutoCompleteType="None" CssClass="engine"></asp:TextBox>
                    <asp:ImageButton ID="SchBtn" runat="server" OnClick="SchBtn_Click" Width="40px" Height="40px" ImageUrl="https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1555567467292&di=3deee74d90f00f0d4bc5ec7b710c80f6&imgtype=0&src=http%3A%2F%2Fpic.51yuansu.com%2Fpic3%2Fcover%2F02%2F25%2F26%2F59b0904fd4605_610.jpg" />
                </div>
            </div>
            <div class="Cont">
                <div class="ContL">
                    <div class="slide">
                        <a href="https://ol.gamersky.com/news/201904/1173143.shtml">
                            <asp:Image ID="SldPic1" runat="server" ImageUrl="Resources\Image管理员\9.jpg" AlternateText="无法显示该图片" /></a>
                    </div>
                </div>
                <div class="ContM">
                    <div class="MidNew">
                        <div class="MidNewNav">
                            <a href="#"><span class="MidNewNavItem">今日要闻</span></a>
                            <a href="#"><span class="MidNewNavItem">游戏资讯</span></a>
                            <a href="#"><span class="MidNewNavItem">游戏美图</span></a>
                        </div>
                        <div class="MidNewCurrent">
                        </div>
                        <div class="MidNewNone">
                        </div>
                        <div class="MidNewNone">
                        </div>
                    </div>
                </div>
                <div class="ContR">
                    <div class="最新单击游戏">
                        <div>
                           <span>最新单击游戏</span><a href="https://down.gamersky.com/" target="_blank">更多...</a>
                        </div>
                        <asp:Image ID="ImgContR2" runat="server" ImageUrl="" />
                        <div class="ContRCls">
                            <table>
                                <tr>
                                    <th class="ContRCls1">游戏名称</th>
                                    <th class="ContRCls2">类型</th>
                                    <th class="ContRCls2">众评</th>
                                </tr>
                                <tr>
                                    <td><asp:Image ID="ImgContR1" runat="server" ImageUrl="" /></td>
                                </tr>
                                <tr>

                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
            </div>
            <div>
                <asp:Button ID="BtnMLogin" runat="server" Text="管理员入口" CssClass="BtnMLogin" OnClick="BtnMLogin_Click" />
            </div>
            <div class="ManagerLogin" id="ManagerLogin" runat="server">
                147jrn<p>管理员登陆</p>
                <div>
                    <asp:TextBox ID="tbMID" runat="server" Height="21px" Width="212px" placeholder="请输入账号"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbID" runat="server" ErrorMessage="账号不能为空"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbMPsw" runat="server" TextMode="Password" Height="21px" Width="212px" placeholder="请输入密码"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbPsw" runat="server" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
                </div>
                <asp:DropDownList ID="dpdlMID" runat="server">
                    <asp:ListItem>游戏管理员</asp:ListItem>
                    <asp:ListItem Selected="True">销售员</asp:ListItem>
                    <asp:ListItem>进货员</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnMLoginin" runat="server" Text="登陆" Width="85px" OnClick="BtnMLoginin_Click"></asp:Button>
                <asp:Button ID="ButMExit" runat="server" Text="退出" Width="85px" OnClick="ButMExit_Click"></asp:Button>
            </div>
        </div>

        <div class="LoginBox" id="LoginBox" runat="server">
            <div>用户名:<asp:TextBox ID="tbID" runat="server" CssClass="TbLoginBox" placeholder="(或手机号)"></asp:TextBox><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="tbID" ErrorMessage="账号不能为空" Style="color: red; font-size: 26px;"></asp:RequiredFieldValidator></div>
            <br />
            <div>密码&nbsp：<asp:TextBox ID="tbPsw" runat="server" CssClass="TbLoginBox" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tbPsw" ErrorMessage="密码不能为空" Style="color: red; font-size: 26px;"></asp:RequiredFieldValidator></div>
            <br />
            <br />
            <asp:ImageButton ID="BtnLoginin" runat="server" Text="登陆" ImageUrl="Resources/Image/登录.png" Width="570px" OnClick="Loginin_Click"></asp:ImageButton>
            <asp:Button ID="BtnExit" runat="server" Text="X" OnClick="Exit_Click" CausesValidation="False"></asp:Button>
        </div>
    </form>
</body>
</html>
