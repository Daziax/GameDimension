<%@ Page Language="C#" AutoEventWireup="true" CodeFile="个人中心.aspx.cs" Inherits="个人中心" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>个人中心</title>
    <link rel="shortcut icon" href="Resources\Image\首页徽章.png" type="image/x-icon" />
    <link rel="stylesheet" href="style\个人中心.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TopBar">
            <asp:Image ID="ImgTitle" runat="server" Width="40px" ImageUrl="Resources\Image\首页徽章.png" ImageAlign="Left" />
            <span style="float: left; width: 500px; font-size: 30px; white-space: normal;">游戏维度www.yxwd.com</span>
            <span><a href="首页.aspx">维度中心</a></span>
            <span>
                <asp:Image ID="imgicon" CssClass="ImgBar" ImageUrl="https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1554958914838&di=c3743a2227cbc03be900aa98c6ea8204&imgtype=0&src=http%3A%2F%2Fb-ssl.duitang.com%2Fuploads%2Fitem%2F201704%2F27%2F20170427155254_Kctx8.jpeg" runat="server" /></span>
            <%--<span><a href="首页.aspx" runat="server">维度中心</a></span>--%>
           
            <asp:Button ID="Exit" runat="server" Text="退出" CssClass="BtnTopBar" OnClick="Exit_Click" />
        </div>
        
        <div class="Content">
            <div class="head">
            <div>
                <asp:ImageButton ID="imgbtn1" runat="server" ImageUrl="Resources\Image\设置1.png" />
            </div>
            <div class="ProfilePic">
                <asp:Image ID="ImgSelfile" runat="server" Width="100px" Height="100px" ImageUrl="https://image.gamersky.com/avatar/original/game/game010.jpg" />
                <br />
                <asp:Label ID="LbName" runat="server" Width="100px" CssClass="PrfName">Dazia</asp:Label>
            </div>
            <div class="nav" runat="server">
                <div class="Information">
                    <asp:Button ID="Btn1" runat="server" Text="资料更改" CssClass="BtnNav" OnClick="Btn1_Click" CausesValidation="False"></asp:Button>
                </div>
                <div class="Circle">
                    <asp:Button ID="Btn2" runat="server" Text="我的订单" CssClass="BtnNav" OnClick="Btn2_Click"></asp:Button>
                </div>
                <div class="Game">
                    <asp:Button ID="Btn3" runat="server" Text="我的游戏" CssClass="BtnNav" OnClick="Btn3_Click" CausesValidation="False"></asp:Button>
                </div>
            </div>
        </div>
            <div class="left">
                <div class="LeftMiddle1" id="LeftMiddle1" runat="server">
                    <div id="grzl">
                        <p class="grzl">照片:&nbsp&nbsp<asp:Image ID="image" runat="server" Width="100px" Height="100px" CssClass="grzxk" ImageAlign="Middle" /><asp:FileUpload ID="fu" runat="server" Text="上传头像" />
                        </p>
                        <p class="grzl">姓名*:&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="tbname" runat="server" CssClass="grzlk" name="name"></asp:TextBox></p>
                        <p class="grzl">维度账号*:<asp:TextBox ID="tbid" runat="server" CssClass="grzlk" name="id" ReadOnly="True"></asp:TextBox></p>
                        <p class="grzl">维度昵称*:<asp:TextBox ID="tbnick" runat="server" CssClass="grzlk" name="id"></asp:TextBox></p>
                        <p class="grzl">性别*:&nbsp&nbsp<asp:RadioButton ID="rdb1" runat="server" CssClass="grzlk" Text="男" GroupName="sex" /><asp:RadioButton ID="rdb2" runat="server" CssClass="grzlk" Text="女" GroupName="sex" /></p>
                         <p class="grzl">收货地址:&nbsp<asp:TextBox ID="tbaddr" runat="server" CssClass="grzlk" name="id"></asp:TextBox></p>
                        <asp:Button ID="btnprf" runat="server" CssClass="BtnLeftMiddle" OnClick="btnprf_Click" Text="修改" CausesValidation="False" />
                        
                    </div>
                    <div id="mmgg" runat="server">
                        <p class="mmgg">旧密码:&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="tbpsw" runat="server" TextMode="Password" CssClass="mmggk" name="pswo"></asp:TextBox></p>
                        <div runat="server" id="NewPsw">
                            <p class="mmgg">新密码:&nbsp&nbsp&nbsp&nbsp<asp:TextBox runat="server" TextMode="Password" CssClass="mmggk" name="pswn" ID="tbpsw1"></asp:TextBox></p>
                            <p class="mmgg">再次输入:&nbsp&nbsp<asp:TextBox ID="tbpsw2" TextMode="Password" runat="server" CssClass="mmggk" name="pswn"></asp:TextBox></p>
                        </div>
                        <asp:Button ID="btnpsw" runat="server" CssClass="BtnLeftMiddle" OnClick="btnpsw_Click" Text="修改" CausesValidation="False" />
                    </div>
                    <div id="sjbd">
                        <p class="sjbd">当前手机号*:<asp:TextBox ID="tbphone" runat="server" placeholder="暂未绑定" CssClass="mmggk" name="pswn"></asp:TextBox></p>
                        <asp:Button ID="btnpho" runat="server" CssClass="BtnLeftMiddle" Text="绑定" OnClick="btnpho_Click" CausesValidation="False" />
                    </div>
                    <div>
                        <p class="sjbd">是否为本站编辑:<asp:Label ID="tbE" runat="server" Text="您并非本站编辑" placeholder="无"></asp:Label></p>
                        <asp:Button ID="btneditor" runat="server" CssClass="BtnLeftMiddle" Text="申请成为" OnClick="btneditor_Click" CausesValidation="False" />
                        <asp:Button ID="btnNext" runat="server" CssClass="BtnLeftMiddle" Text="完成注册" OnClick="btnNext_Click" CausesValidation="False" Visible="False" />
                    </div>
                </div>
                    <div class="LeftMiddle3" id="LeftMiddle2" runat="server">
                    <asp:GridView ID="gv1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" DataSourceID="SQLMyOrder" AllowPaging="True" AllowSorting="True" Width="100%" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="moName" HeaderText="游戏名" SortExpression="moName" />
                            <asp:BoundField DataField="moUID" HeaderText="购买用户" SortExpression="moUID"></asp:BoundField>
                            <asp:BoundField DataField="moPrice" HeaderText="价格" SortExpression="moPrice" />
                            <asp:BoundField DataField="moAmount" HeaderText="数量" SortExpression="moAmount" />
                            <asp:BoundField DataField="moForm" HeaderText="版本" SortExpression="moForm" />
                            <asp:BoundField DataField="moTime" HeaderText="下单时间" SortExpression="moTime" />
                            <asp:BoundField DataField="moStatus" HeaderText="交易状态" SortExpression="moStatus" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                        <asp:SqlDataSource ID="SQLMyOrder" runat="server" ConnectionString="Data Source=.;Initial Catalog=YXWD;Integrated Security=True;MultipleActiveResultSets=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [moName], [moUID], [moPrice], [moAmount], [moForm], [moTime], [moStatus] FROM [MyOrder] WHERE ([moUID] = @moUID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="tbid" Name="moUID" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                </div>
                <div class="LeftMiddle3" id="LeftMiddle3" runat="server">
                    <asp:GridView ID="gv2" runat="server" CellPadding="4" DataKeyNames="gName" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:ImageField DataImageUrlField="gImage" HeaderText="截图">
                            </asp:ImageField>
                            <asp:BoundField DataField="gName" HeaderText="游戏" ReadOnly="True" />
                            <asp:BoundField DataField="gPrice" HeaderText="价格"></asp:BoundField>
                            <asp:ButtonField CommandName="Information" Text="查看详情" HeaderText="详情"></asp:ButtonField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                </div>
            </div>

            <%--<div class="right">
                <div class="RightTitle">热门圈子</div>
            </div>--%>
        </div>
    </form>
</body>
</html>
