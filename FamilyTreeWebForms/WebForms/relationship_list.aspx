<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relationship_list.aspx.cs" Inherits="FamilyTreeWebForms.WebForms.relationship_list" %>
<%@ Register TagPrefix="uc" TagName="ucRelationshipList" Src="~/UserControls/ucRelationshipList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<uc:ucRelationshipList runat="server" ID="ucRelationshipList" />
</asp:Content>
