using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI
{
    public partial class DefaultUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Font.Size = 14;
           
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            lblMessage.Text = "Seja bem vindo " + Session["Usuario"] + " a Phobos Anomaly!! ";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../login.aspx");

        }
    }
}