<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaEntidadEdit.ascx.cs" Inherits="UI.Web.SistemaEntidadEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionSistemaEntidad"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionSistemaEntidad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaEntidad"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaEntidad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadTipo" Text="Tipo de Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntidadTipo" runat="server"   ControlToValidate="txtEntidadTipo"  ValidationGroup="EditionSistemaEntidad"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvEntidadTipo" runat="server" ControlToValidate="txtEntidadTipo"  ValidationGroup="EditionSistemaEntidad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtEntidadTipo"  Width="400px"  MaxLength="50"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadClase" Text="Clase de Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntidadClase" runat="server"   ControlToValidate="txtEntidadClase"  ValidationGroup="EditionSistemaEntidad"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntidadClase" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadClaseBase" Text="Clase Base de Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntidadClaseBase" runat="server"   ControlToValidate="txtEntidadClaseBase"  ValidationGroup="EditionSistemaEntidad"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntidadClaseBase" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liIncluirSeguridad" Text="Incluir Seguridad" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkIncluirSeguridad" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liIncluirConfiguracion" Text="Incluir Configuración" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkIncluirConfiguracion" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
</table>
<asp:Panel runat="server" GroupingText="Acciones"  ID="pnlFilterAcciones" >
    <div>
         <asp:DataList ID="dlAcciones" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" >
            <ItemTemplate>
                <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("SistemaAccion_Nombre") %>' runat="server" />
                <asp:HiddenField ID="hdValue" Value='<%# Bind("IdSistemaAccion") %>' runat="server" />
            </ItemTemplate>
         </asp:DataList>
	</div>
</asp:Panel>

<asp:Panel runat="server" GroupingText="Estados"  ID="pnlFilterEstados" >
    <div>
         <asp:DataList ID="dlEstados" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" >
            <ItemTemplate>
                <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Estado_Nombre") %>' runat="server" />
                <asp:HiddenField ID="hdValue" Value='<%# Bind("IdEstado") %>' runat="server" />
            </ItemTemplate>
         </asp:DataList>
	</div>
</asp:Panel>