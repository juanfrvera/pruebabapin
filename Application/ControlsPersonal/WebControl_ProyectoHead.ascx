<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="WebControl_ProyectoHead.ascx.cs"
    Inherits="UI.Web.WebControl_ProyectoHead" %>
<asp:UpdatePanel ID="updHeadPanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table runat="server" id="tbHead">
            <tr>
                <td>
                    <b>
                        <asp:Label ID="lblNumero" runat="server"></asp:Label>
                    </b>
                    &nbsp;-&nbsp;
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>
                        <asp:Literal ID="liIngreso" Text="Ingreso" runat="server"></asp:Literal>:</b>
                    <asp:Label ID="lblFechaIngreso" runat="server"></asp:Label>&nbsp;-&nbsp; <b>
                        <asp:Literal ID="liUltimaModificacion" Text="Última modificación" runat="server"></asp:Literal>:</b>
                    <asp:Label ID="lblFechaUltimaModificacion" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblInactive" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
