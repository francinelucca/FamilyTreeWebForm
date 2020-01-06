<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRelativeEdit.ascx.cs" Inherits="FamilyTreeWebForms.UserControls.ucRelativeEdit" %>
<div class="row">
    <h2>Relative</h2>
    <br />
 <div class="control-group">
<asp:Label text="Persona" runat="server" ID="lblPersona"/> 
<asp:DropDownList id="ddlPersona" runat="server" disabled="disabled"/>
 </div>   
 <div class="control-group">
<asp:Label text="Relative" runat="server" ID="lblRelative"/> 
<asp:DropDownList id="ddlRelative" runat="server" />
 </div>   
 <div class="control-group">
    <asp:Label text="Relationship" runat="server" ID="lblRelationship"/> 
     <asp:DropDownList ID="ddlRelationship" runat="server" />
 </div>    
<asp:Button id="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
<asp:HiddenField ID="hfID" runat="server" />  
</div>
