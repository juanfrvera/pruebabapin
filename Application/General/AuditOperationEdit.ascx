<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationEdit.ascx.cs" Inherits="UI.Web.AuditOperationEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liAuditoriaSesion" Text="Sesión de Auditoria" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlAuditSession" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvAuditSession" runat="server" ControlToValidate="ddlAuditSession"  ValidationGroup="EditionAuditOperation"   Text="*" Width="1px" Height="1px"  InitialValue="0"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liUsuarioNombre" Text="Nombre de Usuario" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"   ControlToValidate="txtUserName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtUserName" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadNombre" Text="Nombre de la Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityName" runat="server"   ControlToValidate="txtEntityName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityName" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadBaseNombre" Text="Nombre de la Entidad Base" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityBaseName" runat="server"   ControlToValidate="txtEntityBaseName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityBaseName" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liTipoNombre" Text="Tipo de Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revTypeName" runat="server"   ControlToValidate="txtTypeName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtTypeName" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidad Text="Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityId" runat="server"   ControlToValidate="txtEntityId"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityId" Width="200px" MaxLength="30"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEntidadClave" Text="Clave de Entidad" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityKey" runat="server"   ControlToValidate="txtEntityKey"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityKey" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liModulo" Text="Modulo" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revModule" runat="server"   ControlToValidate="txtModule"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtModule" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liTipoServicio" Text="Tipo de Servicio" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revServiceType" runat="server"   ControlToValidate="txtServiceType"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtServiceType" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liServicio" Text="Servicio" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revService" runat="server"   ControlToValidate="txtService"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtService" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liOperacion" Text="Operación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOperation" runat="server"   ControlToValidate="txtOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtOperation" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombreEstado" Text="Estado del Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revStatusName" runat="server"   ControlToValidate="txtStatusName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtStatusName" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liInfo" Text="Info" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revInfo" runat="server"   ControlToValidate="txtInfo"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtInfo"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liComentario" Text="Comentario" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revComment" runat="server"   ControlToValidate="txtComment"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtComment"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liFechaVieja" Text="Fecha Vieja" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataOld" runat="server"   ControlToValidate="txtDataOld"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataOld"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liFechaPreOperacion" Text="Fecha de Pre Operación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataPreOperation" runat="server"   ControlToValidate="txtDataPreOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataPreOperation"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liFechaPostOperacion" Text="Fecha de Post Operación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataPostOperation" runat="server"   ControlToValidate="txtDataPostOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataPostOperation"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaInicio" Text="Fecha de Inicio" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="false" ID="diStartDate" /></td>
	</tr><tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaFin" Text="Fecha de Fin" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diEndDate" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liEnableViewLog" Text="EnableViewLog" runat="server" ></asp:Literal>EnableViewLog</td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkEnableViewLog" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
