using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Web;
using Model;
using System.Data;
using System.Web.UI;

namespace BLL
{
    public class DbOp
    {
        //刷新Session
        public void ReSession(string IDorPhone)
        {
            Function func = new Function();
            UserPlayer user = new UserPlayer();
            user = func.SelectUser(IDorPhone);
            HttpContext.Current.Session.Add("uID", user.UID);
            HttpContext.Current.Session.Add("uPsw", user.UPsw);
            HttpContext.Current.Session.Add("uSex", user.USex);
            HttpContext.Current.Session.Add("uEditor", user.UEditor);
            HttpContext.Current.Session.Add("uName", user.UName);
            HttpContext.Current.Session.Add("uNickname", user.UNickname);
            HttpContext.Current.Session.Add("uPhoto", user.UPhoto);
            HttpContext.Current.Session.Add("uPhone", user.UPhone);
            HttpContext.Current.Session.Add("uAddress", user.UAddress);
            HttpContext.Current.Session.Timeout = 5;

        }
        //TopBar登陆注册
        public void Loginin(string UserOrManeger, string IDorPhone, string Psw, string MID = "")
        {
            Function func = new Function();
            HttpRequest request = HttpContext.Current.Request;
            string aspx = request.Url.ToString().Substring(23);
            try
            {
                if (UserOrManeger == "user")
                {
                    UserPlayer user = new UserPlayer();
                    user = func.SelectUser(IDorPhone);
                    if (user.UPsw == Psw)
                    {
                        HttpContext.Current.Session.Add("uID", user.UID);
                        HttpContext.Current.Session.Add("uPsw", user.UPsw);
                        HttpContext.Current.Session.Add("uSex", user.USex);
                        HttpContext.Current.Session.Add("uEditor", user.UEditor);
                        HttpContext.Current.Session.Add("uName", user.UName);
                        HttpContext.Current.Session.Add("uNickname", user.UNickname);
                        HttpContext.Current.Session.Add("uPhoto", user.UPhoto);
                        HttpContext.Current.Session.Add("uPhone", user.UPhone);
                        HttpContext.Current.Session.Add("uAddress", user.UAddress);
                        HttpContext.Current.Session.Timeout = 5;
                        HttpContext.Current.Response.Write("<script>alert('登陆成功！');window.location='" + aspx + "';</script>");
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>alert('登陆失败，请重新登陆！');</script>");
                    }
                }
                else if (UserOrManeger == "manager")
                {
                    Manager manager = func.SelectManager(IDorPhone);
                    //HttpContext.Current.Response.Write("<script>alert('警告！ + " + Psw + "');window.location='" + aspx + "'</script>");

                    if (manager.MPsw.Trim() == Psw.Trim())
                    {
                        HttpContext.Current.Session.Add("mID", IDorPhone);
                        HttpContext.Current.Session.Add("mPsw", Psw);
                        switch (MID)
                        {
                            case "游戏管理员":
                                HttpContext.Current.Response.Write("<script language=javascript>alert('游戏管理员登陆成功！');window.location='游戏管理.aspx'</script>");
                                break;
                            case "进货员":
                                HttpContext.Current.Response.Write("<script language=javascript>alert('进货管理员登陆成功！');window.location='进货管理.aspx'</script>");
                                break;
                            case "销售员":
                                HttpContext.Current.Response.Write("<script language=javascript>alert('订单管理员登陆成功！');window.location='订单管理.aspx'</script>");
                                break;
                        }

                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script language=javascript>alert('管理员登陆失败，请重新登陆！');window.location='首页.aspx'</script>");
                    }
                }

            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>alert('" + e.Message + "');window.location='首页.aspx';</script>");
            }


        }
        public void LogOut()
        {
            HttpContext.Current.Session.RemoveAll();
            /*if (UserOrManager == "User")
            {
                HttpContext.Current.Session["uID"] = null;
                HttpContext.Current.Session["uPsw"] = null;
                HttpContext.Current.Session["uSex"] = null;
                HttpContext.Current.Session["uEditor"] = null;
                HttpContext.Current.Session["uName"] = null;
                HttpContext.Current.Session["uNickname"] = null;
                HttpContext.Current.Session["uPhoto"] = null;
            }
            else if (UserOrManager == "Manager")
            {
                HttpContext.Current.Session["mID"] = null;
                HttpContext.Current.Session["mPsw"] = null;
            }*/
        }

