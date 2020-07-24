using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 首页 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginBox.Visible = false;
        ManagerLogin.Visible = false;
        DbOp dbOp = new DbOp();
        lb1.Text = dbOp.MainItem().Rows[0][0].ToString();
        img1.ImageUrl= dbOp.MainItem().Rows[0][4].ToString();
        lb2.Text = dbOp.MainItem().Rows[1][0].ToString();
        img2.ImageUrl = dbOp.MainItem().Rows[1][4].ToString();
        if(dbOp.MainItem().Rows.Count>2)
        { lb3.Text = dbOp.MainItem().Rows[2][0].ToString();
            img3.ImageUrl = dbOp.MainItem().Rows[2][4].ToString();
        }

        
        if (Session.Count != 0 && Session.Count != 2)
        {
            if (Session["uPhoto"] != null)
                imgicon.ImageUrl = Session["uPhoto"].ToString();
            TopBarVA1.Attributes["style"] = "display:none;";
            TopBarVA2.Attributes["style"] = "display:inline;";
        }
        else
        {
            TopBarVA1.Attributes["style"] = "display:inline;";
            TopBarVA2.Attributes["style"] = "display:none;";
        }
    }

    protected void SchBtn_Click(object sender, ImageClickEventArgs e)
    {

    }


    protected void Login_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        LoginBox.Visible = true;
        //LoginBox.Attributes["style"] = "display:block; z-index: 999999;padding:20px;background-color:aliceblue;text-align:center;border-radius: 20px; width: 500px; height: 320px; margin: auto; position: fixed; Top: 0; left: 0; right: 0; bottom: 0; ";
    }
    protected void Loginin_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.Loginin("user", tbID.Text.ToString(), tbPsw.Text.ToString());

    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        LoginBox.Visible = false;
        Session.RemoveAll();
        Server.Transfer("首页.aspx");
    }

    protected void BtnMLogin_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        ManagerLogin.Visible = true;
        //ManagerLogin.Attributes["style"] = "display:block; z-index: 999999;padding:20px;background-color:aliceblue;text-align:center;border-radius: 20px; width: 500px; height: 320px; margin: auto; position: fixed; Top: 0; left: 0; right: 0; bottom: 0; ";
    }
    protected void BtnMLoginin_Click(object sender, EventArgs e)
    {
        DbOp db = new DbOp();
        db.Loginin("manager", tbMID.Text.Trim(), tbMPsw.Text.Trim(),dpdlMID.Text);
        ManagerLogin.Visible = false;
    }
    protected void ButMExit_Click(object sender, EventArgs e)
    {
        DbOp db = new DbOp();
        db.LogOut();
        ManagerLogin.Visible = false;
    }




    protected void img1_Click(object sender, ImageClickEventArgs e)
    {
        DbOp db = new DbOp();
        db.EnterGame(lb1.Text);
    }

    protected void img2_Click(object sender, ImageClickEventArgs e)
    {
        DbOp db = new DbOp();
        db.EnterGame(lb2.Text);
    }

    protected void img3_Click(object sender, ImageClickEventArgs e)
    {
        DbOp db = new DbOp();
        db.EnterGame(lb3.Text);
    }
}