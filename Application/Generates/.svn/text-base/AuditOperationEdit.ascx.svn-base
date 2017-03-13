<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationEdit.ascx.cs" Inherits="UI.Web.AuditOperationEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  >AuditSession</td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlAuditSession" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvAuditSession" runat="server" ControlToValidate="ddlAuditSession"  ValidationGroup="EditionAuditOperation"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  >UserName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"   ControlToValidate="txtUserName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El UserName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtUserName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >EntityName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityName" runat="server"   ControlToValidate="txtEntityName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >EntityBaseName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityBaseName" runat="server"   ControlToValidate="txtEntityBaseName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityBaseName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityBaseName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >TypeName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revTypeName" runat="server"   ControlToValidate="txtTypeName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El TypeName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtTypeName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Entity</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityId" runat="server"   ControlToValidate="txtEntityId"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityId no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityId"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >EntityKey</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revEntityKey" runat="server"   ControlToValidate="txtEntityKey"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityKey no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtEntityKey"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Module</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revModule" runat="server"   ControlToValidate="txtModule"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Module no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtModule"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >ServiceType</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revServiceType" runat="server"   ControlToValidate="txtServiceType"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El ServiceType no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtServiceType"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Service</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revService" runat="server"   ControlToValidate="txtService"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Service no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtService"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Operation</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOperation" runat="server"   ControlToValidate="txtOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Operation no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtOperation"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >StatusName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revStatusName" runat="server"   ControlToValidate="txtStatusName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El StatusName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtStatusName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Info</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revInfo" runat="server"   ControlToValidate="txtInfo"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Info no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtInfo"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Comment</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revComment" runat="server"   ControlToValidate="txtComment"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Comment no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtComment"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >DataOld</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataOld" runat="server"   ControlToValidate="txtDataOld"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El DataOld no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataOld"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >DataPreOperation</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataPreOperation" runat="server"   ControlToValidate="txtDataPreOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El DataPreOperation no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataPreOperation"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >DataPostOperation</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDataPostOperation" runat="server"   ControlToValidate="txtDataPostOperation"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El DataPostOperation no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDataPostOperation"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  >StartDate</td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" ID="diStartDate" /></td>
	</tr><tr>
		 <td class="tdLabel"  >EndDate</td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" ID="diEndDate" /></td>
	</tr><tr>
		<td class="tdLabel"  >EnableViewLog</td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkEnableViewLog" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		<td class="tdLabel"  >ApplicationName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revApplicationName" runat="server"   ControlToValidate="txtApplicationName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El ApplicationName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtApplicationName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >FormPath</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revFormPath" runat="server"   ControlToValidate="txtFormPath"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El FormPath no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtFormPath"  Width="100%"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >FormName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revFormName" runat="server"   ControlToValidate="txtFormName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El FormName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtFormName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >UserControlName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revUserControlName" runat="server"   ControlToValidate="txtUserControlName"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El UserControlName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtUserControlName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >UserControlPath</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revUserControlPath" runat="server"   ControlToValidate="txtUserControlPath"  ValidationGroup="EditionAuditOperation"  Text="*" Width="1px" Height="1px"  ErrorMessage="El UserControlPath no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtUserControlPath"  Width="100%"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
