using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 个人中心 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoginBox.Visible = false;
        LeftMiddle3.Visible = false;
        LeftMiddle2.Visible = false;
        if (!IsPostBack)
        {
       
            //if (Session.Count == 2)
            //{
            //    btnpho.Visible = false;
            //    btnprf.Visible = false;
            //    mmgg.Visible = false;
            //    btneditor.Visible = false;
                
            //    tbid.ReadOnly = false;
            //    btnNext.Visible = true;
            //    tbphone.Visible = false;
            //}
            //else 
            if (Session.Count == 0)
            {
                Exit.Visible = false;
                Response.Write("<script>alert('长时间未操作，将返回首页！');window.location='首页.aspx';</script>");
            }
            else //Session.Count != 0 && Session.Count != 2
            {
                if (Session["uPhoto"] != null)
                    imgicon.ImageUrl = Session["uPhoto"].ToString();
                //TopBarVA1.Attributes["style"] = "display:none;";
                //TopBarVA2.Attributes["style"] = "display:inline;";
                Exit.Visible = true;
                btnNext.Attributes["style"] = "display:none";
                ImgSelfile.ImageUrl = Session["uPhoto"].ToString();
                LbName.Text = Session["uName"].ToString();
                imgicon.ImageUrl = Session["uPhoto"].ToString();
                image.ImageUrl = Session["uPhoto"].ToString();
                tbname.Text = Session["uName"].ToString();
                tbid.Text = Session["uID"].ToString();
                tbnick.Text = Session["uNickname"].ToString();
                tbpsw1.Text = Session["uPsw"].ToString();
                tbphone.Text = Session["uPhone"].ToString();
                tbaddr.Text = Session["uAddress"].ToString();
                if (Session["uSex"].ToString() == "男")
                    rdb1.Checked = true;
                else if (Session["uSex"].ToString() == "女")
                    rdb2.Checked = true;
            }
        }
    }

    protected void btnprf_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.ChangePrf(tbid.Text.Trim(), rdb1.Checked == true ? "男" : "女", tbE.Text == "您并非本站编辑" ? false : true, tbname.Text.Trim(), tbnick.Text.Trim(), fu.HasFile ? "\\头像\\" + fu.PostedFile.FileName : Session["uPhoto"].ToString(), tbaddr.Text.Trim()); ;
    }

    protected void btnpsw_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.ChangePsw(tbid.Text.Trim(), tbpsw2.Text);
    }

    protected void btnpho_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.ChangePhone(tbid.Text.Trim(), tbphone.Text);
        HttpContext.Current.Response.Write("alert(2'" + tbphone.Text + "')");
    }
    protected void btneditor_Click(object sender, EventArgs e)
    {

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('你不应该看到该页面')</script>");
        //if (rdb1.Checked == true)
        //    Session.Add("uSex", "男");
        //else if (rdb2.Checked == true)
        //    Session.Add("uSex", "女");
        //string filestr;
        //if (fu.HasFile)
        //{
        //    filestr = "\\头像\\" + fu.PostedFile.FileName;
        //    try
        //    {
        //        fu.PostedFile.SaveAs(Server.MapPath("") + filestr);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert(‘文件上传失败'" + ex.Message + ")</script>");
        //    }
        //}
        //else
        //{ Response.Write("<script>alert('请上传头像！')</script>"); return; }
        //DbOp dbop = new DbOp();
        //dbop.Signin(tbid.Text.Trim(), Session["uPsw"].ToString(), Session["uSex"].ToString(), tbE.Text.ToString() == "您并非本站编辑" ? true : false, tbname.Text.Trim(), tbnick.Text.Trim(), Session["uPhone"].ToString(), filestr,tbaddr.Text.Trim());
    }

    protected void Btn3_Click(object sender, EventArgs e)
    {
        //LeftMiddle1.Attributes["style"] = "display:none;";
        //LeftMiddle3.Attributes["style"] = "display: inline - block;letter-spacing: 14px;text - align: center;font - size: 28px;border: dotted;border - color: royalblue;width: 900px;border - style: groove;display: inline - block;position: center;border - radius: 10px; ";
        LeftMiddle3.Visible = true;
        LeftMiddle1.Visible = false;
        LeftMiddle2.Visible = false;

        DbOp dbop = new DbOp();
        gv2.DataSource = dbop.InGridview(tbid.Text);
        gv2.DataBind();
    }
    protected void Btn1_Click(object sender, EventArgs e)
    {
        //LeftMiddle1.Attributes["style"] = " letter-spacing:14px;text - align:center;font - size:28px;border: dotted;border - color: royalblue;width: 900px;border - style: groove;display: inline - block;position: center;border - radius: 10px;background - image: url("+"http://img17.3lian.com/d/file/201701/19/8b96a92eb05c5f902c22a52b9f343213.jpg"+"); ";
        //LeftMiddle3.Attributes["style"] = "display:none;";
        LeftMiddle3.Visible = false;
        LeftMiddle2.Visible = false;
        LeftMiddle1.Visible = true;
    }


    protected void Btn2_Click(object sender, EventArgs e)
    {
        LeftMiddle3.Visible = false;
        LeftMiddle2.Visible = true;
        LeftMiddle1.Visible = false;
    }


    protected void Login_Click(object sender, EventArgs e)
    {
        //LoginBox.Visible = true;
    }
    //protected void Loginin_Click(object sender, EventArgs e)
    //{
    //    DbOp dbop = new DbOp();
    //    dbop.Loginin("user", tbid3.Text.ToString(), tbpsw3.Text.ToString());
    //}

    protected void Exit_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Server.Transfer("个人中心.aspx");
    }

    protected void Information_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strUniqueID = "";
        if (e.CommandName == "Information")
        {
            int intRow = int.Parse(e.CommandArgument.ToString()); //获取当前所在行
            strUniqueID = gv2.DataKeys[intRow].Value.ToString();
        }
        DbOp dbop = new DbOp();
        dbop.EnterGame(strUniqueID);
    }
}