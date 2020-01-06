<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPersonaEdit.ascx.cs" Inherits="FamilyTreeWebForms.UserControls.ucPersonaEdit" %>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .header-center{
        text-align:center;
    }
    .table-condensed tr th {
border: 0px solid #6e7bd9;
color: white;
background-color: #6e7bd9;
}

.table-condensed, .table-condensed tr td {
border: 0px solid #000;
}

tr:nth-child(even) {
background: #f8f7ff
}

tr:nth-child(odd) {
background: #fff;
}
</style>
<div class="row">
    <h2>Persona</h2>
    <br />
 <div class="control-group">
<asp:Label text="First Name" runat="server" ID="lblFirstName"/> 
<asp:TextBox id="txtFirstName" runat="server" />
<asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtFirstName" errormessage="Please enter First Name!" />
 </div>   
 <div class="control-group">
<asp:Label text="Last Name" runat="server" ID="lblLastName"/> 
<asp:TextBox id="txtLastName" runat="server" />
<asp:RequiredFieldValidator runat="server" id="reqLastName" controltovalidate="txtLastName" errormessage="Please enter Last Name!" />
 </div>   
 <div class="control-group">
    <asp:Label text="Gender" runat="server" ID="lblGender"/> 
     <asp:DropDownList ID="ddlGender" runat="server" />
 </div>   
 <div class="control-group">
<asp:Label text="BirthDay" runat="server" ID="lblBirthDay"/> 
<asp:TextBox id="txtBirthday" runat="server" textmode="Date"/>
<asp:RequiredFieldValidator runat="server" id="reqBirthDay" controltovalidate="txtBirthday" errormessage="Please enter BirthDay!" />
 <asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="txtBirthday" 
    ErrorMessage="Please enter a valid Birthday.">
</asp:CompareValidator>
 </div>  
<asp:Button id="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
<asp:Button id="btnDeleteRelative" runat="server" OnClick="btnDeleteRelative_Click" style="visibility: hidden; display: none;" />
<asp:HiddenField ID="hfID" runat="server" />  
<asp:HiddenField ID="hfRelativeID" runat="server" />  
    <asp:Panel ID="relativesPanel" runat="server" Visible="false">
            <hr />
    <h2>Relatives</h2>
    <asp:GridView runat="server" ID="relativesGridView" ItemType="FamilyTreeWebForms.DATA.Relative" DataKeyNames="id" 
    HorizontalAlign="Center"
    AutoGenerateColumns="false"  Width="100%" UseAccessibleHeader="true" CssClass="table table-condensed table-hover">
    <Columns>
            <asp:BoundField DataField="RelatedTo.fullName" HeaderText="Relative" ReadOnly="True" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="header-center"/>
            <asp:BoundField DataField="Relationship.relationship1" HeaderText="Relationship" ReadOnly="True" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="header-center" />
        <asp:TemplateField HeaderStyle-Width="40">
    <ItemTemplate>
        <asp:ImageButton ID="ButtonEditRelative" runat="server"  
            ImageUrl="~/Images/editIcon.png" OnClick="ButtonEditRelative_Click" ToolTip="Edit"
            CommandArgument='<%#Bind("id")%>'/>
        <asp:ImageButton ID="ButtonDeleteRelative" runat="server"  
            ImageUrl="~/Images/deleteIcon.png" OnClick="ButtonDeleteRelative_Click" ToolTip="Delete"
            CommandArgument='<%#Bind("id")%>'/>
    </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button id="btnAddRelative" Text="Add Relative" runat="server" OnClick="btnAddRelative_Click" />
    </asp:Panel>
</div>
<script type="text/javascript">
     function ShowPopup() {
        $(function () {
            $("#Dialog").dialog({
                title: "Confirm Delete",
                buttons: {
                    Delete: function () {
                     $( this ).dialog( "close" );
                     $("#<%=btnDeleteRelative.ClientID%>").click();
                        return true;
                    },
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };

    $(document).ready(function () {

});
</script>