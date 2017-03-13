<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_PrestamoDictamenHead.ascx.cs" Inherits="UI.Web.WebControl_PrestamoDictamenHead" %>
<asp:UpdatePanel ID="updHeadPanel" runat = "server" UpdateMode ="Conditional" >
    <ContentTemplate >
        <table runat="server" ID="tbHead" >
            <tr>
                <td><b><asp:Label ID="lblNumero" runat="server" ></asp:Label>
                    </b>&nbsp;&nbsp;
                        <asp:Label ID="lblId" runat ="server" ></asp:Label>
                        &nbsp;-&nbsp;
                        <asp:Label ID="lblDescripcion" runat="server" ></asp:Label></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
