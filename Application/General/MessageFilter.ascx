<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageFilter.ascx.cs" Inherits="UI.Web.MessageFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liMediaFrom" Text="Media From" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvMediaFrom" runat="server" ControlToValidate="ddlMediaFrom"  ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlMediaFrom" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liUsuarioDestinatario" Text="Usuario Destinatario" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvUserFrom" runat="server" ControlToValidate="ddlUserFrom"  ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlUserFrom" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liPrioridad" Text="Prioridad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="ddlPriority"  ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlPriority" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
		<td class="tdFilter" >
		    <div ><asp:Literal ID="liAsunto" Text="Asunto" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revSubject" runat="server"  ControlToValidate="txtSubject" ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtSubject" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liCuerpo" Text="Cuerpo" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revBody" runat="server"  ControlToValidate="txtBody" ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtBody" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liFechaInicio" Text="Fecha de Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td><td class="tdFilter" ><div ><asp:Literal ID="liFechaEnvio" Text="Fecha de Envío" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdSendDate"  />         
		</td>
		<td class="tdFilter" >
		    <div ><asp:Literal ID="liEsManual" Text="Es Manual" runat="server" ></asp:Literal></div>
		    <div><uc:ThreeState ID="chkIsManual" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liProyecto" Text="Código BAPIN" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvProyecto" runat="server" ControlToValidate="ddlProyecto"  ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlProyecto" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		        <td align="right" valign="bottom" >
		            <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		            &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterMessage" />
		        </td>
		</tr>
</table>
