using FamilyTreeWebForms.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyTreeWebForms.UserControls
{
    public partial class ucPersonasList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            personasGridView_GetData();

            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public void personasGridView_GetData()
        {
            personasGridView.DataSource = new PersonaDAO().getPersonas().AsQueryable();
            personasGridView.DataBind(); 
        }

        protected void ButtonEdit_Click(object sender, ImageClickEventArgs e)
        {
            var personaId = ((ImageButton)sender).CommandArgument;
            Response.Redirect(String.Format("~/WebForms/personas_edit?ID={0}", personaId));


        }

        protected void ButtonDelete_Click(object sender, ImageClickEventArgs e)
        {
            var personaId = ((ImageButton)sender).CommandArgument;
            hfID.Value = personaId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfID.Value))
            {
                try
                {
                    new PersonaDAO().deletePersona(Convert.ToInt16(hfID.Value));
                    personasGridView_GetData();
                }
                catch(Exception ex)
                {
                    ucError.ShowError(ex.Message);
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/personas_edit");

        }
        
    }
}