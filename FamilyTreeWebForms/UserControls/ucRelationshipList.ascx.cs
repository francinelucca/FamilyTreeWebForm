using FamilyTreeWebForms.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyTreeWebForms.UserControls
{
    public partial class ucRelationshipList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.relationshipsGridView_GetData();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public void relationshipsGridView_GetData()
        {
            relationshipsGridView.DataSource = new RelationshipsDAO().getRelationships().AsQueryable();
            relationshipsGridView.DataBind();
        }

        protected void ButtonEdit_Click(object sender, ImageClickEventArgs e)
        {
            var relationshipId = ((ImageButton)sender).CommandArgument;
            Response.Redirect(String.Format("~/WebForms/relationship_edit?ID={0}", relationshipId));


        }

        protected void ButtonDelete_Click(object sender, ImageClickEventArgs e)
        {
            var relationshipId = ((ImageButton)sender).CommandArgument;
            hfID.Value = relationshipId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfID.Value))
            {
                try
                {
                    new RelationshipsDAO().deleteRelationship(Convert.ToInt16(hfID.Value));
                    relationshipsGridView_GetData();
                }
                catch(Exception error)
                {
                    this.ucError.ShowError(error.Message);
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/relationship_edit");

        }
    }
}