        //个人中心
        public void Signin(string UID, string UPsw, string USex, bool UEditor, string UName, string UNickname, string UPhone, string UPhoto, string UAddress)
        {
            Function func = new Function();
            if (func.InsertUser(UID, UPsw, USex, UEditor, UName, UNickname, UPhone, UPhoto, UAddress))
            {
                HttpContext.Current.Session.Add("uPhoto", UPhoto);
                HttpContext.Current.Session.Add("uName", UName);
                HttpContext.Current.Session.Add("uID", UID);
                HttpContext.Current.Session.Add("uEditor", UEditor);
                HttpContext.Current.Session.Add("uNickname", UNickname);
                HttpContext.Current.Session.Add("uAddress", UAddress);
                HttpContext.Current.Response.Write("<script language='javascript'>alert('注册成功！');window.location='个人中心.aspx';</script>");
                //HttpContext.Current.Server.Transfer("个人中心.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("<script language='javascript'>alert('注册失败！请重新注册');window.location='个人中心.aspx';</script>");
                //HttpContext.Current.Server.Transfer("个人中心.aspx");
            }
        }
        public void ChangePrf(string UID, string USex, bool UEditor, string UName, string UNickname, string UPhoto, string UAddress)
        {
            Function func = new Function();
            func.UpdateUser(UID, USex, UEditor, UName, UNickname, UPhoto, UAddress);
            ReSession(UID);
        }
        public void ChangePsw(string UID, string newpsw)
        {
            Function func = new Function();
            func.UpdateUser1(UID, "uPsw", newpsw);
            ReSession(UID);
        }
        public void ChangePhone(string UID, string UPhone)
        {
            Function func = new Function();
            func.UpdateUser1(UID, "uPhone", UPhone);
            ReSession(UID);
        }
        /*public void Update2(string ID, string oldpsw, string newpsw)
        {
            Function func = new Function();
            if (func.SelectUser(ID).UPsw == oldpsw)
                func.UpdateUser(ID, "uPsw", newpsw);

        }
        public void Update3(string ID, string newphone)
        {
            Function func = new Function();
            func.UpdateUser(ID, "uPhone", newphone);
        }*/
        public DataTable InGridview(string UID)
        {
            Function func = new Function();
            return func.SelectMyGame(UID);
        }
        public void EnterGame(string GName)
        {
            Gamelist game = new Gamelist();
            Function func = new Function();
            game = func.SelectGamelist(GName);
            HttpCookie cookie = new HttpCookie("Game");
            HttpCookieCollection cookies = HttpContext.Current.Response.Cookies;
            cookies.Add(cookie);
            cookie.Values.Add("GName", HttpUtility.UrlEncode(game.GName));
            cookie.Values.Add("GImage", HttpUtility.UrlEncode(game.GImage));
            cookie.Values.Add("GVideo", HttpUtility.UrlEncode(game.GVideo));
            cookie.Values.Add("GWhere", HttpUtility.UrlEncode(game.GWhere));
            cookie.Values.Add("GStation", HttpUtility.UrlEncode(game.GStation));
            cookie.Values.Add("GPrice", HttpUtility.UrlEncode(game.GPrice));
            cookie.Values.Add("GInformation", HttpUtility.UrlEncode(game.GInformation));
            HttpContext.Current.Response.Redirect("游戏详情.aspx");
        }

        public DataTable MainItem()
        {
            Function func = new Function();
            return func.AllSelectGamelist();
        }

        //管理员
        public DataTable ManagerGridview()
        {
            Function func = new Function();
            return func.ManagerSelectGamelist();
        }
        public void GridviewDelete(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            Function func = new Function();
            func.DeleteGamelist(gv, e);
        }
        /*public void GridviewEdit(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Function func = new Function();
            //func.UpdateGamelist(gv, e);
        }*/
        public void GridviewUpdate(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Function func = new Function();
            func.UpdateGamelist(((System.Web.UI.WebControls.TextBox)(gv.Rows[e.RowIndex].Cells[1].Controls[0])).Text, ((System.Web.UI.WebControls.TextBox)(gv.Rows[e.RowIndex].Cells[0].Controls[0])).Text, ((System.Web.UI.WebControls.TextBox)(gv.Rows[e.RowIndex].Cells[2].Controls[0])).Text, ((System.Web.UI.WebControls.TextBox)(gv.Rows[e.RowIndex].Cells[3].Controls[0])).Text, ((System.Web.UI.WebControls.TextBox)(gv.Rows[e.RowIndex].Cells[4].Controls[0])).Text);
        }
        public void Bind(System.Web.UI.WebControls.GridView gv)    //绑定数据源
        {
            DbOp dbOp = new DbOp();
            gv.DataSource = dbOp.ManagerGridview();
            gv.DataKeyNames = new string[] { "gName" };
            gv.DataBind();
        }
        public void AddGame(string GName, string GInformation, string GPrice, string GImage, string GVideo)
        {
            Function func = new Function();
            func.InsertGamelist(GName, GInformation, GPrice, GImage, GVideo);
        }

