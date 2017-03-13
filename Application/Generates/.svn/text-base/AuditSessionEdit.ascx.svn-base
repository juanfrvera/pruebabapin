<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditSessionEdit.ascx.cs" Inherits="UI.Web.AuditSessionEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  >UserName</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"   ControlToValidate="txtUserName"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El UserName no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtUserName"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Session</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revSessionId" runat="server"   ControlToValidate="txtSessionId"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El SessionId no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtSessionId"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Login</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revLogin" runat="server"   ControlToValidate="txtLogin"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Login no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtLogin"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Rols</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRols" runat="server"   ControlToValidate="txtRols"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Rols no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtRols"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Area</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revArea" runat="server"   ControlToValidate="txtArea"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Area no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtArea"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >IP</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIP" runat="server"   ControlToValidate="txtIP"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El IP no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtIP"  Width="100px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >BrowserVersion</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revBrowserVersion" runat="server"   ControlToValidate="txtBrowserVersion"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El BrowserVersion no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtBrowserVersion"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >OperatingSystem</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOperatingSystem" runat="server"   ControlToValidate="txtOperatingSystem"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El OperatingSystem no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtOperatingSystem"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
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
		<td class="tdLabel"  >Mandate</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revMandate" runat="server"   ControlToValidate="txtMandate"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Mandate no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtMandate"  Width="60px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Message</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revMessage" runat="server"   ControlToValidate="txtMessage"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Message no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtMessage"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Comments</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revComments" runat="server"   ControlToValidate="txtComments"  ValidationGroup="EditionAuditSession"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Comments no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtComments"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
