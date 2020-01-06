using FamilyTreeWebForms.DAO;
using FamilyTreeWebForms.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FamilyTreeWebForms.UserControls
{
    public partial class ucRelationshipEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ID = Request.QueryString["ID"];
                if (ID != null)
                {
                    this.fillValues(ID);
                    hfID.Value = ID;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Relationship relationship = new Relationship();
            if (hfID.Value != null && !string.IsNullOrEmpty(hfID.Value))
            {
                relationship = new RelationshipsDAO().getRelationshipById(Convert.ToInt32(hfID.Value));
            }
            relationship.Relationship1 = txtRelationship.Text;

            if (relationship.id == 0)
            {
                relationship.createdAt = DateTime.Now;
                new RelationshipsDAO().createRelationship(relationship);
            }
            else
            {
                relationship.updatedAt = DateTime.Now;
                new RelationshipsDAO().updateRelationship(relationship);
            }
            Response.Redirect("~/WebForms/relationship_list");

        }
        protected void fillValues(string ID)
        {
            Relationship relationship = new RelationshipsDAO().getRelationshipById(Convert.ToInt32(ID));
            if (relationship != null)
            {
                txtRelationship.Text = relationship.Relationship1;
            }
        }
    }
}