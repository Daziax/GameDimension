using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using BLL;

public partial class 游戏详情 : System.Web.UI.Page
{
    protected void Page_Prerender(object sender,EventArgs e)
    {
        UserIcon.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginBox.Visible = false;
        if (Session.Count != 0)
        {
            if(Session["UPhoto"]!=null)
                imgicon.ImageUrl = Session["UPhoto"].ToString();
            TopBarVA1.Attributes["style"] = "display:none;";
            TopBarVA2.Attributes["style"] = "display:inline;";
        }
        else
        {
            TopBarVA1.Attributes["style"] = "display:inline;";
            TopBarVA2.Attributes["style"] = "display:none;";
        }
        if(Request.Cookies.Count!=0)
        {
            //Response.Write("<script>alert('"+ HttpUtility.UrlDecode(Request.Cookies["Game"]["GVideo"]).ToString() + "');window.location='个人中心.aspx'</script>");
            ImgBk.Attributes["style"] = "background-image: url("+ HttpUtility.UrlDecode(Request.Cookies["Game"]["GVideo"]).ToString()+");background-position: center top;background - repeat: no - repeat;background - size: 100 % auto;background - size: cover;width: 100 %;height: 100 %; ";
            img1.ImageUrl = HttpUtility.UrlDecode(Request.Cookies["Game"]["GImage"]).ToString();
            TopTitle.Text= HttpUtility.UrlDecode(Request.Cookies["Game"]["GName"]).ToString();
            Para.Text= HttpUtility.UrlDecode(Request.Cookies["Game"]["GInformation"]).ToString();
            Price.Text = "价格:" + HttpUtility.UrlDecode(Request.Cookies["Game"]["GPrice"]).ToString()+"元";
            
        }
        DbOp db = new DbOp();
        if (Session["UID"] != null)
        {
            if (db.SelectMyGame(Session["UID"].ToString()))
                ThePlayer.Visible = true;
            else
                ThePlayer.Visible = false;
        }
        else
            ThePlayer.Visible = false;

    }

    protected void btnWanna_Click(object sender, EventArgs e)
    {
        DbOp dbOp = new DbOp();
        dbOp.PassSCart(TopTitle.Text, Price.Text.Substring(3, Price.Text.Length - 4), Session["UID"].ToString());
        Response.Write("<script>alert('成功添加至购物车');</script>");
    }

    protected void btnPlayed_Click(object sender, EventArgs e)
    {
        DbOp dbOp = new DbOp();
        dbOp.AddMyGame(TopTitle.Text);
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        LoginBox.Visible = true;
        //LoginBox.Attributes["style"] = "display:block; z-index: 999999;padding:20px;background-color:aliceblue;text-align:center;border-radius: 20px; width: 500px; height: 320px; margin: auto; position: fixed; Top: 0; left: 0; right: 0; bottom: 0; ";
    }
    protected void Loginin_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.Loginin("user", tbID.Text.ToString(), tbPsw.Text.ToString());
        LoginBox.Visible = false;
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        LoginBox.Visible = false;
        Session.RemoveAll();
    }
    protected void Buy_Click(object sender, EventArgs e)
    {
        DbOp db = new DbOp();
        db.PassSCart(TopTitle.Text, Price.Text.Substring(3, Price.Text.Length - 4), Session["UID"].ToString());
        Server.Transfer("购买页面.aspx");
        //db.SCard(TopTitle.Text, Price.Text.Substring(3, Price.Text.Length - 4), Session["UID"].ToString());
        //db.BuyGame(TopTitle.Text, Price.Text.Substring(3,Price.Text.Length-4), Session["UID"].ToString());
    }
}