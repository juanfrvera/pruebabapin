<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoPrioridadEdit.ascx.cs" Inherits="UI.Web.ProyectoPrioridadEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liProyecto" Text="Proyecto" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlProyecto" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvProyecto" runat="server" ControlToValidate="ddlProyecto"  ValidationGroup="EditionProyectoPrioridad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liPlanPeriodo" Text="PlanPeriodo" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlPlanPeriodo" runat="server" CssClass="field_input"  ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPlanPeriodo" runat="server" ControlToValidate="ddlPlanPeriodo"  ValidationGroup="EditionProyectoPrioridad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liPrioridad" Text="Prioridad" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlPrioridad" runat="server" CssClass="field_input"  ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPrioridad" runat="server" ControlToValidate="ddlPrioridad"  ValidationGroup="EditionProyectoPrioridad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liPuntaje" Text="Puntaje" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revPuntaje" runat="server" ControlToValidate="txtPuntaje"  ValidationGroup="EditionProyectoPrioridad"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Puntaje no es valido"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvPuntaje" runat="server" ControlToValidate="txtPuntaje"  ValidationGroup="EditionProyectoPrioridad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtPuntaje" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liReqArt15" Text="ReqArt15" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkReqArt15" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liClasificacion" Text="Clasificacion" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlClasificacion" runat="server" CssClass="field_input"  ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvClasificacion" runat="server" ControlToValidate="ddlClasificacion"  ValidationGroup="EditionProyectoPrioridad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liComentario" Text="Comentario" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revComentario" runat="server"   ControlToValidate="txtComentario"  ValidationGroup="EditionProyectoPrioridad"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Comentario no es valido"></asp:RegularExpressionValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtComentario"  Width="100%"  MaxLength="500"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
