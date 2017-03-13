<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoComentarioTecnicoFilter.ascx.cs"
    Inherits="UI.Web.ProyectoComentarioTecnicoFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter" style="width: 250px">
            <div>
                <asp:Literal ID="liComentarioTecnico" Text="Tipo de Comentario Técnico" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvComentarioTecnico" runat="server" ControlToValidate="ddlComentarioTecnico"
                    ValidationGroup="FilterProyectoComentarioTecnico" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:DropDownList ID="ddlComentarioTecnico" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter" style=" width:350px">
            <div>
                <asp:Literal ID="liFecha" Text="Fecha" runat="server"></asp:Literal></div>
            <uc:DateRangeInput runat="server" ID="rdFecha"  ValidationGroup="FilterProyectoComentarioTecnico"/>
        </td>
         <td class="tdFilter" style=" width:300px"><div ><asp:Literal ID="liActivo" Text="T.Proyecto" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkTipoProyecto" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td> 
        <td class="tdFilter" width="250px" >
            <table>
                <tr>
                    <td class="tdFilter">
                    </td>
                </tr>
                <tr>
                    <td class="tdFilter">
                        <asp:Panel runat="server" ID="pnlNroBapin" BorderWidth="1" BackColor=" #e6f7ff">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="height: 20px;
                                padding: 10px;">
                                <tr>
                                    <td class="tdFilter" align="center">
                                        <div>
                                            <asp:Literal ID="liNroProyecto" Text="Código BAPIN /<br />Nro. Préstamo" runat="server"></asp:Literal>&nbsp;
                                            <asp:RegularExpressionValidator
                                                ID="revNroProyecto" runat="server" ControlToValidate="txtNroProyecto" ValidationGroup="FilterProyecto"
                                                Text="*" Width="1px" Height="1px" ErrorMessage="El Nro. de Proyecto no es válido"></asp:RegularExpressionValidator>
                                        
                                            <asp:TextBox ID="txtNroProyecto" runat="server" type="text" min="0" Width="70px" CssClass="field_input"></asp:TextBox>
                                            </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>        
    </tr>
    <tr>
        <td class="tdFilter" colspan="3">
            <div>
                <asp:Literal ID="liUsuario" Text="Usuario" runat="server"></asp:Literal>&nbsp;
<%--                <asp:RequiredFieldValidator
                    ID="rfvUsuarioModificacion" runat="server" ControlToValidate="ddlUsuario"
                    ValidationGroup="FilterProyectoComentarioTecnico" Text="*" Width="1px" Height="1px">
                    </asp:RequiredFieldValidator>--%>
            </div>
            <div>
                <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>          
        </td>        
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="FilterProyectoComentarioTecnico" />
        </td>
    </tr>
</table>
