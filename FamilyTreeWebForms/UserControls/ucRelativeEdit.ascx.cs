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
    public partial class ucRelativeEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string ID = Request.QueryString["ID"];
                string personaId = Request.QueryString["personaId"];
                this.fillDropDowns(personaId);
                if (ID != null)
                {
                    this.fillValues(ID);
                    hfID.Value = ID;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Relative relative = new Relative();
            if (hfID.Value != null && !string.IsNullOrEmpty(hfID.Value))
            {
                relative = new RelativeDAO().getRelativeById(Convert.ToInt32(hfID.Value));
            }
            relative.RelativeId = Convert.ToInt32(ddlRelative.SelectedValue);
            relative.PersonaId = Convert.ToInt32(ddlPersona.SelectedValue);
            relative.RelationshipId = Convert.ToInt32(ddlRelationship.SelectedValue);


            if (relative.id == 0)
            {
                relative.createdAt = DateTime.Now;
                new RelativeDAO().createRelative(relative);
            }
            else
            {
                relative.updatedAt = DateTime.Now;
                new RelativeDAO().updateRelative(relative);
            }
            Response.Redirect(string.Format("~/WebForms/personas_edit?ID={0}",relative.PersonaId));

        }
        protected void fillValues(string ID)
        {
            Relative relative = new RelativeDAO().getRelativeById(Convert.ToInt32(ID));
            if (relative != null)
            {
                ddlRelative.SelectedValue = relative.RelativeId.ToString();
                ddlPersona.SelectedValue = relative.PersonaId.ToString();
                ddlRelationship.SelectedValue = relative.RelationshipId.ToString();
            }
        }

        protected void fillDropDowns(string personaId)
        {
            List<Persona> personas = new PersonaDAO().getPersonas();
            List<Relationship> relationships = new RelationshipsDAO().getRelationships();

            foreach(Persona p in personas)
            {
                if(p.id.ToString() != personaId)
                {
                    ddlRelative.Items.Add(new ListItem(p.fullName, p.id.ToString()));
                }
                else
                {
                    ddlPersona.Items.Add(new ListItem(p.fullName, p.id.ToString()));
                }
            }

            foreach (Relationship r in relationships)
            {
                ddlRelationship.Items.Add(new ListItem(r.Relationship1, r.id.ToString()));
            }
        }
    }
}