<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRelationshipList.ascx.cs" Inherits="FamilyTreeWebForms.UserControls.ucRelationshipList" %>
<%@ Register TagPrefix="uc" TagName="ucError" Src="~/UserControls/ucError.ascx" %>
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
    <uc:ucError runat="server" ID="ucError" />
            <h2>Relationships</h2>
    <asp:GridView runat="server" ID="relationshipsGridView" ItemType="FamilyTreeWebForms.DATA.Relationship" DataKeyNames="id" 
    HorizontalAlign="Center"
    AutoGenerateColumns="false" Width="100%" UseAccessibleHeader="true" CssClass="table table-condensed table-hover">
    <Columns>
            <asp:BoundField DataField="relationship1" HeaderText="Relationship" ReadOnly="True" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="header-center"/>
        <asp:TemplateField HeaderStyle-Width="40">
    <ItemTemplate>
        <asp:ImageButton ID="ButtonEdit" runat="server"  
            ImageUrl="~/Images/editIcon.png" OnClick="ButtonEdit_Click" ToolTip="Edit"
            CommandArgument='<%#Bind("id")%>'/>
        <asp:ImageButton ID="ButtonDelete" runat="server"  
            ImageUrl="~/Images/deleteIcon.png" OnClick="ButtonDelete_Click" ToolTip="Delete"
            CommandArgument='<%#Bind("id")%>'/>
    </ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
        <div id="Dialog" style="display:none;">
        <div class="DialogF">
            <asp:UpdatePanel ID="confirmPnl" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
                 <h2>Are you sure you want to delete this relationship?</h2>
             </ContentTemplate>
            </asp:UpdatePanel> 
        </div>
    </div>
<asp:Button id="btnCreate" Text="Create New" runat="server" OnClick="btnCreate_Click" />
<asp:Button id="btnDelete" runat="server" OnClick="btnDelete_Click" style="visibility: hidden; display: none;" />
<asp:HiddenField ID="hfID" runat="server" />  
</div>
<script type="text/javascript">
     function ShowPopup() {
        $(function () {
            $("#Dialog").dialog({
                title: "Confirm Delete",
                buttons: {
                    Delete: function () {
                     $( this ).dialog( "close" );
                     $("#<%=btnDelete.ClientID%>").click();
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