<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personas_edit.aspx.cs" Inherits="FamilyTreeWebForms.WebForms.personas_edit" %>
<%@ Register TagPrefix="uc" TagName="ucPersonaEdit" Src="~/UserControls/ucPersonaEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<uc:ucPersonaEdit runat="server" ID="ucPersonasEdit" />
</asp:Content>