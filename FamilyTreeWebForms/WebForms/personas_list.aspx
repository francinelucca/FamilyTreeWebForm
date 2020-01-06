<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personas_list.aspx.cs" Inherits="FamilyTreeWebForms.WebForms.personas_list" %>
<%@ Register TagPrefix="uc" TagName="ucPersonasList" Src="~/UserControls/ucPersonasList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<uc:ucPersonasList runat="server" ID="ucPersonasList" />
</asp:Content>