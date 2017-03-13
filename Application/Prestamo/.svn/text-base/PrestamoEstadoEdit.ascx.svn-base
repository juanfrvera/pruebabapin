<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoEstadoEdit.ascx.cs" Inherits="UI.Web.PrestamoEstadoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liPrestamo" Text="Préstamo" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlPrestamo" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPrestamo" runat="server" ControlToValidate="ddlPrestamo"  ValidationGroup="EditionPrestamoEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlEstado" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="EditionPrestamoEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaEstimada" Text="Fecha Estimada" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="false" ID="diFechaEstimada" /></td>
	</tr><tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaRealizada" Text="Fecha Realizada" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diFechaRealizada" /></td>
	</tr></table>
