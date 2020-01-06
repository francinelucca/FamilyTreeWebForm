<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucError.ascx.cs" Inherits="FamilyTreeWebForms.UserControls.ucError" %>
<div class="row">
    <div id="DialogError" style="display:none;">
        <div class="DialogF">
            <asp:UpdatePanel ID="confirmPnl" runat="server" UpdateMode="Conditional">
             <ContentTemplate>
                 <asp:Label ID="lblerrorMessage" runat="server" />
             </ContentTemplate>
            </asp:UpdatePanel> 
        </div>
    </div>
</div>
<script type="text/javascript">
     function ShowErrorPopup() {
        $(function () {
            $("#DialogError").dialog({
                title: "",
                buttons: {
                    OK: function () {
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