<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationFilter.ascx.cs" Inherits="UI.Web.AuditOperationFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div >AuditSession&nbsp;<asp:RequiredFieldValidator ID="rfvAuditSession" runat="server" ControlToValidate="ddlAuditSession"  ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlAuditSession" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div >UserName&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"  ControlToValidate="txtUserName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El UserName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtUserName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >EntityName&nbsp;<asp:RegularExpressionValidator ID="revEntityName" runat="server"  ControlToValidate="txtEntityName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntityName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >EntityBaseName&nbsp;<asp:RegularExpressionValidator ID="revEntityBaseName" runat="server"  ControlToValidate="txtEntityBaseName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityBaseName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntityBaseName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >TypeName&nbsp;<asp:RegularExpressionValidator ID="revTypeName" runat="server"  ControlToValidate="txtTypeName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El TypeName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtTypeName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >EntityId&nbsp;<asp:RegularExpressionValidator ID="revEntityId" runat="server"  ControlToValidate="txtEntityId" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityId no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntityId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >EntityKey&nbsp;<asp:RegularExpressionValidator ID="revEntityKey" runat="server"  ControlToValidate="txtEntityKey" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El EntityKey no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntityKey" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Module&nbsp;<asp:RegularExpressionValidator ID="revModule" runat="server"  ControlToValidate="txtModule" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El Module no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtModule" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >ServiceType&nbsp;<asp:RegularExpressionValidator ID="revServiceType" runat="server"  ControlToValidate="txtServiceType" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El ServiceType no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtServiceType" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Service&nbsp;<asp:RegularExpressionValidator ID="revService" runat="server"  ControlToValidate="txtService" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El Service no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtService" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Operation&nbsp;<asp:RegularExpressionValidator ID="revOperation" runat="server"  ControlToValidate="txtOperation" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El Operation no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOperation" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >StatusName&nbsp;<asp:RegularExpressionValidator ID="revStatusName" runat="server"  ControlToValidate="txtStatusName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El StatusName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtStatusName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >Info&nbsp;<asp:RegularExpressionValidator ID="revInfo" runat="server"  ControlToValidate="txtInfo" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El Info no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtInfo" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >Comment&nbsp;<asp:RegularExpressionValidator ID="revComment" runat="server"  ControlToValidate="txtComment" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El Comment no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtComment" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >DataOld&nbsp;<asp:RegularExpressionValidator ID="revDataOld" runat="server"  ControlToValidate="txtDataOld" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El DataOld no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDataOld" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >DataPreOperation&nbsp;<asp:RegularExpressionValidator ID="revDataPreOperation" runat="server"  ControlToValidate="txtDataPreOperation" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El DataPreOperation no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDataPreOperation" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >DataPostOperation&nbsp;<asp:RegularExpressionValidator ID="revDataPostOperation" runat="server"  ControlToValidate="txtDataPostOperation" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El DataPostOperation no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDataPostOperation" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >StartDate</div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td><td class="tdFilter" ><div >EndDate</div>
		 <uc:DateRangeInput runat="server" ID="rdEndDate"  />         
		</td><td class="tdFilter" ><div >EnableViewLog</div>
		<div><uc:ThreeState ID="chkEnableViewLog" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div >ApplicationName&nbsp;<asp:RegularExpressionValidator ID="revApplicationName" runat="server"  ControlToValidate="txtApplicationName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El ApplicationName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtApplicationName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >FormPath&nbsp;<asp:RegularExpressionValidator ID="revFormPath" runat="server"  ControlToValidate="txtFormPath" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El FormPath no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtFormPath" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >FormName&nbsp;<asp:RegularExpressionValidator ID="revFormName" runat="server"  ControlToValidate="txtFormName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El FormName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtFormName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div >UserControlName&nbsp;<asp:RegularExpressionValidator ID="revUserControlName" runat="server"  ControlToValidate="txtUserControlName" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El UserControlName no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtUserControlName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div >UserControlPath&nbsp;<asp:RegularExpressionValidator ID="revUserControlPath" runat="server"  ControlToValidate="txtUserControlPath" ValidationGroup="FilterAuditOperation" Text="*" Width="1px" Height="1px"  ErrorMessage="El UserControlPath no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtUserControlPath" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		</tr>
</table>
