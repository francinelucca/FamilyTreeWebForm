<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRelationshipEdit.ascx.cs" Inherits="FamilyTreeWebForms.UserControls.ucRelationshipEdit" %>
<div class="row">
    <h2>Relationship</h2>
    <br />
 <div class="control-group">
<asp:Label text="Relationship" runat="server" ID="Relationship"/> 
<asp:TextBox id="txtRelationship" runat="server" />
<asp:RequiredFieldValidator runat="server" id="redRelationship" controltovalidate="txtRelationship" errormessage="Please enter Relationship Name!" />
 </div>   
<asp:Button id="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
<asp:HiddenField ID="hfID" runat="server" />  
</div>