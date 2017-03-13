<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProyectoSeguimientoHead.ascx.cs" Inherits="UI.Web.WebControl_ProyectoSeguimientoHead" %>
<asp:UpdatePanel ID="updHeadPanel" runat = "server" UpdateMode ="Conditional" >
    <ContentTemplate >
        <table runat="server" ID="tbHead" >
            <tr>
                <td><b><asp:Label ID="lblNumeroDenominacion" runat="server" ></asp:Label></b>&nbsp;(<asp:Label ID="lblCodSaf" runat="server" ></asp:Label>)&nbsp;-&nbsp;<asp:Label ID="lblDescripcion" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>