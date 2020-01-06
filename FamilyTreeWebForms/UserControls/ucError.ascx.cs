using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyTreeWebForms.UserControls
{
    public partial class ucError : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ShowError(string error)
        {
            lblerrorMessage.Text = error;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowErrorPopup();", true);
        }
    }
}