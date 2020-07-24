using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class 购买页面 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (SCart.scName != null)
            {
                Name.Text = SCart.scName;
                Amount.Text = SCart.scAmount;
                UID.Text = SCart.scUID;
                Price.Text = SCart.scPrice;
                if(SCart.scName1!=null)
                {
                    Name1.Text = SCart.scName1;
                    Amount1.Text = SCart.scAmount1;
                    UID1.Text = SCart.scUID1;
                    Price1.Text = SCart.scPrice1;
                }
            }
            else if(SCart.scName1!=null)
            {
                Name.Text = SCart.scName1;
                Amount.Text = SCart.scAmount1;
                UID.Text = SCart.scUID1;
                Price.Text = SCart.scPrice1;
            }

        }
    }

    protected void rBuy_Click(object sender, EventArgs e)
    {
        DbOp dp = new DbOp();
        if (SCart.scName != null)
        {
            dp.BuyGame(Amount.Text, Form.SelectedValue);
        }
        if (SCart.scName1 != null)
        {
            dp.BuyGame(Amount1.Text, Form2.SelectedValue);
        }
        
    }
}