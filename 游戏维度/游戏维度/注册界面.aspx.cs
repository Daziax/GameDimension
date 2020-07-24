using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 注册界面 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }



    protected void Login_Click(object sender, EventArgs e)
    {
        /*LoginBox.Visible = true;*/
        Response.Redirect("首页.aspx");
    }
    protected void Loginin_Click(object sender, EventArgs e)
    {
        DbOp dbop = new DbOp();
        dbop.Loginin("user", tbid.Text.ToString(), tbPsw.Text.ToString());
        LoginBox.Visible = true;
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        LoginBox.Visible = false;
        Session.RemoveAll();
        Server.Transfer("注册界面.aspx");
    }

    protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        if (cb1.Checked)
        {
            if (Page.IsValid)
            {
                Session.Add("uPhone", tb1.Text.ToString());
                Session.Add("uPsw", tb2.Text.ToString());

                if (rdb1.Checked == true)
                    Session.Add("uSex", "男");
                else if (rdb2.Checked == true)
                    Session.Add("uSex", "女");
                string filestr;
                if (fu.HasFile)
                {
                    filestr = "\\头像\\" + fu.PostedFile.FileName;
                    try
                    {
                        fu.PostedFile.SaveAs(Server.MapPath("") + filestr);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(‘文件上传失败'" + ex.Message + ")</script>");
                    }
                }
                else
                { Response.Write("<script>alert('请上传头像！')</script>"); return; }
                DbOp dbop = new DbOp();
                dbop.Signin(tbid.Text.Trim(), Session["uPsw"].ToString(), Session["uSex"].ToString(), false, tbname.Text.Trim(), tbnick.Text.Trim(), Session["uPhone"].ToString(), filestr, "");
               
             
                Response.Write("<script>alert('请进一步完善注册');window.location='个人中心.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('注册失败，请检查账号密码是否符合要求');window.location='注册界面.aspx';</script>");
            }


        }
        else
        {
            Response.Write("alert('请先勾选该条例！')");
        }

       
    }
}