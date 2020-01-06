<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="relative_edit.aspx.cs" Inherits="FamilyTreeWebForms.WebForms.relative_edit" %>
<%@ Register TagPrefix="uc" TagName="ucRelativeEdit" Src="~/UserControls/ucRelativeEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<uc:ucRelativeEdit runat="server" ID="ucRelativeEdit" />
</asp:Content>