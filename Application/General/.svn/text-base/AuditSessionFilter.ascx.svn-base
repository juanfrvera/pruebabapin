<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditSessionFilter.ascx.cs" Inherits="UI.Web.AuditSessionFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
    <tr>	    
	    <td width="25%" class="tdFilter" ><div ><asp:Literal ID="liInicio" Text="Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td>		
	    <td  width="25%" class="tdFilter" ><div ><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revUserName" runat="server"  ControlToValidate="txtUserName" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El UserName no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtUserName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>        
        <td width="25%" class="tdFilter" ><div ><asp:Literal ID="liSesionId" Text="Sesión ID" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revSessionId" runat="server"  ControlToValidate="txtSessionId" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El SessionId no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtSessionId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td width="25%" class="tdFilter" ><div ><asp:Literal ID="liIP" Text="IP" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revIP" runat="server"  ControlToValidate="txtIP" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El IP no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtIP" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr>
	<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liFin" Text="Fin" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdEndDate"  />         
		</td>
        <td class="tdFilter" ><div ><asp:Literal ID="liNavigador" Text="Navegador" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revBrowserVersion" runat="server"  ControlToValidate="txtBrowserVersion" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El BrowserVersion no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtBrowserVersion" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" ><div ><asp:Literal ID="liSO" Text="S.O." runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revOperatingSystem" runat="server"  ControlToValidate="txtOperatingSystem" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El OperatingSystem no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOperatingSystem" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" ><div ><asp:Literal ID="liMandato" Text="Mandato" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revMandate" runat="server"  ControlToValidate="txtMandate" ValidationGroup="FilterAuditSession" Text="*" Width="1px" Height="1px"  ErrorMessage="El Mandate no es válido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtMandate" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
    </tr>
	<tr>
	    <td class="tdFilter" >      
		</td>
        <td class="tdFilter" > 
        </td>
        <td class="tdFilter" > 
        </td>
        <td align="right" valign="bottom" >
            <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
            &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true"  ValidationGroup="AuditSession" />
        </td>
	</tr>
</table>
