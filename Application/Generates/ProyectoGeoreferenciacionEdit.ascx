<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoGeoreferenciacionEdit.ascx.cs" Inherits="UI.Web.ProyectoGeoreferenciacionEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liProyecto" Text="Proyecto" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlProyecto" runat="server" CssClass="field_input"     ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvProyecto" InitialValue="0" runat="server" ControlToValidate="ddlProyecto"  ValidationGroup="EditionProyectoGeoreferenciacion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liGeoreferenciacion" Text="Georeferenciacion" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlGeoreferenciacion" runat="server" CssClass="field_input"     ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvGeoreferenciacion" InitialValue="0" runat="server" ControlToValidate="ddlGeoreferenciacion"  ValidationGroup="EditionProyectoGeoreferenciacion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
