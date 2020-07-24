using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 管理员页面 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DbOp dbOp = new DbOp();
            dbOp.Bind(gv);
        }
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DbOp db = new DbOp();
        db.GridviewDelete(gv, e);
        db.Bind(gv);
    }



    protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        DbOp db = new DbOp();
        db.Bind(gv);
    }

    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        DbOp db = new DbOp();
        db.GridviewUpdate(gv, e);
        db.Bind(gv);
    }

    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        DbOp db = new DbOp();
        db.Bind(gv);
    }

    protected void AddGame_Click(object sender, EventArgs e)
    {
        string filestr1 = "";
        string filestr2 = "";
        if (fu1.HasFile)
        {
            filestr1 = "\\Resources\\Image\\" + fu1.PostedFile.FileName;
            try
            {
                fu1.PostedFile.SaveAs(Server.MapPath("") + filestr1);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('文件上传失败'" + ex.Message + ")</script>");
            }
        }
        if (fu2.HasFile)
        {
            filestr2 = "\\Resources\\Image\\" + fu2.PostedFile.FileName;
            try
            {
                fu2.PostedFile.SaveAs(Server.MapPath("") + filestr2);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(‘文件上传失败'" + ex.Message + ")</script>");
            }
        }
        else
        { Response.Write("<script>alert('文件上传失败')</script>"); return; }
        DbOp db = new DbOp();
        db.AddGame(tb1.Text.ToString(), tb3.Text, tb2.Text, filestr1, filestr2);
        db.Bind(gv);
    }


}