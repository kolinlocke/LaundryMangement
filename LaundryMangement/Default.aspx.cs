using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaundryMangement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Request.Browser.IsMobileDevice

            this.Response.Redirect("~/Pages/WebForm1.aspx");
        }
    }
}