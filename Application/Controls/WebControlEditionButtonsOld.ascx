<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlEditionButtons.ascx.cs" Inherits=" UI.Web.WebControlEditionButtons" %>
<%--
<asp:Button ID="btDelete" runat="server" Text="Eliminar" OnClick="btDelete_Click"
    SkinID="LightButton" CausesValidation="True" Width="170px" />

<asp:Button ID="btAplicate" runat="server" Text="Aplicar" OnClick="btAplicate_Click"
    SkinID="LightButton" CausesValidation="True" Width="170px" />
    --%>
<asp:Button ID="btSave" runat="server" Text="Guardar y Cerrar " OnClick="btSave_Click" SkinID="LightButton"
    CausesValidation="True" Width="150px" />
<asp:Button ID="btSaveAndNew" runat="server" Text="Guardar y Crear Nuevo" OnClick="btSaveAndNew_Click"
    SkinID="LightButton" CausesValidation="True" Width="170px" />
<asp:Button ID="btCancel" runat="server" Text="Cancelar" OnClick="btCancel_Click"
    SkinID="LightButton" CausesValidation="False" Width="170px" />