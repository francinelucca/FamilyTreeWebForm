<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relationship_edit.aspx.cs" Inherits="FamilyTreeWebForms.WebForms.relationship_edit" %>
<%@ Register TagPrefix="uc" TagName="ucRelationshipEdit" Src="~/UserControls/ucRelationshipEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<uc:ucRelationshipEdit runat="server" ID="ucRelationshipEdit" />
</asp:Content>
