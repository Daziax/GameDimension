<%@ Page Language="C#" AutoEventWireup="true" CodeFile="游戏详情.aspx.cs" Inherits="游戏详情" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="style\游戏详情.css" />

    <title>游戏详情</title>

</head>
<script type="text/javascript" src="style/jquery-3.4.1.js"></script>
<script type="text/javascript" src="style/游戏详情.js"></script>
<body>
    <form id="form1" runat="server">
        <div class="ImgBackground" id="ImgBk" runat="server">
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
            <div class="content">

                <div class="Top">
                    <div class="TopLeft">
                        <asp:Image ID="img1" runat="server" ImageUrl="Resources\Image\塞尔达封面.jpg" CssClass="img1" style="left: 50px; top: -57px" />
                    </div>
                    <div class="TopMid">
                        <div>
                            <asp:Image ID="img2" runat="server" CssClass="logo" ImageUrl="Resources\Image\xbox.png" />
                            <asp:Image ID="img3" runat="server" CssClass="logo" Height="36px" Width="102px" ImageUrl="Resources\Image\ps4.jpg" />
                            <asp:Image ID="img4" runat="server" CssClass="logo" Height="36px" Width="102px" ImageUrl="Resources\Image\switch.png" />
                        </div>
                        <div class="TopTitle">
                            <asp:Label ID="TopTitle" runat="server" Text="塞尔达传说：荒野之息"></asp:Label>
                        </div>
                        <div class="Information">
                            <p><asp:Label ID="Para" runat="server" Text="《塞尔达传说：荒野之息》是任天堂开发的系列重启作品，是真正的全开放世界，而非以前的种种限制，玩家可以从任何方向到达你想去的地方。本作中，林克从一开始就获得了所有道具能力，并且可以和世界中的各种要素进行互动。大自然的风火雷电都可以被利用，让林克的冒险有层出不穷的玩法。任天堂秉承系列优秀的品质，相信游戏不会让玩家失望。《塞尔达传说：荒野之息》中文版于2018年2月1日发售。玩家可以用繁体中文或简体中文享受至今为至从未经历过的冒险，已持有游戏的玩家预定能通过更新资料来追加游戏语言。"></asp:Label></p>
                        </div>
                    </div>
                    <div class="TopRight">
                        <div class="price">
                            <a href="#AllPrice" title="点击查看全部价格">
                                <asp:Label ID="Price" runat="server" Text="价格：400元"></asp:Label></a>
                        </div>
                        <div class="buy">
                            <asp:ImageButton ID="ImgBtn1" runat="server" ImageUrl="Resources\Image\购买1.jpg" OnClick="Buy_Click" CausesValidation="False" />
                        </div>
                        <div class="TopRightBtn">
                            <asp:Button ID="btnWanna" runat="server" CssClass="TopRightBtnItem" Text="加入购物车" ToolTip="加入" OnClick="btnWanna_Click" CausesValidation="False" /><asp:Button ID="btnPlayed" runat="server" ToolTip="评分并评价" CssClass="TopRightBtnItem" Text="玩过" OnClick="btnPlayed_Click" CausesValidation="False" />
                        </div>
                    </div>
                </div>
                <div class="cover"></div>
                <div class="layer">
                    <div class="OnLayer">
                        <div class="MediaComment">
                            <div class="media">
                                <div><img src="Resources/Image/媒体.png" /><label>媒体评分</label></div>
                                <div>
                                    <ul>
                                        <li class="MediaCommentItem">
                                            <label>10</label>/10 游民星空</li>
                                        <li  class="MediaCommentItem">
                                            <label>10</label>/10 IGN</li>
                                        <li  class="MediaCommentItem">
                                            <label>10</label>/10 VGtime</li>
                                        <li  class="MediaCommentItem">
                                            <label>9.5</label>/10 EGM</li>
                                        <li  class="MediaCommentItem">
                                            <label>9.5</label>/10 三DM</li>
                                        <li  class="MediaCommentItem">
                                            <label>10</label>/10 中游娱乐</li>
                                        <li  class="MediaCommentItem">
                                            <label>10</label>/10 Ubisoft</li>
                                        <li  class="MediaCommentItem">
                                            <label>9.5</label>/10 NTD</li>
                                    </ul>
                                    <div>
                                        《荒野之息》将系列传统与现代流行的游戏元素融合得是如此完美，这个开放世界辽阔得令人惊叹，虽说在具体的尺寸上还是比洛圣都略逊一筹，但由于没有汽车飞机等机械载具，《荒野之息》在感官上给人带来的广阔体验依然在沙盒游戏中算是数一数二的。
                                    </div>
                                </div>
                                 <input type="button" value="<" /><input type="button" value=">" />
                            </div>
                        </div>
                        <div class="MidLine"></div>
                        <div class="PlayerComment">
                            <div class="ThePlayer" runat="server" id="ThePlayer">
                                <textarea rows="10" cols="3"></textarea>
                                <input type="button" value="发表评论" />
                            </div>
                            <div class="AllPlayer">
                                <div><img src="Resources/Image/玩家评论.png" /><label>玩家评论</label></div>
                                <input type="hidden" id="session" value='<%=Session["uNickname"]%>' />
                                <ul>
                                    <li>
                                        <div class="EachAllPlayer">
                                            <div>
                                                <asp:Image ID ="UserIcon" runat="server" Height="80px" ImageUrl='<%#imgicon.ImageUrl%>' />
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="EachAllPlayer">
                                            <div><asp:Image ID="img45" runat="server" Height="80px" ImageUrl="Resources/Image管理员/2.jpg" /></div>
                                            <div>
                                                <label>买家xxx:</label>
                                                <div>非常好玩！强烈推荐<a href="#">更多</a></div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="LoginBox" id="LoginBox" runat="server">
                <div>用户名:<asp:TextBox ID="tbID" runat="server" CssClass="TbLoginBox" placeholder="(或手机号)"></asp:TextBox><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="tbID" ErrorMessage="账号不能为空" style="color:red;font-size:26px;"></asp:RequiredFieldValidator></div>
                <br />
                <div>密码&nbsp：<asp:TextBox ID="tbPsw" runat="server" CssClass="TbLoginBox" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="tbPsw" ErrorMessage="密码不能为空" style="color:red;font-size:26px;"></asp:RequiredFieldValidator></div>
                <br />
                <br />
                <asp:ImageButton ID="BtnLoginin" runat="server" Text="登陆" ImageUrl="Resources/Image/登录.png" Width="570px" OnClick="Loginin_Click"></asp:ImageButton>
                <asp:Button ID="BtnExit" runat="server" Text="X" OnClick="Exit_Click" CausesValidation="False"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
