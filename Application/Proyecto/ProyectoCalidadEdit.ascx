<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoCalidadEdit.ascx.cs" Inherits="UI.Web.ProyectoCalidadEdit" %>

<style type ="text/css">
    .smallCheck
    {
        font-size:x-small;
    }
</style>

<asp:Panel ID="pnlHojaDeCalidad" runat="server" GroupingText ="Hoja de Calidad" >
 <asp:UpdatePanel ID= "upCalidad"  runat="server" UpdateMode = "Conditional" >
 <ContentTemplate>
 <asp:Panel ID="pnl" runat="server" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td ><asp:Literal ID="litEstadoGral" runat="server" Text="Estado"></asp:Literal></td>
            <td colspan='3' style="font-size:14px;font-weight:bold"><asp:Label runat="server" ID="lblEstado"></asp:Label></td>
        </tr>
        <tr>
            <td colspan='4'>&nbsp;</td>
        </tr>        
        <tr>
            <td style="width:15%">&nbsp;</td>
            <td style="width:35%"><asp:Literal ID="litActual" runat="server" Text="Actual"></asp:Literal></td>                        
            <td style="width:35%"><asp:Literal ID="litSugerido" runat="server" Text="Sugerido"></asp:Literal></td>                        
            <td style="width:10%;text-align:center"><asp:Literal ID="litAceptado" runat="server" Text="Aceptar"></asp:Literal></td>
        </tr>
        <tr>
            <td><asp:Literal ID="litDenominacion" runat="server" Text="Denominación"></asp:Literal></td>
            <td><asp:TextBox ID="tbDenominacionActual" runat="server" TextMode="MultiLine" Rows="3" Enabled="false" Width="270"></asp:TextBox></td>
            <td><asp:TextBox ID="tbDenominacionSugerido" runat="server" TextMode="MultiLine" Rows="3" Enabled="false" Width="270"></asp:TextBox></td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoDenominacion" runat="server" /></td>            
        </tr>
        <tr>
            <td><asp:Literal ID="litTipoProyecto" runat="server" Text="Tipo de Proyecto"></asp:Literal></td>
            <td><asp:DropDownList ID="ddlTipoProyectoActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlTipoProyectoSugerido" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoTipoProyecto" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal></td>
            <td><asp:DropDownList ID="ddlEstadoActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlEstadoSugerido" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoEstado" runat="server" /></td>            
        </tr>                    
        <tr>
            <td><asp:Literal ID="litProceso" runat="server" Text="Proceso"></asp:Literal></td>
            <td><asp:DropDownList ID="ddlProcesoActual" runat="server"  Enabled="false" ></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlProcesoSugerido" runat="server"  Enabled="false" ></asp:DropDownList></td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoProceso" runat="server" /></td>
        </tr>                    
        <tr>
            <td><asp:Literal ID="litFinalidad" runat="server" Text="Finalidad Función"></asp:Literal></td>
            <td><asp:DropDownList ID="ddlFinalidadActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlFinalidadSugerido" runat="server" Enabled="false" ></asp:DropDownList></td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoFinalidad" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Literal ID="litProvincias" runat="server" Text="Provincias"></asp:Literal></td>
            <td >
                <table ><tr><td style="vertical-align:top">
                    <asp:DataList ID="dlProvinciasA" runat="server" CellSpacing="0" CellPadding="0">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkA" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                            <asp:HiddenField ID="hdValueA" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                </td><td valign="top">
                   <asp:DataList ID="dlProvinciasB" runat="server"  CellSpacing="0" CellPadding="0">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkB" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                            <asp:HiddenField ID="hdValueB" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                </td></tr></table>
            </td>
            <td>
                <table ><tr><td  style="height:50px;vertical-align:top">
                    <asp:DataList ID="dlProvinciasC" runat="server"  CellSpacing="0" CellPadding="0">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkD" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                            <asp:HiddenField ID="hdValueC" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                </td><td valign="top" style="height:50px">
                   <asp:DataList ID="dlProvinciasD" runat="server" CellSpacing="0" CellPadding="0">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkD" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                            <asp:HiddenField ID="hdValueD" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                        </ItemTemplate>
                    </asp:DataList>
                </td></tr></table>            
            </td>
            <td style="text-align:center"><asp:CheckBox ID="cbAceptadoLocalizacion" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Literal ID="litComentario" runat="server" Text="Comentarios"></asp:Literal></td>        
            <td colspan='3'><asp:TextBox ID="tbComentario" runat="server" TextMode="MultiLine" Rows="3" Enabled="false" Width="784"></asp:TextBox></td>
        </tr>
    </table>     
    </asp:Panel>       
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Panel>
