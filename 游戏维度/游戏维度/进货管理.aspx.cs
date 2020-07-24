using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


public partial class 库存管理 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (!IsPostBack)
        {
            DbOp dbOp = new DbOp();
            dbOp.Bind(gv1);
        }*/
    }

    protected void AdIvtr_Click(object sender, EventArgs e)
    {
        DbOp db = new DbOp();
        db.StockGame(GameName.Text, Amount.Text, Price.Text, Form.SelectedValue);
    }
}