        //添加我的游戏
        public void AddMyGame(string GName)
        {
            if (HttpContext.Current.Session["UID"].ToString() != null)
            {
                Function func = new Function();
                func.InsertMyGame(GName, HttpContext.Current.Session["UID"].ToString());
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('请先登陆');window.location='游戏详情.aspx';</script>");
            }
        }

        //添加我的游戏
        public bool SelectMyGame(string UID)
        {
            Function func = new Function();
            DataTable dt = func.SelectMyGame(UID);
            string gname = HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies["Game"]["GName"]).ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == gname)
                    return true;
            }
            return false;

        }

        //买游戏 添加我的订单
        public void BuyGame(string amount, string form)
        {
            SCart.scAmount = amount;

            Function func = new Function();
            func.InsertMyOrder(SCart.scName, SCart.scPrice, SCart.scUID, amount, form);
            func.UpdateGamelist1(SCart.scName, "gInventory", (Convert.ToUInt32(func.SelectGamelist(SCart.scName).GInventory) - 1).ToString());
        }

        //购物车传值
        public void PassSCart(string MOName, string MOPrice, string MOUID)
        {
            Function func = new Function();
            Gamelist gl = func.SelectGamelist(MOName);
            if (SCart.scName == null)
            {
                SCart.scName = MOName;
                SCart.scUID = MOUID;
                SCart.scPrice = MOPrice;
            }
            else
            {
                SCart.scName1 = MOName;
                SCart.scUID1 = MOUID;
                SCart.scPrice1 = MOPrice;
            }
        }
        //进货记录
        public void StockGame(string ORName, string ORAmount, string ORPrice, string ORForm)
        {
            Function func = new Function();
            func.InsertOrderRecord(ORName, ORAmount, ORPrice, ORForm);
            Gamelist gm = func.SelectGamelist(ORName);
            func.UpdateGamelist1(ORName, "gInventory", (Convert.ToInt32(gm.GInventory) + Convert.ToInt32(ORAmount)).ToString());

            //更改游戏库存数量
        }


        //订单管理发货
        public void Ship(bool w)
        {

            Function func = new Function();
            func.UpdateMyOrder("moStatus", "已发货", MyOrder.moTime, MyOrder.moUID);
            if (w)
            {
                func.UpdateMyOrder("moTracking", MyOrder.moTracking, MyOrder.moTime, MyOrder.moUID);
                func.UpdateMyOrder("moCompany", MyOrder.moCompany, MyOrder.moTime, MyOrder.moUID);
            }
            else
                func.UpdateMyOrder("moKey", MyOrder.moKey, MyOrder.moTime, MyOrder.moUID);
            Gamelist gm = func.SelectGamelist(MyOrder.moName);
            func.UpdateGamelist1(MyOrder.moName, "gInventory", (Convert.ToInt32(gm.GInventory) - Convert.ToInt32(MyOrder.moAmount)).ToString());
            func.UpdateGamelist1(MyOrder.moName, "gSold", (Convert.ToInt32(gm.GSold) + Convert.ToInt32(MyOrder.moAmount)).ToString());
            HttpContext.Current.Response.Write("<script>alert('发货成功！')</script>");
        }

        //传值
        //Pass pass = new Pass();
        public void PassNum(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string row1 = (e.CommandArgument).ToString();
            int row = Convert.ToInt32(row1);
            MyOrder.moTime = Convert.ToDateTime(gv.DataKeys[row]["moTime"]);
            MyOrder.moUID = gv.DataKeys[row]["moUID"].ToString();
            MyOrder.moName = gv.Rows[row].Cells[0].Text;
            MyOrder.moAmount = gv.Rows[row].Cells[3].Text;
            //pass.Row = row;
        }

        //发货确认
        public void ConfirmOrder(bool w, string MOCompany, string MOTracking, string MOKey)
        {
            MyOrder.moCompany = MOCompany;
            MyOrder.moKey = MOKey;
            MyOrder.moTracking = MOTracking;
            Ship(w);
        }




    }

    interface IInterface
    {

    }
}
