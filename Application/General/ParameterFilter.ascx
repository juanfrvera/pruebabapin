<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterFilter.ascx.cs" Inherits="UI.Web.ParameterFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style="width:230px;"><div ><asp:Literal ID="liParametroCategoria" Text="Categoría de Parametro" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvParameterCategory" runat="server" ControlToValidate="ddlParameterCategory"  ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlParameterCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
	    <td class="tdFilter" style="width:230px;" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"  ControlToValidate="txtName" ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtName" runat="server" CssClass="field_input" MaxLength="70"   ></asp:TextBox></div>
        </td><td class="tdFilter" style="width:230px;" ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"  ControlToValidate="txtCode" ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCode" runat="server" CssClass="field_input" MaxLength="50"  ></asp:TextBox></div>
        </td><td class="tdFilter" style="width:230px;"><div ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"  ControlToValidate="txtDescription" ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDescription" runat="server" CssClass="field_input"  ></asp:TextBox></div>

	</tr><tr>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liDataValue" Text="Valor Fecha" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdDateValue"  />         
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liStringValue" Text="Valor de la Cadena" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revStringValue" runat="server"  ControlToValidate="txtStringValue" ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtStringValue" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
        <%--<td class="tdFilter" ><div ><asp:Literal ID="liTextValue" Text="Valor Texto" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revTextValue" runat="server"  ControlToValidate="txtTextValue" ValidationGroup="FilterParameter" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtTextValue" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>--%>
        <td class="tdFilter" ><div ><asp:Literal ID="liNumberValue" Text=" Valor Número" runat="server" ></asp:Literal></div>
		 <div><uc:NumberRangeInput runat="server" ID="rnNumberValue"  /> </div>         
		</td>
	</tr>
	<tr>
	    <td class="tdFilter" ></td>
	    <td class="tdFilter" ></td>
	    <td class="tdFilter" ></td>
	    <td align="right" valign="bottom" >
	        <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
	        &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterParameter" />
	    </td>
	</tr>
</table>
