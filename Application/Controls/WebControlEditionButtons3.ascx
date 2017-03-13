<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControlEditionButtons3.ascx.cs" Inherits=" UI.Web.WebControlEditionButtons3" %>
<%--
<asp:Button ID="btDelete" runat="server" Text="Eliminar" OnClick="btDelete_Click"
    SkinID="LightButton" CausesValidation="True" Width="170px" />
    --%>
    <div style="text-align:center">
<asp:Button ID="btAplicate" runat="server" Text="Guardar" OnClick="btAplicate_Click" 
    SkinID="LightButton" CausesValidation="True"  />
<asp:Button ID="btSave" runat="server" Text="Guardar y Cerrar " OnClick="btSave_Click" SkinID="LightButton"
    CausesValidation="True"  />
<asp:Button ID="btSaveAndNew" runat="server" Text="Guardar y Crear Nuevo" OnClick="btSaveAndNew_Click" 
    SkinID="LightButton" CausesValidation="True"  />
<asp:Button ID="btCancel" runat="server" Text="Cerrar" OnClick="btCancel_Click"
    SkinID="LightButton" CausesValidation="False" />
<asp:Button ID="btPrint" runat="server" Text="Imprimir" OnClick="btPrint_Click"
    SkinID="LightButton" CausesValidation="False" />
    </div>