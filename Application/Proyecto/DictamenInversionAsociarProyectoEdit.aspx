<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictamenInversionAsociarProyectoEdit.aspx.cs" Inherits="UI.Web.Proyecto.DictamenInversionAsociarProyectoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <asp:Panel ID="pnlEvaluacionDeFactibilidad" runat ="server" GroupingText ="Evaluacion de Factibilidad" >
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvProyectoDeInversion" runat= "server" >
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText ="Denominacion" SortExpression="Nombre" />
                            <asp:BoundField DataField="Denominacion" HeaderText ="Denominacion" SortExpression ="Denominacion" />
                            <%--<asp:BoundField DataField="Locali"--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlListaDeProyectos" runat ="server" GroupingText ="Lista De Proyectos" >
                        <table>
                            <tr>
                                <td>
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>

<asp:Panel ID="pnlLocalizacion" runat ="server" GroupingText="Localizacion"  >
    <asp:DataList ID="dlProvincias" runat="server" CellSpacing="0" CellPadding="0">
        <ItemTemplate>
            <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
            <asp:HiddenField ID="hdValue" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
        </ItemTemplate>
    </asp:DataList>
</asp:Panel>
<asp:Panel ID="pnlEstado" runat="server" GroupingText="Estado" >
    <table>
        <tr>
            <td align="right">
                <asp:Button ID="btEstado" runat="server" Text="Estado" OnClick="btEstado_Click"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvEstado" runat="server" >
                    <Columns>
                        <asp:BoundField  DataField="Nombre"
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
</body>
</html>

