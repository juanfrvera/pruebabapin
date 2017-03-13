<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditSessionFilter.ascx.cs" Inherits="UI.Web.AuditSessionFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div >UserName&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"  ControlToValidate="txtUserName" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El UserName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtUserName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >SessionId&nbsp;<asp:RegularExpressionValidator ID="revSessionId" runat="server"  ControlToValidate="txtSessionId" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El SessionId no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtSessionId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Login&nbsp;<asp:RegularExpressionValidator ID="revLogin" runat="server"  ControlToValidate="txtLogin" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Login no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtLogin" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Rols&nbsp;<asp:RegularExpressionValidator ID="revRols" runat="server"  ControlToValidate="txtRols" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Rols no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtRols" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >Area&nbsp;<asp:RegularExpressionValidator ID="revArea" runat="server"  ControlToValidate="txtArea" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Area no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtArea" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >IP&nbsp;<asp:RegularExpressionValidator ID="revIP" runat="server"  ControlToValidate="txtIP" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El IP no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtIP" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >BrowserVersion&nbsp;<asp:RegularExpressionValidator ID="revBrowserVersion" runat="server"  ControlToValidate="txtBrowserVersion" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El BrowserVersion no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtBrowserVersion" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >OperatingSystem&nbsp;<asp:RegularExpressionValidator ID="revOperatingSystem" runat="server"  ControlToValidate="txtOperatingSystem" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El OperatingSystem no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOperatingSystem" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >StartDate</div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td><td class="tdFilter" ><div >EndDate</div>
		 <uc:DateRangeInput runat="server" ID="rdEndDate"  />         
		</td><td class="tdFilter" ><div >Mandate&nbsp;<asp:RegularExpressionValidator ID="revMandate" runat="server"  ControlToValidate="txtMandate" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Mandate no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtMandate" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Message&nbsp;<asp:RegularExpressionValidator ID="revMessage" runat="server"  ControlToValidate="txtMessage" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Message no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtMessage" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >Comments&nbsp;<asp:RegularExpressionValidator ID="revComments" runat="server"  ControlToValidate="txtComments" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Comments no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtComments" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		</tr>
</table>
