using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class 订单详情 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gv1.DataBind();
            digital.Visible = true;
            entity.Visible = false;
            v3.Visible = false;
            bool a = rbe.Checked;
            bool b = rbd.Checked;
        }
    }


    protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Shipped_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        v3.Visible = true;
        DbOp dbop = new DbOp();
        dbop.PassNum(gv1, e);//需要传值
    }
    protected void Next_Click(object sender, ImageClickEventArgs e)
    {
        DbOp dbop = new DbOp();
        if (rbe.Checked)
        {
            dbop.ConfirmOrder(true, tbCompany.Text.Trim(), tbTracking.Text.Trim(), "0");
            
        }
        else
        {
            dbop.ConfirmOrder(false, "0", "0", tbKey.Text.Trim());
        }
        gv1.DataBind();

    }
    protected void rbe_CheckedChanged(object sender, EventArgs e)
    {

        if (rbe.Checked)
        {
            digital.Visible = false;
            entity.Visible = true;
        }
        else
        {
            digital.Visible = true;
            entity.Visible = false;
        }
    }



    protected void Exit_Click(object sender, EventArgs e)
    {
        v3.Visible = false;
    }





    protected void rbd_CheckedChanged(object sender, EventArgs e)
    {
        if (!rbd.Checked)
        {
            digital.Visible = false;
            entity.Visible = true;
        }
        else
        {
            digital.Visible = true;
            entity.Visible = false;
        }
    }
}