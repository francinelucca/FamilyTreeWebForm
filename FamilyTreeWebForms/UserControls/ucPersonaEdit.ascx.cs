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
    public partial class ucPersonaEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.fillDropDownList();
                string ID = Request.QueryString["ID"];
                if (ID != null)
                {
                    relativesPanel.Visible = true;
                    hfID.Value = ID;
                    this.fillValues(ID);
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            if(hfID.Value != null && !string.IsNullOrEmpty(hfID.Value))
            {
                persona = new PersonaDAO().getPersonaById(Convert.ToInt32(hfID.Value));
            }
            persona.BirthDay = DateTime.Parse(txtBirthday.Text);
            persona.FirstName = txtFirstName.Text;
            persona.LastName = txtLastName.Text;
            persona.Gender = ddlGender.SelectedValue;

            if(persona.id == 0)
            {
                persona.createdAt = DateTime.Now;
                new PersonaDAO().createPersona(persona);
            }
            else
            {
                persona.updatedAt = DateTime.Now;
                new PersonaDAO().updatePersona(persona);
            }
            Response.Redirect("~/WebForms/personas_list");

        }

        protected void fillDropDownList()
        {
            ddlGender.Items.Add(new ListItem(Persona.FEMALE_GENDER_STRING, Persona.FEMALE_GENDER_VALUE));
            ddlGender.Items.Add(new ListItem(Persona.MALE_GENDER_STRING, Persona.MALE_GENDER_VALUE));
        }

        protected void fillValues(string ID)
        {
            Persona persona = new PersonaDAO().getPersonaById(Convert.ToInt32(ID));
            if(persona != null)
            {
                txtFirstName.Text = persona.FirstName;
                txtLastName.Text = persona.LastName;
                ddlGender.SelectedValue = persona.Gender;
                txtBirthday.Text = persona.birthdayFormat;
                this.relativesGridView_GetData();
            }
        }

        protected void ButtonEditRelative_Click(object sender, ImageClickEventArgs e)
        {
            var relativeId = ((ImageButton)sender).CommandArgument;
            Response.Redirect(String.Format("~/WebForms/relative_edit?ID={0}&personaId={1}", relativeId,hfID.Value));
        }

        protected void ButtonDeleteRelative_Click(object sender, ImageClickEventArgs e)
        {
            var relativeId = ((ImageButton)sender).CommandArgument;
            hfRelativeID.Value = relativeId;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

        }

        protected void btnDeleteRelative_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfRelativeID.Value))
            {
                new RelativeDAO().deleteRelative(Convert.ToInt16(hfRelativeID.Value));
                relativesGridView_GetData();
            }
        }

        protected void btnAddRelative_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/WebForms/relative_edit?personaId={0}", hfID.Value));
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public void relativesGridView_GetData()
        {
            string personaID = hfID.Value;
            if (!string.IsNullOrEmpty(personaID))
            {
               relativesGridView.DataSource =  new PersonaDAO().getPersonaById(Convert.ToInt32(personaID)).Relatives.AsQueryable();
               relativesGridView.DataBind();
            }
        }
    }
}